namespace QuanLyQuanCafe.GUI
{
    partial class frmDangNhap
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
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnDangNhap = new Button();
            lblQuenMatKhau = new LinkLabel();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.None;
            txtEmail.Font = new Font("Times New Roman", 13.8F);
            txtEmail.Location = new Point(696, 136);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(296, 34);
            txtEmail.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.Font = new Font("Times New Roman", 13.8F);
            txtPassword.Location = new Point(696, 184);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(296, 34);
            txtPassword.TabIndex = 1;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Anchor = AnchorStyles.None;
            btnDangNhap.BackColor = SystemColors.MenuHighlight;
            btnDangNhap.Font = new Font("Times New Roman", 13.8F);
            btnDangNhap.ForeColor = SystemColors.ControlText;
            btnDangNhap.Location = new Point(728, 240);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(240, 48);
            btnDangNhap.TabIndex = 2;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // lblQuenMatKhau
            // 
            lblQuenMatKhau.Anchor = AnchorStyles.None;
            lblQuenMatKhau.AutoSize = true;
            lblQuenMatKhau.Font = new Font("Times New Roman", 13.8F);
            lblQuenMatKhau.Location = new Point(776, 304);
            lblQuenMatKhau.Name = "lblQuenMatKhau";
            lblQuenMatKhau.Size = new Size(155, 26);
            lblQuenMatKhau.TabIndex = 5;
            lblQuenMatKhau.TabStop = true;
            lblQuenMatKhau.Text = "Quên mật khẩu";
            lblQuenMatKhau.LinkClicked += lblQuenMatKhau_LinkClicked;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.DangNhap;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1109, 537);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = SystemColors.HotTrack;
            button1.Font = new Font("Times New Roman", 13.8F);
            button1.Location = new Point(728, 344);
            button1.Name = "button1";
            button1.Size = new Size(240, 48);
            button1.TabIndex = 7;
            button1.Text = "Đăng ký";
            button1.UseVisualStyleBackColor = false;
            // 
            // frmDangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1109, 537);
            Controls.Add(button1);
            Controls.Add(lblQuenMatKhau);
            Controls.Add(btnDangNhap);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(pictureBox1);
            Name = "frmDangNhap";
            Text = "frmDangNhap";
            WindowState = FormWindowState.Maximized;
            Load += frmDangNhap_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnDangNhap;
        private LinkLabel lblQuenMatKhau;
        private PictureBox pictureBox1;
        private Button button1;
    }
}