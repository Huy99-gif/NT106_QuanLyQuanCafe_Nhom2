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
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(325, 327);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(224, 27);
            txtPassword.TabIndex = 17;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(189, 383);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dtpHireDate
            // 
            dtpHireDate.Location = new Point(325, 183);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.Size = new Size(250, 27);
            dtpHireDate.TabIndex = 14;
            // 
            // cboRole
            // 
            cboRole.FormattingEnabled = true;
            cboRole.Items.AddRange(new object[] { "manager", "staff" });
            cboRole.Location = new Point(325, 279);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(151, 28);
            cboRole.TabIndex = 13;
            cboRole.Text = "Vai trò";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(325, 231);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Phone Number";
            txtPhone.Size = new Size(125, 27);
            txtPhone.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(325, 87);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(200, 27);
            txtEmail.TabIndex = 11;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(325, 135);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "FullName";
            txtFullName.Size = new Size(125, 27);
            txtFullName.TabIndex = 10;
            // 
            // txtEmpID
            // 
            txtEmpID.Location = new Point(325, 39);
            txtEmpID.Name = "txtEmpID";
            txtEmpID.ReadOnly = true;
            txtEmpID.Size = new Size(128, 27);
            txtEmpID.TabIndex = 9;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(584, 376);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += bttCancel_Click;
            // 
            // frmAddEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            ClientSize = new Size(800, 450);
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
    }
}