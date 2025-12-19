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
using System.Data.Entity;

namespace Lab04_QLSV
{
    public partial class frmSearch : MetroFramework.Forms.MetroForm
    {
        private StudentContextDB context;

        public frmSearch()
        {
            InitializeComponent();
             context = new StudentContextDB();
             this.Load += FrmSearch_Load;
        }

        private void FrmSearch_Load(object sender, EventArgs e)
        {
             try
            {
                FillFaculty();
                BindGrid(context.Students.ToList());
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillFaculty()
        {
            var list = context.Faculties.ToList();
            list.Insert(0, new Faculty() { FacultyID = 0, FacultyName = "Toàn bộ" });
            cboFaculty.DataSource = list;
            cboFaculty.DisplayMember = "FacultyName";
            cboFaculty.ValueMember = "FacultyID";
            cboFaculty.SelectedIndex = 0;
        }

        private void BindGrid(List<Student> list)
        {
             dgvSearch.Rows.Clear();
            foreach (var item in list)
            {
                int index = dgvSearch.Rows.Add();
                dgvSearch.Rows[index].Cells[0].Value = item.StudentID;
                dgvSearch.Rows[index].Cells[1].Value = item.FullName;
                dgvSearch.Rows[index].Cells[2].Value = item.Faculty != null ? item.Faculty.FacultyName : "N/A";
                dgvSearch.Rows[index].Cells[3].Value = item.AverageScore;
            }
            lblResult.Text = "Kết quả tìm kiếm: " + list.Count;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var query = context.Students.AsQueryable();

                // Make sure we include Faculty for display
                query = query.Include("Faculty");

                // Filter by Faculty
                if (cboFaculty.SelectedIndex > 0)
                {
                    int facultyID = (int)cboFaculty.SelectedValue;
                    query = query.Where(p => p.FacultyID == facultyID);
                }

                // Filter by name or ID (using same textbox)
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    string keyword = txtSearch.Text.ToLower();
                    query = query.Where(p => p.FullName.ToLower().Contains(keyword) || p.StudentID.ToLower().Contains(keyword));
                }

                var list = query.ToList();
                BindGrid(list);

                if (list.Count == 0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                 MetroFramework.MetroMessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInput();
        }

        private void ResetInput()
        {
            cboFaculty.SelectedIndex = 0;
            txtSearch.Text = "";
            BindGrid(context.Students.Include("Faculty").ToList());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
