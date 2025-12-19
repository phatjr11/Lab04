namespace Lab04_QLSV
{
    partial class frmAddStudent
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblID = new MetroFramework.Controls.MetroLabel();
            this.txtStudentID = new MetroFramework.Controls.MetroTextBox();
            this.lblName = new MetroFramework.Controls.MetroLabel();
            this.txtFullName = new MetroFramework.Controls.MetroTextBox();
            this.lblFaculty = new MetroFramework.Controls.MetroLabel();
            this.cboFaculty = new MetroFramework.Controls.MetroComboBox();
            this.lblScore = new MetroFramework.Controls.MetroLabel();
            this.txtAvgScore = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.lblGender = new MetroFramework.Controls.MetroLabel();
            this.rbMale = new MetroFramework.Controls.MetroRadioButton();
            this.rbFemale = new MetroFramework.Controls.MetroRadioButton();
            this.lblBirthDate = new MetroFramework.Controls.MetroLabel();
            this.dtpBirthDate = new MetroFramework.Controls.MetroDateTime();
            this.lblAddress = new MetroFramework.Controls.MetroLabel();
            this.txtAddress = new MetroFramework.Controls.MetroTextBox();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.btnBrowse = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(23, 75);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(94, 19);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "Mã Sinh Viên:";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(140, 75);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(200, 23);
            this.txtStudentID.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(23, 115);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(56, 19);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Họ Tên:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(140, 115);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(200, 23);
            this.txtFullName.TabIndex = 3;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(23, 155);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(63, 19);
            this.lblGender.TabIndex = 4;
            this.lblGender.Text = "Giới tính:";
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Location = new System.Drawing.Point(140, 159);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(51, 15);
            this.rbMale.TabIndex = 5;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Nam";
            this.rbMale.UseSelectable = true;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(220, 159);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(42, 15);
            this.rbFemale.TabIndex = 6;
            this.rbFemale.Text = "Nữ";
            this.rbFemale.UseSelectable = true;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(23, 190);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(71, 19);
            this.lblBirthDate.TabIndex = 7;
            this.lblBirthDate.Text = "Ngày sinh:";
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(140, 190);
            this.dtpBirthDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(200, 29);
            this.dtpBirthDate.TabIndex = 8;
            // 
            // lblFaculty
            // 
            this.lblFaculty.AutoSize = true;
            this.lblFaculty.Location = new System.Drawing.Point(23, 235);
            this.lblFaculty.Name = "lblFaculty";
            this.lblFaculty.Size = new System.Drawing.Size(43, 19);
            this.lblFaculty.TabIndex = 9;
            this.lblFaculty.Text = "Khoa:";
            // 
            // cboFaculty
            // 
            this.cboFaculty.FormattingEnabled = true;
            this.cboFaculty.ItemHeight = 23;
            this.cboFaculty.Location = new System.Drawing.Point(140, 235);
            this.cboFaculty.Name = "cboFaculty";
            this.cboFaculty.Size = new System.Drawing.Size(200, 29);
            this.cboFaculty.TabIndex = 10;
            this.cboFaculty.UseSelectable = true;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(23, 280);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(61, 19);
            this.lblScore.TabIndex = 11;
            this.lblScore.Text = "Điểm TB:";
            // 
            // txtAvgScore
            // 
            this.txtAvgScore.Location = new System.Drawing.Point(140, 280);
            this.txtAvgScore.Name = "txtAvgScore";
            this.txtAvgScore.Size = new System.Drawing.Size(200, 23);
            this.txtAvgScore.TabIndex = 12;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(23, 320);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(51, 19);
            this.lblAddress.TabIndex = 13;
            this.lblAddress.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(140, 320);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 23);
            this.txtAddress.TabIndex = 14;
            // 
            // picAvatar
            // 
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(380, 75);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(120, 150);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatar.TabIndex = 15;
            this.picAvatar.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(380, 240);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(120, 23);
            this.btnBrowse.TabIndex = 16;
            this.btnBrowse.Text = "Chọn ảnh...";
            this.btnBrowse.UseSelectable = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(140, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(265, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 440);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.rbFemale);
            this.Controls.Add(this.rbMale);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAvgScore);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.cboFaculty);
            this.Controls.Add(this.lblFaculty);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.lblID);
            this.Name = "frmAddStudent";
            this.Text = "Thêm Sinh Viên";
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblID;
        private MetroFramework.Controls.MetroTextBox txtStudentID;
        private MetroFramework.Controls.MetroLabel lblName;
        private MetroFramework.Controls.MetroTextBox txtFullName;
        private MetroFramework.Controls.MetroLabel lblFaculty;
        private MetroFramework.Controls.MetroComboBox cboFaculty;
        private MetroFramework.Controls.MetroLabel lblScore;
        private MetroFramework.Controls.MetroTextBox txtAvgScore;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroLabel lblGender;
        private MetroFramework.Controls.MetroRadioButton rbMale;
        private MetroFramework.Controls.MetroRadioButton rbFemale;
        private MetroFramework.Controls.MetroLabel lblBirthDate;
        private MetroFramework.Controls.MetroDateTime dtpBirthDate;
        private MetroFramework.Controls.MetroLabel lblAddress;
        private MetroFramework.Controls.MetroTextBox txtAddress;
        private System.Windows.Forms.PictureBox picAvatar;
        private MetroFramework.Controls.MetroButton btnBrowse;
    }
}