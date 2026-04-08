namespace GUI
{
    partial class frmAddEmployee
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
            txtPassword = new TextBox();
            btnSave = new Button();
            dtpHireDate = new DateTimePicker();
            cboRole = new ComboBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtFullName = new TextBox();
            txtEmpID = new TextBox();
            btnCancel = new Button();
            textBox1 = new TextBox();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(369, 469);
            txtPassword.MinimumSize = new Size(280, 0);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(280, 30);
            txtPassword.TabIndex = 17;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(52, 152, 219);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(296, 544);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 40);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // dtpHireDate
            // 
            dtpHireDate.Location = new Point(369, 304);
            dtpHireDate.MinimumSize = new Size(280, 0);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.Size = new Size(280, 30);
            dtpHireDate.TabIndex = 14;
            // 
            // cboRole
            // 
            cboRole.FormattingEnabled = true;
            cboRole.Items.AddRange(new object[] { "manager", "staff" });
            cboRole.Location = new Point(369, 414);
            cboRole.MinimumSize = new Size(280, 0);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(280, 31);
            cboRole.TabIndex = 13;
            cboRole.Text = "Vai trò";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(369, 359);
            txtPhone.MinimumSize = new Size(280, 0);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Phone Number";
            txtPhone.Size = new Size(280, 30);
            txtPhone.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.ForeColor = Color.FromArgb(70, 70, 70);
            txtEmail.Location = new Point(369, 193);
            txtEmail.MinimumSize = new Size(280, 0);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(280, 30);
            txtEmail.TabIndex = 11;
            // 
            // txtFullName
            // 
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.ForeColor = Color.FromArgb(70, 70, 70);
            txtFullName.Location = new Point(369, 248);
            txtFullName.MinimumSize = new Size(280, 0);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "FullName";
            txtFullName.Size = new Size(280, 30);
            txtFullName.TabIndex = 10;
            // 
            // txtEmpID
            // 
            txtEmpID.BorderStyle = BorderStyle.FixedSingle;
            txtEmpID.Location = new Point(369, 138);
            txtEmpID.MinimumSize = new Size(280, 0);
            txtEmpID.Name = "txtEmpID";
            txtEmpID.ReadOnly = true;
            txtEmpID.Size = new Size(280, 30);
            txtEmpID.TabIndex = 9;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(189, 195, 199);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(624, 544);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += bttCancel_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.HighlightText;
            textBox1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.FromArgb(44, 62, 80);
            textBox1.Location = new Point(333, 46);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(368, 47);
            textBox1.TabIndex = 19;
            textBox1.Text = "Tạo tài khoản";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Location = new Point(296, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(448, 500);
            panel1.TabIndex = 20;
            // 
            // frmAddEmployee
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            BackgroundImage = Properties.Resources.bg_login;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1090, 661);
            Controls.Add(textBox1);
            Controls.Add(btnCancel);
            Controls.Add(txtPassword);
            Controls.Add(btnSave);
            Controls.Add(dtpHireDate);
            Controls.Add(cboRole);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtFullName);
            Controls.Add(txtEmpID);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "frmAddEmployee";
            Text = "frmAddEmployee";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPassword;
        private Button btnSave;
        private DateTimePicker dtpHireDate;
        private ComboBox cboRole;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtFullName;
        private TextBox txtEmpID;
        private Button btnCancel;
        private TextBox textBox1;
        private Panel panel1;
    }
}