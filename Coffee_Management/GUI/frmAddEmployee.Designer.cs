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
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(328, 408);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(224, 27);
            txtPassword.TabIndex = 17;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(192, 464);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 56);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dtpHireDate
            // 
            dtpHireDate.Location = new Point(328, 264);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.Size = new Size(224, 27);
            dtpHireDate.TabIndex = 14;
            // 
            // cboRole
            // 
            cboRole.FormattingEnabled = true;
            cboRole.Items.AddRange(new object[] { "manager", "staff" });
            cboRole.Location = new Point(328, 360);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(151, 28);
            cboRole.TabIndex = 13;
            cboRole.Text = "Vai trò";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(328, 312);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Phone Number";
            txtPhone.Size = new Size(216, 27);
            txtPhone.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.ForeColor = SystemColors.HighlightText;
            txtEmail.Location = new Point(328, 168);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(240, 27);
            txtEmail.TabIndex = 11;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(328, 216);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "FullName";
            txtFullName.Size = new Size(248, 27);
            txtFullName.TabIndex = 10;
            // 
            // txtEmpID
            // 
            txtEmpID.Location = new Point(328, 120);
            txtEmpID.Name = "txtEmpID";
            txtEmpID.ReadOnly = true;
            txtEmpID.Size = new Size(128, 27);
            txtEmpID.TabIndex = 9;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(576, 464);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(128, 56);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += bttCancel_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.HighlightText;
            textBox1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = SystemColors.InactiveCaptionText;
            textBox1.Location = new Point(296, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(328, 43);
            textBox1.TabIndex = 19;
            textBox1.Text = "Tạo tài khoản";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // frmAddEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(969, 575);
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
    }
}