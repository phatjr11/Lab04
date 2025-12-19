using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab04_QLSV.Models;

namespace Lab04_QLSV
{
    public partial class frmFaculty : MetroFramework.Forms.MetroForm
    {
        private StudentContextDB context;

        public frmFaculty()
        {
            InitializeComponent();
            context = new StudentContextDB();
            this.Load += FrmFaculty_Load;
        }

        private void FrmFaculty_Load(object sender, EventArgs e)
        {
             try
            {
                ReloadList();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadList()
        {
            var list = context.Faculties.ToList();
            BindGrid(list);
        }

        private void BindGrid(List<Faculty> list)
        {
            dgvFaculty.Rows.Clear();
            foreach (var item in list)
            {
                int index = dgvFaculty.Rows.Add();
                dgvFaculty.Rows[index].Cells[0].Value = item.FacultyID;
                dgvFaculty.Rows[index].Cells[1].Value = item.FacultyName;
                dgvFaculty.Rows[index].Cells[2].Value = item.TotalProfessor;
            }
        }

        private void dgvFaculty_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFaculty.SelectedRows.Count > 0)
            {
                var row = dgvFaculty.SelectedRows[0];
                txtFacultyID.Text = row.Cells[0].Value?.ToString() ?? "";
                txtFacultyName.Text = row.Cells[1].Value?.ToString() ?? "";
                txtTotalProfessor.Text = row.Cells[2].Value?.ToString() ?? "0";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Faculty f = new Faculty()
                {
                    // Assuming FacultyID is NOT IDENTITY, since schema said int, PK. If Identity, don't set it.
                    // Usually in these labs we input ID manually? Checking schema...
                    // "FacultyID (int, PK)" doesn't specify identity. I'll assume manual input for now based on UI requirements usually involving ID input.
                    // Actually, let's look at schema again. 
                    // Wait, I can't check schema easily without SQL, but Entity Framework usually handles identity.
                    // If I put a textbox for ID, I assume it's manual.
                    FacultyID = int.Parse(txtFacultyID.Text),
                    FacultyName = txtFacultyName.Text,
                    TotalProfessor = int.TryParse(txtTotalProfessor.Text, out int tp) ? tp : 0
                };
                
                context.Faculties.Add(f);
                context.SaveChanges();
                ReloadList();
                MetroFramework.MetroMessageBox.Show(this, "Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

         private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtFacultyID.Text);
                Faculty f = context.Faculties.FirstOrDefault(p => p.FacultyID == id);
                if (f != null)
                {
                    f.FacultyName = txtFacultyName.Text;
                    f.TotalProfessor = int.TryParse(txtTotalProfessor.Text, out int tp) ? tp : 0;
                    context.SaveChanges();
                    ReloadList();
                    MetroFramework.MetroMessageBox.Show(this, "Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                     MetroFramework.MetroMessageBox.Show(this, "Không tìm thấy khoa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
             try
            {
                int id = int.Parse(txtFacultyID.Text);
                Faculty f = context.Faculties.FirstOrDefault(p => p.FacultyID == id);
                if (f != null)
                {
                     if (MetroFramework.MetroMessageBox.Show(this, "Bạn có chắc muốn xóa? Điều này sẽ ảnh hưởng đến sinh viên thuộc khoa này!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                     {
                        context.Faculties.Remove(f);
                        context.SaveChanges();
                        ReloadList();
                        ResetInput();
                        MetroFramework.MetroMessageBox.Show(this, "Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "Không thể xóa khoa này (có thể do ràng buộc khóa ngoại)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetInput()
        {
            txtFacultyID.Text = "";
            txtFacultyName.Text = "";
            txtTotalProfessor.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
