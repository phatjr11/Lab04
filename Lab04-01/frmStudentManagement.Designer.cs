namespace Lab04
{
    partial class frmStudentManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStudent = new System.Windows.Forms.TabPage();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.colStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFacultyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAverageScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxStudentInput = new System.Windows.Forms.GroupBox();
            this.txtAverageScore = new System.Windows.Forms.TextBox();
            this.cmbFaculty = new System.Windows.Forms.ComboBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.lblFaculty = new System.Windows.Forms.Label();
            this.lblAverageScore = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tabFaculty = new System.Windows.Forms.TabPage();
            this.dgvFaculty = new System.Windows.Forms.DataGridView();
            this.colFID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalProfessor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxFaculty = new System.Windows.Forms.GroupBox();
            this.txtTotalProfessor = new System.Windows.Forms.TextBox();
            this.txtFacultyName = new System.Windows.Forms.TextBox();
            this.txtFacultyID = new System.Windows.Forms.TextBox();
            this.lblTotalProfessor = new System.Windows.Forms.Label();
            this.lblFacultyName = new System.Windows.Forms.Label();
            this.lblFacultyID = new System.Windows.Forms.Label();
            this.btnFDelete = new System.Windows.Forms.Button();
            this.btnFUpdate = new System.Windows.Forms.Button();
            this.btnFAdd = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabStudent.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.groupBoxStudentInput.SuspendLayout();
            this.tabFaculty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaculty)).BeginInit();
            this.groupBoxFaculty.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStudent);
            this.tabControl1.Controls.Add(this.tabFaculty);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(735, 421);
            this.tabControl1.TabIndex = 0;
            // 
            // tabStudent
            // 
            this.tabStudent.Controls.Add(this.groupBoxSearch);
            this.tabStudent.Controls.Add(this.dgvStudent);
            this.tabStudent.Controls.Add(this.groupBoxStudentInput);
            this.tabStudent.Location = new System.Drawing.Point(4, 22);
            this.tabStudent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabStudent.Name = "tabStudent";
            this.tabStudent.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabStudent.Size = new System.Drawing.Size(727, 395);
            this.tabStudent.TabIndex = 0;
            this.tabStudent.Text = "Sinh viên";
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.btnSearch);
            this.groupBoxSearch.Controls.Add(this.txtSearch);
            this.groupBoxSearch.Controls.Add(this.lblSearch);
            this.groupBoxSearch.Location = new System.Drawing.Point(300, 16);
            this.groupBoxSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxSearch.Size = new System.Drawing.Size(412, 162);
            this.groupBoxSearch.TabIndex = 0;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Tìm kiếm & Thống kê";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(315, 21);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(60, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(150, 22);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(151, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(11, 24);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(155, 13);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Từ khóa (MSSV, họ tên, khoa):";
            // 
            // dgvStudent
            // 
            this.dgvStudent.AllowUserToAddRows = false;
            this.dgvStudent.AllowUserToDeleteRows = false;
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStudentID,
            this.colFullName,
            this.colFacultyName,
            this.colAverageScore});
            this.dgvStudent.Location = new System.Drawing.Point(15, 187);
            this.dgvStudent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.ReadOnly = true;
            this.dgvStudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudent.Size = new System.Drawing.Size(698, 203);
            this.dgvStudent.TabIndex = 1;
            this.dgvStudent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellClick);
            // 
            // colStudentID
            // 
            this.colStudentID.Name = "colStudentID";
            this.colStudentID.ReadOnly = true;
            // 
            // colFullName
            // 
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            // 
            // colFacultyName
            // 
            this.colFacultyName.Name = "colFacultyName";
            this.colFacultyName.ReadOnly = true;
            // 
            // colAverageScore
            // 
            this.colAverageScore.Name = "colAverageScore";
            this.colAverageScore.ReadOnly = true;
            // 
            // groupBoxStudentInput
            // 
            this.groupBoxStudentInput.Controls.Add(this.txtAverageScore);
            this.groupBoxStudentInput.Controls.Add(this.cmbFaculty);
            this.groupBoxStudentInput.Controls.Add(this.txtFullName);
            this.groupBoxStudentInput.Controls.Add(this.txtStudentID);
            this.groupBoxStudentInput.Controls.Add(this.lblFaculty);
            this.groupBoxStudentInput.Controls.Add(this.lblAverageScore);
            this.groupBoxStudentInput.Controls.Add(this.lblFullName);
            this.groupBoxStudentInput.Controls.Add(this.lblStudentID);
            this.groupBoxStudentInput.Controls.Add(this.btnDelete);
            this.groupBoxStudentInput.Controls.Add(this.btnUpdate);
            this.groupBoxStudentInput.Controls.Add(this.btnAdd);
            this.groupBoxStudentInput.Location = new System.Drawing.Point(15, 16);
            this.groupBoxStudentInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxStudentInput.Name = "groupBoxStudentInput";
            this.groupBoxStudentInput.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxStudentInput.Size = new System.Drawing.Size(270, 162);
            this.groupBoxStudentInput.TabIndex = 2;
            this.groupBoxStudentInput.TabStop = false;
            this.groupBoxStudentInput.Text = "Thông tin sinh viên";
            // 
            // txtAverageScore
            // 
            this.txtAverageScore.Location = new System.Drawing.Point(90, 79);
            this.txtAverageScore.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAverageScore.Name = "txtAverageScore";
            this.txtAverageScore.Size = new System.Drawing.Size(76, 20);
            this.txtAverageScore.TabIndex = 0;
            // 
            // cmbFaculty
            // 
            this.cmbFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFaculty.Location = new System.Drawing.Point(90, 107);
            this.cmbFaculty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbFaculty.Name = "cmbFaculty";
            this.cmbFaculty.Size = new System.Drawing.Size(166, 21);
            this.cmbFaculty.TabIndex = 1;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(90, 50);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(166, 20);
            this.txtFullName.TabIndex = 2;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(90, 22);
            this.txtStudentID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStudentID.MaxLength = 10;
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(114, 20);
            this.txtStudentID.TabIndex = 3;
            // 
            // lblFaculty
            // 
            this.lblFaculty.AutoSize = true;
            this.lblFaculty.Location = new System.Drawing.Point(11, 110);
            this.lblFaculty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFaculty.Name = "lblFaculty";
            this.lblFaculty.Size = new System.Drawing.Size(35, 13);
            this.lblFaculty.TabIndex = 4;
            this.lblFaculty.Text = "Khoa:";
            // 
            // lblAverageScore
            // 
            this.lblAverageScore.AutoSize = true;
            this.lblAverageScore.Location = new System.Drawing.Point(11, 81);
            this.lblAverageScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAverageScore.Name = "lblAverageScore";
            this.lblAverageScore.Size = new System.Drawing.Size(51, 13);
            this.lblAverageScore.TabIndex = 5;
            this.lblAverageScore.Text = "Điểm TB:";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(11, 53);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(42, 13);
            this.lblFullName.TabIndex = 6;
            this.lblFullName.Text = "Họ tên:";
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(11, 24);
            this.lblStudentID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(42, 13);
            this.lblStudentID.TabIndex = 7;
            this.lblStudentID.Text = "Mã SV:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(154, 134);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(82, 134);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(60, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(11, 134);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabFaculty
            // 
            this.tabFaculty.Controls.Add(this.dgvFaculty);
            this.tabFaculty.Controls.Add(this.groupBoxFaculty);
            this.tabFaculty.Location = new System.Drawing.Point(4, 22);
            this.tabFaculty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabFaculty.Name = "tabFaculty";
            this.tabFaculty.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabFaculty.Size = new System.Drawing.Size(727, 396);
            this.tabFaculty.TabIndex = 1;
            this.tabFaculty.Text = "Khoa";
            // 
            // dgvFaculty
            // 
            this.dgvFaculty.AllowUserToAddRows = false;
            this.dgvFaculty.AllowUserToDeleteRows = false;
            this.dgvFaculty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaculty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFID,
            this.colFName,
            this.colTotalProfessor});
            this.dgvFaculty.Location = new System.Drawing.Point(15, 171);
            this.dgvFaculty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvFaculty.Name = "dgvFaculty";
            this.dgvFaculty.ReadOnly = true;
            this.dgvFaculty.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFaculty.Size = new System.Drawing.Size(698, 219);
            this.dgvFaculty.TabIndex = 0;
            this.dgvFaculty.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaculty_CellClick);
            // 
            // colFID
            // 
            this.colFID.Name = "colFID";
            this.colFID.ReadOnly = true;
            // 
            // colFName
            // 
            this.colFName.Name = "colFName";
            this.colFName.ReadOnly = true;
            // 
            // colTotalProfessor
            // 
            this.colTotalProfessor.Name = "colTotalProfessor";
            this.colTotalProfessor.ReadOnly = true;
            // 
            // groupBoxFaculty
            // 
            this.groupBoxFaculty.Controls.Add(this.txtTotalProfessor);
            this.groupBoxFaculty.Controls.Add(this.txtFacultyName);
            this.groupBoxFaculty.Controls.Add(this.txtFacultyID);
            this.groupBoxFaculty.Controls.Add(this.lblTotalProfessor);
            this.groupBoxFaculty.Controls.Add(this.lblFacultyName);
            this.groupBoxFaculty.Controls.Add(this.lblFacultyID);
            this.groupBoxFaculty.Controls.Add(this.btnFDelete);
            this.groupBoxFaculty.Controls.Add(this.btnFUpdate);
            this.groupBoxFaculty.Controls.Add(this.btnFAdd);
            this.groupBoxFaculty.Location = new System.Drawing.Point(15, 16);
            this.groupBoxFaculty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxFaculty.Name = "groupBoxFaculty";
            this.groupBoxFaculty.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxFaculty.Size = new System.Drawing.Size(270, 146);
            this.groupBoxFaculty.TabIndex = 1;
            this.groupBoxFaculty.TabStop = false;
            this.groupBoxFaculty.Text = "Thông tin khoa";
            // 
            // txtTotalProfessor
            // 
            this.txtTotalProfessor.Location = new System.Drawing.Point(90, 79);
            this.txtTotalProfessor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTotalProfessor.Name = "txtTotalProfessor";
            this.txtTotalProfessor.Size = new System.Drawing.Size(76, 20);
            this.txtTotalProfessor.TabIndex = 0;
            // 
            // txtFacultyName
            // 
            this.txtFacultyName.Location = new System.Drawing.Point(90, 50);
            this.txtFacultyName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFacultyName.Name = "txtFacultyName";
            this.txtFacultyName.Size = new System.Drawing.Size(166, 20);
            this.txtFacultyName.TabIndex = 1;
            // 
            // txtFacultyID
            // 
            this.txtFacultyID.Location = new System.Drawing.Point(90, 22);
            this.txtFacultyID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFacultyID.Name = "txtFacultyID";
            this.txtFacultyID.Size = new System.Drawing.Size(76, 20);
            this.txtFacultyID.TabIndex = 2;
            // 
            // lblTotalProfessor
            // 
            this.lblTotalProfessor.AutoSize = true;
            this.lblTotalProfessor.Location = new System.Drawing.Point(11, 81);
            this.lblTotalProfessor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalProfessor.Name = "lblTotalProfessor";
            this.lblTotalProfessor.Size = new System.Drawing.Size(41, 13);
            this.lblTotalProfessor.TabIndex = 3;
            this.lblTotalProfessor.Text = "Số GV:";
            // 
            // lblFacultyName
            // 
            this.lblFacultyName.AutoSize = true;
            this.lblFacultyName.Location = new System.Drawing.Point(11, 53);
            this.lblFacultyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFacultyName.Name = "lblFacultyName";
            this.lblFacultyName.Size = new System.Drawing.Size(56, 13);
            this.lblFacultyName.TabIndex = 4;
            this.lblFacultyName.Text = "Tên khoa:";
            // 
            // lblFacultyID
            // 
            this.lblFacultyID.AutoSize = true;
            this.lblFacultyID.Location = new System.Drawing.Point(11, 24);
            this.lblFacultyID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFacultyID.Name = "lblFacultyID";
            this.lblFacultyID.Size = new System.Drawing.Size(52, 13);
            this.lblFacultyID.TabIndex = 5;
            this.lblFacultyID.Text = "Mã khoa:";
            // 
            // btnFDelete
            // 
            this.btnFDelete.Location = new System.Drawing.Point(154, 110);
            this.btnFDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFDelete.Name = "btnFDelete";
            this.btnFDelete.Size = new System.Drawing.Size(60, 23);
            this.btnFDelete.TabIndex = 6;
            this.btnFDelete.Text = "Xóa";
            this.btnFDelete.Click += new System.EventHandler(this.btnFDelete_Click);
            // 
            // btnFUpdate
            // 
            this.btnFUpdate.Location = new System.Drawing.Point(82, 110);
            this.btnFUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFUpdate.Name = "btnFUpdate";
            this.btnFUpdate.Size = new System.Drawing.Size(60, 23);
            this.btnFUpdate.TabIndex = 7;
            this.btnFUpdate.Text = "Sửa";
            this.btnFUpdate.Click += new System.EventHandler(this.btnFUpdate_Click);
            // 
            // btnFAdd
            // 
            this.btnFAdd.Location = new System.Drawing.Point(11, 110);
            this.btnFAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFAdd.Name = "btnFAdd";
            this.btnFAdd.Size = new System.Drawing.Size(60, 23);
            this.btnFAdd.TabIndex = 8;
            this.btnFAdd.Text = "Thêm";
            this.btnFAdd.Click += new System.EventHandler(this.btnFAdd_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 421);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(735, 22);
            this.statusStrip1.TabIndex = 1;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(54, 17);
            this.toolStripStatusLabel1.Text = "Sẵn sàng";
            // 
            // frmStudentManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 443);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmStudentManagement";
            this.Text = "Quản lý Sinh viên & Khoa - Bài 1+2+3";
            this.Load += new System.EventHandler(this.frmStudentManagement_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabStudent.ResumeLayout(false);
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.groupBoxStudentInput.ResumeLayout(false);
            this.groupBoxStudentInput.PerformLayout();
            this.tabFaculty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaculty)).EndInit();
            this.groupBoxFaculty.ResumeLayout(false);
            this.groupBoxFaculty.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Khai báo controls
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStudent;
        private System.Windows.Forms.TabPage tabFaculty;
        private System.Windows.Forms.GroupBox groupBoxStudentInput;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblAverageScore;
        private System.Windows.Forms.TextBox txtAverageScore;
        private System.Windows.Forms.Label lblFaculty;
        private System.Windows.Forms.ComboBox cmbFaculty;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFacultyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAverageScore;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBoxFaculty;
        private System.Windows.Forms.Label lblFacultyID;
        private System.Windows.Forms.TextBox txtFacultyID;
        private System.Windows.Forms.Label lblFacultyName;
        private System.Windows.Forms.TextBox txtFacultyName;
        private System.Windows.Forms.Label lblTotalProfessor;
        private System.Windows.Forms.TextBox txtTotalProfessor;
        private System.Windows.Forms.Button btnFAdd;
        private System.Windows.Forms.Button btnFUpdate;
        private System.Windows.Forms.Button btnFDelete;
        private System.Windows.Forms.DataGridView dgvFaculty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalProfessor;
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

    }
}
#endregion