using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Lab04_QLSV.Models;

namespace Lab04_QLSV
{
    public partial class frmDashboard : MetroFramework.Forms.MetroForm
    {
        private StudentContextDB context;

        public frmDashboard()
        {
            InitializeComponent();
            context = new StudentContextDB();
            this.Load += FrmDashboard_Load;
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadData()
        {
            var students = context.Students.ToList();
            var faculties = context.Faculties.ToList();

            lblTotalStudents.Text = $"Tổng số sinh viên: {students.Count}";

            // 1. Chart Faculty (Pie)
            chartFaculty.Series["StudentsByFaculty"].Points.Clear();
            foreach (var faculty in faculties)
            {
                int count = students.Count(s => s.FacultyID == faculty.FacultyID);
                if (count > 0)
                {
                    chartFaculty.Series["StudentsByFaculty"].Points.AddXY(faculty.FacultyName, count);
                }
            }
            chartFaculty.Titles.Clear();
            chartFaculty.Titles.Add("Tỷ lệ sinh viên theo Khoa");

            // 2. Chart Grade (Column)
            chartGrade.Series["StudentsByGrade"].Points.Clear();
            
            var grades = new Dictionary<string, int>
            {
                { "Xuất sắc (>=9)", students.Count(s => s.AverageScore >= 9) },
                { "Giỏi (8-9)", students.Count(s => s.AverageScore >= 8 && s.AverageScore < 9) },
                { "Khá (7-8)", students.Count(s => s.AverageScore >= 7 && s.AverageScore < 8) },
                { "Trung bình (5-7)", students.Count(s => s.AverageScore >= 5 && s.AverageScore < 7) },
                { "Yếu (<5)", students.Count(s => s.AverageScore < 5) }
            };

            foreach (var grade in grades)
            {
                chartGrade.Series["StudentsByGrade"].Points.AddXY(grade.Key, grade.Value);
            }
            
            chartGrade.Titles.Clear();
            chartGrade.Titles.Add("Thống kê theo xếp loại học lực");
            chartGrade.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
