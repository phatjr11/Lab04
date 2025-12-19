using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lab04_QLSV.Models;

namespace Lab04_QLSV
{
    public partial class frmQLSV : MetroFramework.Forms.MetroForm
    {
        private StudentContextDB context;

        public frmQLSV()
        {
            InitializeComponent();
            context = new StudentContextDB();
            this.Load += FrmQLSV_Load;
        }

        private void FrmQLSV_Load(object sender, EventArgs e)
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
            var listStudents = context.Students.Include("Faculty").ToList();
            BindGrid(listStudents);
        }

        private void BindGrid(List<Student> listStudents)
        {
            dgvStudents.Rows.Clear();
            foreach (var item in listStudents)
            {
                int index = dgvStudents.Rows.Add();
                dgvStudents.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudents.Rows[index].Cells[1].Value = item.FullName;
                dgvStudents.Rows[index].Cells[2].Value = item.Faculty != null ? item.Faculty.FacultyName : "N/A";
                dgvStudents.Rows[index].Cells[3].Value = item.AverageScore;
            }
            if (dgvStudents.Rows.Count > 0)
            {
                UpdatePreview(listStudents[0].StudentID);
            }
        }

        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                string studentID = dgvStudents.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
                UpdatePreview(studentID);
            }
        }

        private void UpdatePreview(string studentID)
        {
            try
            {
                var s = context.Students.FirstOrDefault(p => p.StudentID == studentID);
                if (s != null)
                {
                    lblDetailInfo.Text = $"MSSV: {s.StudentID}\n" +
                                        $"Họ tên: {s.FullName}\n" +
                                        $"Giới tính: {s.Gender ?? "N/A"}\n" +
                                        $"Ngày sinh: {(s.BirthDate.HasValue ? s.BirthDate.Value.ToShortDateString() : "N/A")}\n" +
                                        $"Địa chỉ: {s.Address ?? "N/A"}";

                    if (!string.IsNullOrEmpty(s.Avatar))
                    {
                        string fullPath = Path.Combine(Application.StartupPath, "Images", s.Avatar);
                        if (File.Exists(fullPath))
                        {
                            // Use a stream to avoid locking the file
                            using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                            {
                                picPreview.Image = Image.FromStream(fs);
                            }
                        }
                        else
                        {
                            picPreview.Image = null;
                        }
                    }
                    else
                    {
                        picPreview.Image = null;
                    }
                }
            }
            catch { 
                picPreview.Image = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddStudent frm = new frmAddStudent();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ReloadList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                string studentID = dgvStudents.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
                Student s = context.Students.FirstOrDefault(p => p.StudentID == studentID);
                if (s != null)
                {
                    frmAddStudent frm = new frmAddStudent(s);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        ReloadList();
                    }
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Vui lòng chọn sinh viên cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
             if (dgvStudents.SelectedRows.Count > 0)
            {
                string studentID = dgvStudents.SelectedRows[0].Cells[0].Value?.ToString() ?? "";
                if (MetroFramework.MetroMessageBox.Show(this, "Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Student s = context.Students.FirstOrDefault(p => p.StudentID == studentID);
                    if (s != null)
                    {
                        context.Students.Remove(s);
                        context.SaveChanges();
                        ReloadList();
                        MetroFramework.MetroMessageBox.Show(this, "Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnFaculty_Click(object sender, EventArgs e)
        {
            frmFaculty frm = new frmFaculty();
            frm.ShowDialog();
            ReloadList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
             frmSearch frm = new frmSearch();
             frm.ShowDialog();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
