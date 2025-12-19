using Lab04_01;
using System;
using System.Linq;
using System.Windows.Forms;

// ✅ Namespace đúng theo EF model (thường là namespace project)
namespace Lab04
{
    public partial class frmStudentManagement : Form
    {
        public frmStudentManagement()
        {
            InitializeComponent();
        }

        // === LOAD FORM ===
        private void frmStudentManagement_Load(object sender, EventArgs e)
        {
            LoadStudentData();
            LoadFacultyData();
        }

        // 🔹 Bài 1: Load sinh viên
        private void LoadStudentData(string keyword = "")
        {
            try
            {
                using (var ctx = new StudentContextDB())
                {
                    var faculties = ctx.Faculties.ToList();
                    cmbFaculty.DataSource = faculties;
                    cmbFaculty.DisplayMember = "FacultyName";
                    cmbFaculty.ValueMember = "FacultyID";

                    var query = ctx.Students.AsQueryable();
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        string k = keyword.Trim().ToLower();
                        query = query.Where(s =>
                            s.StudentID.Contains(k) ||
                            s.FullName.ToLower().Contains(k) ||
                            s.Faculty.FacultyName.ToLower().Contains(k)
                        );
                    }

                    var students = query.ToList();
                    dgvStudent.Rows.Clear();
                    foreach (var s in students)
                    {
                        dgvStudent.Rows.Add(
                            s.StudentID,
                            s.FullName,
                            s.Faculty?.FacultyName ?? "—",
                            s.AverageScore.ToString("N1")
                        );
                    }
                    toolStripStatusLabel1.Text = $"Đã tải {students.Count} sinh viên";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi tải dữ liệu SV: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Bài 2: Load khoa
        private void LoadFacultyData()
        {
            try
            {
                using (var ctx = new StudentContextDB())
                {
                    var faculties = ctx.Faculties.ToList();
                    dgvFaculty.Rows.Clear();
                    foreach (var f in faculties)
                    {
                        dgvFaculty.Rows.Add(f.FacultyID, f.FacultyName, f.TotalProfessor);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi tải dữ liệu Khoa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === 🔸 SINH VIÊN: Thêm/Sửa/Xóa ===
        private bool ValidateStudent(out string id, out string name, out float score, out int fid)
        {
            id = txtStudentID.Text.Trim();
            name = txtFullName.Text.Trim();
            string scoreStr = txtAverageScore.Text.Trim();
            score = 0f; fid = -1;

            if (string.IsNullOrEmpty(id) || id.Length != 10)
            { MessageBox.Show("⚠️ Mã SV phải có đúng 10 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (string.IsNullOrEmpty(name))
            { MessageBox.Show("⚠️ Vui lòng nhập họ tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (string.IsNullOrEmpty(scoreStr) || !float.TryParse(scoreStr, out score) || score < 0 || score > 10)
            { MessageBox.Show("⚠️ Điểm TB phải từ 0.0 đến 10.0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (cmbFaculty.SelectedValue == null)
            { MessageBox.Show("⚠️ Chưa chọn khoa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            fid = (int)cmbFaculty.SelectedValue;
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateStudent(out string id, out string name, out float score, out int fid)) return;
            try
            {
                using (var ctx = new StudentContextDB())
                {
                    if (ctx.Students.Any(s => s.StudentID == id))
                    { MessageBox.Show("❌ Mã SV đã tồn tại! Dùng chức năng Sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    ctx.Students.Add(new Student { StudentID = id, FullName = name, AverageScore = score, FacultyID = fid });
                    ctx.SaveChanges();
                    MessageBox.Show("✅ Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetStudent();
                    LoadStudentData();
                }
            }
            catch (Exception ex) { MessageBox.Show($"❌ Lỗi thêm SV: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtStudentID.Text.Trim();
            if (string.IsNullOrEmpty(id)) { MessageBox.Show("⚠️ Chưa chọn SV để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!ValidateStudent(out _, out string name, out float score, out int fid)) return;
            try
            {
                using (var ctx = new StudentContextDB())
                {
                    var s = ctx.Students.FirstOrDefault(x => x.StudentID == id);
                    if (s == null) { MessageBox.Show("❌ Không tìm thấy SV cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    s.FullName = name; s.AverageScore = score; s.FacultyID = fid;
                    ctx.SaveChanges();
                    MessageBox.Show("✅ Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetStudent();
                    LoadStudentData();
                }
            }
            catch (Exception ex) { MessageBox.Show($"❌ Lỗi sửa SV: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtStudentID.Text.Trim();
            if (string.IsNullOrEmpty(id)) { MessageBox.Show("⚠️ Chưa chọn SV để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show("Bạn có chắc muốn xóa SV này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                using (var ctx = new StudentContextDB())
                {
                    var s = ctx.Students.FirstOrDefault(x => x.StudentID == id);
                    if (s == null) { MessageBox.Show("❌ Không tìm thấy SV cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    ctx.Students.Remove(s);
                    ctx.SaveChanges();
                    MessageBox.Show("✅ Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetStudent();
                    LoadStudentData();
                }
            }
            catch (Exception ex) { MessageBox.Show($"❌ Lỗi xóa SV: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // === 🔸 Click grid → fill form ===
        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvStudent.Rows[e.RowIndex];
            txtStudentID.Text = row.Cells[0].Value?.ToString() ?? "";
            txtFullName.Text = row.Cells[1].Value?.ToString() ?? "";
            txtAverageScore.Text = row.Cells[3].Value?.ToString() ?? "";
            string f = row.Cells[2].Value?.ToString() ?? "";
            cmbFaculty.SelectedIndex = cmbFaculty.FindStringExact(f);
        }

        private void ResetStudent()
        {
            txtStudentID.Clear(); txtFullName.Clear(); txtAverageScore.Clear(); cmbFaculty.SelectedIndex = 0;
        }

        // === 🔸 KHOA: Thêm/Sửa/Xóa ===
        private bool ValidateFaculty(out int id, out string name, out int prof)
        {
            id = -1; name = ""; prof = 0;
            if (string.IsNullOrEmpty(txtFacultyID.Text) || !int.TryParse(txtFacultyID.Text, out id) || id <= 0)
            { MessageBox.Show("⚠️ Mã khoa phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            name = txtFacultyName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            { MessageBox.Show("⚠️ Vui lòng nhập tên khoa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (string.IsNullOrEmpty(txtTotalProfessor.Text) || !int.TryParse(txtTotalProfessor.Text, out prof) || prof < 0)
            { MessageBox.Show("⚠️ Số giáo viên phải ≥ 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            return true;
        }

        private void btnFAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFaculty(out int id, out string name, out int prof)) return;
            try
            {
                using (var ctx = new StudentContextDB())
                {
                    if (ctx.Faculties.Any(f => f.FacultyID == id))
                    { MessageBox.Show("❌ Mã khoa đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    ctx.Faculties.Add(new Faculty { FacultyID = id, FacultyName = name, TotalProfessor = prof });
                    ctx.SaveChanges();
                    MessageBox.Show("✅ Thêm khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFaculty();
                    LoadFacultyData();
                }
            }
            catch (Exception ex) { MessageBox.Show($"❌ Lỗi thêm khoa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnFUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFacultyID.Text) || !int.TryParse(txtFacultyID.Text, out int id))
            { MessageBox.Show("⚠️ Chưa chọn khoa để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!ValidateFaculty(out _, out string name, out int prof)) return;
            try
            {
                using (var ctx = new StudentContextDB())
                {
                    var f = ctx.Faculties.FirstOrDefault(x => x.FacultyID == id);
                    if (f == null) { MessageBox.Show("❌ Không tìm thấy khoa cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    f.FacultyName = name; f.TotalProfessor = prof;
                    ctx.SaveChanges();
                    MessageBox.Show("✅ Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFaculty();
                    LoadFacultyData();
                }
            }
            catch (Exception ex) { MessageBox.Show($"❌ Lỗi sửa khoa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnFDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFacultyID.Text) || !int.TryParse(txtFacultyID.Text, out int id))
            { MessageBox.Show("⚠️ Chưa chọn khoa để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            try
            {
                using (var ctx = new StudentContextDB())
                {
                    if (ctx.Students.Any(s => s.FacultyID == id))
                    { MessageBox.Show("❌ Khoa đang có sinh viên → không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    var f = ctx.Faculties.FirstOrDefault(x => x.FacultyID == id);
                    if (f == null) { MessageBox.Show("❌ Không tìm thấy khoa cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    if (MessageBox.Show("Xóa khoa này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    ctx.Faculties.Remove(f);
                    ctx.SaveChanges();
                    MessageBox.Show("✅ Xóa khoa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFaculty();
                    LoadFacultyData();
                }
            }
            catch (Exception ex) { MessageBox.Show($"❌ Lỗi xóa khoa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvFaculty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvFaculty.Rows[e.RowIndex];
            txtFacultyID.Text = row.Cells[0].Value?.ToString() ?? "";
            txtFacultyName.Text = row.Cells[1].Value?.ToString() ?? "";
            txtTotalProfessor.Text = row.Cells[2].Value?.ToString() ?? "";
        }

        private void ResetFaculty()
        {
            txtFacultyID.Clear(); txtFacultyName.Clear(); txtTotalProfessor.Clear();
        }

        // === 🔹 Tìm kiếm (Bài 3) ===
        private void btnSearch_Click(object sender, EventArgs e) => LoadStudentData(txtSearch.Text);
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoadStudentData(txtSearch.Text);
        }
    }
}