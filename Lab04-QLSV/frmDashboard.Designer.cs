namespace Lab04_QLSV
{
    partial class frmDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartFaculty = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartGrade = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTotalStudents = new MetroFramework.Controls.MetroLabel();
            this.btnClose = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartFaculty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGrade)).BeginInit();
            this.SuspendLayout();
            // 
            // chartFaculty
            // 
            chartArea1.Name = "ChartArea1";
            this.chartFaculty.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartFaculty.Legends.Add(legend1);
            this.chartFaculty.Location = new System.Drawing.Point(23, 100);
            this.chartFaculty.Name = "chartFaculty";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "StudentsByFaculty";
            this.chartFaculty.Series.Add(series1);
            this.chartFaculty.Size = new System.Drawing.Size(350, 300);
            this.chartFaculty.TabIndex = 0;
            this.chartFaculty.Text = "Biểu đồ Khoa";
            // 
            // chartGrade
            // 
            chartArea2.Name = "ChartArea1";
            this.chartGrade.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartGrade.Legends.Add(legend2);
            this.chartGrade.Location = new System.Drawing.Point(400, 100);
            this.chartGrade.Name = "chartGrade";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "StudentsByGrade";
            this.chartGrade.Series.Add(series2);
            this.chartGrade.Size = new System.Drawing.Size(350, 300);
            this.chartGrade.TabIndex = 1;
            this.chartGrade.Text = "Biểu đồ Xếp loại";
            // 
            // lblTotalStudents
            // 
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTotalStudents.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTotalStudents.Location = new System.Drawing.Point(23, 63);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(176, 25);
            this.lblTotalStudents.TabIndex = 2;
            this.lblTotalStudents.Text = "Tổng số sinh viên: 0";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(675, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 460);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTotalStudents);
            this.Controls.Add(this.chartGrade);
            this.Controls.Add(this.chartFaculty);
            this.Name = "frmDashboard";
            this.Text = "Thống kê dữ liệu";
            ((System.ComponentModel.ISupportInitialize)(this.chartFaculty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGrade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartFaculty;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGrade;
        private MetroFramework.Controls.MetroLabel lblTotalStudents;
        private MetroFramework.Controls.MetroButton btnClose;
    }
}
