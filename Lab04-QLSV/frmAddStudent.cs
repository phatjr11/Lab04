using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lab04_QLSV.Models;

namespace Lab04_QLSV
{
    public partial class frmAddStudent : MetroFramework.Forms.MetroForm
    {
        private StudentContextDB context;
        private Student existingStudent;
        private bool isEditMode = false;
        private string avatarPath = string.Empty;

        public frmAddStudent(Student s = null)
        {
            InitializeComponent();
            context = new StudentContextDB();
            this.existingStudent = s;
            if (s != null)
                isEditMode = true;
                
            this.Load += FrmAddStudent_Load;
        }

        private void FrmAddStudent_Load(object sender, EventArgs e)
        {
            try
            {
                FillFaculty();
                if (isEditMode)
                {
                    this.Text = "Cập nhật sinh viên";
                    txtStudentID.Text = existingStudent.StudentID;
                    txtFullName.Text = existingStudent.FullName;
                    txtAvgScore.Text = existingStudent.AverageScore.ToString();
                    cboFaculty.SelectedValue = existingStudent.FacultyID;
                    txtStudentID.Enabled = false; // Cannot change ID
                    
                    // Phase 2 Fields
                    if (existingStudent.Gender == "Nam") rbMale.Checked = true;
                    else if (existingStudent.Gender == "Nữ") rbFemale.Checked = true;
                    
                    if (existingStudent.BirthDate.HasValue)
                        dtpBirthDate.Value = existingStudent.BirthDate.Value;
                    
                    txtAddress.Text = existingStudent.Address;
                    
                    if (!string.IsNullOrEmpty(existingStudent.Avatar))
                    {
                        string fullPath = Path.Combine(Application.StartupPath, "Images", existingStudent.Avatar);
                        if (File.Exists(fullPath))
                        {
                            picAvatar.Image = Image.FromFile(fullPath);
                            avatarPath = existingStudent.Avatar;
                        }
                    }
                }
                else
                {
                    this.Text = "Thêm mới sinh viên";
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillFaculty()
        {
            var list = context.Faculties.ToList();
            cboFaculty.DataSource = list;
            cboFaculty.DisplayMember = "FacultyName";
            cboFaculty.ValueMember = "FacultyID";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picAvatar.Image = Image.FromFile(ofd.FileName);
                    avatarPath = ofd.FileName; // Temporarily store full path
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             try
            {
                // Validate
                if (string.IsNullOrWhiteSpace(txtStudentID.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(txtAvgScore.Text, out double score) || score < 0 || score > 10)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Điểm trung bình không hợp lệ (0-10)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string gender = rbMale.Checked ? "Nam" : "Nữ";
                DateTime birthDate = dtpBirthDate.Value;
                string address = txtAddress.Text;
                string finalAvatarName = string.Empty;

                // Handle Avatar Copy
                if (!string.IsNullOrEmpty(avatarPath) && File.Exists(avatarPath))
                {
                    string imagesFolder = Path.Combine(Application.StartupPath, "Images");
                    if (!Directory.Exists(imagesFolder)) Directory.CreateDirectory(imagesFolder);

                    string fileName = txtStudentID.Text + Path.GetExtension(avatarPath);
                    string destPath = Path.Combine(imagesFolder, fileName);
                    
                    // Don't copy if it's already there (same path)
                    if (avatarPath != destPath)
                    {
                        File.Copy(avatarPath, destPath, true);
                    }
                    finalAvatarName = fileName;
                } else if (isEditMode) {
                    finalAvatarName = existingStudent.Avatar;
                }

                if (isEditMode)
                {
                    Student s = context.Students.FirstOrDefault(p => p.StudentID == existingStudent.StudentID);
                    if (s != null)
                    {
                        s.FullName = txtFullName.Text;
                        s.AverageScore = score;
                        s.FacultyID = (int)cboFaculty.SelectedValue;
                        s.Gender = gender;
                        s.BirthDate = birthDate;
                        s.Address = address;
                        s.Avatar = finalAvatarName;

                        context.SaveChanges();
                        MetroFramework.MetroMessageBox.Show(this, "Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    Student s = context.Students.FirstOrDefault(p => p.StudentID == txtStudentID.Text);
                    if (s != null)
                    {
                         MetroFramework.MetroMessageBox.Show(this, "Mã sinh viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         return;
                    }

                    s = new Student()
                    {
                        StudentID = txtStudentID.Text,
                        FullName = txtFullName.Text,
                        AverageScore = score,
                        FacultyID = (int)cboFaculty.SelectedValue,
                        Gender = gender,
                        BirthDate = birthDate,
                        Address = address,
                        Avatar = finalAvatarName
                    };
                    context.Students.Add(s);
                    context.SaveChanges();
                    MetroFramework.MetroMessageBox.Show(this, "Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
