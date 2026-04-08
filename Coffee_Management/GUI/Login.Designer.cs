namespace GUI
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pnlRight = new Panel();
            chkRememberMe = new CheckBox();
            btnClose = new Button();
            lblForgotPass = new LinkLabel();
            btnSignIn = new Button();
            pnlPassBg = new Panel();
            btnShowPass = new Button();
            txtPassword = new TextBox();
            pnlEmailBg = new Panel();
            txtEmail = new TextBox();
            lblTitle = new Label();
            pictureBox1 = new PictureBox();
            picLeft = new PictureBox();
            pnlRight.SuspendLayout();
            pnlPassBg.SuspendLayout();
            pnlEmailBg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLeft).BeginInit();
            SuspendLayout();
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(30, 30, 30);
            pnlRight.Controls.Add(chkRememberMe);
            pnlRight.Controls.Add(btnClose);
            pnlRight.Controls.Add(lblForgotPass);
            pnlRight.Controls.Add(btnSignIn);
            pnlRight.Controls.Add(pnlPassBg);
            pnlRight.Controls.Add(pnlEmailBg);
            pnlRight.Controls.Add(lblTitle);
            pnlRight.Cursor = Cursors.Hand;
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.ForeColor = Color.White;
            pnlRight.Location = new Point(350, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(730, 503);
            pnlRight.TabIndex = 1;
            // 
            // chkRememberMe
            // 
            chkRememberMe.AutoSize = true;
            chkRememberMe.Location = new Point(64, 320);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.Size = new Size(130, 24);
            chkRememberMe.TabIndex = 6;
            chkRememberMe.Text = "Lưu đăng nhập";
            chkRememberMe.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(656, 0);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(74, 503);
            btnClose.TabIndex = 5;
            btnClose.Text = "X";
            btnClose.Click += btnClose_Click;
            // 
            // lblForgotPass
            // 
            lblForgotPass.AutoSize = true;
            lblForgotPass.LinkColor = Color.White;
            lblForgotPass.Location = new Point(288, 320);
            lblForgotPass.Name = "lblForgotPass";
            lblForgotPass.Size = new Size(125, 20);
            lblForgotPass.TabIndex = 4;
            lblForgotPass.TabStop = true;
            lblForgotPass.Text = "Forgot Password?";
            lblForgotPass.LinkClicked += linkLabel1_LinkClicked;
            // 
            // btnSignIn
            // 
            btnSignIn.BackColor = Color.White;
            btnSignIn.Cursor = Cursors.Hand;
            btnSignIn.FlatAppearance.BorderSize = 0;
            btnSignIn.FlatStyle = FlatStyle.Flat;
            btnSignIn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSignIn.ForeColor = Color.Black;
            btnSignIn.Location = new Point(166, 375);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(150, 45);
            btnSignIn.TabIndex = 3;
            btnSignIn.Text = "Sign In";
            btnSignIn.UseVisualStyleBackColor = false;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // pnlPassBg
            // 
            pnlPassBg.BackColor = Color.FromArgb(45, 45, 48);
            pnlPassBg.Controls.Add(btnShowPass);
            pnlPassBg.Controls.Add(txtPassword);
            pnlPassBg.Location = new Point(54, 251);
            pnlPassBg.Name = "pnlPassBg";
            pnlPassBg.Size = new Size(379, 45);
            pnlPassBg.TabIndex = 2;
            // 
            // btnShowPass
            // 
            btnShowPass.BackColor = Color.Transparent;
            btnShowPass.Cursor = Cursors.Hand;
            btnShowPass.FlatAppearance.BorderSize = 0;
            btnShowPass.FlatStyle = FlatStyle.Flat;
            btnShowPass.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnShowPass.ForeColor = Color.Black;
            btnShowPass.Location = new Point(309, 3);
            btnShowPass.Name = "btnShowPass";
            btnShowPass.Size = new Size(67, 36);
            btnShowPass.TabIndex = 5;
            btnShowPass.Text = "👁️";
            btnShowPass.UseVisualStyleBackColor = false;
            btnShowPass.MouseDown += btnShowPass_MouseDown;
            btnShowPass.MouseUp += btnShowPass_MouseUp;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(45, 45, 48);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(15, 9);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "password123";
            txtPassword.Size = new Size(350, 27);
            txtPassword.TabIndex = 0;
            txtPassword.Enter += TxtPassword_Enter;
            txtPassword.Validating += txtPassword_Validating;
            // 
            // pnlEmailBg
            // 
            pnlEmailBg.BackColor = Color.FromArgb(45, 45, 48);
            pnlEmailBg.Controls.Add(txtEmail);
            pnlEmailBg.Location = new Point(54, 180);
            pnlEmailBg.Name = "pnlEmailBg";
            pnlEmailBg.Size = new Size(379, 45);
            pnlEmailBg.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(45, 45, 48);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.ForeColor = Color.White;
            txtEmail.Location = new Point(15, 9);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "jubaer@gmail.com";
            txtEmail.Size = new Size(350, 27);
            txtEmail.TabIndex = 0;
            txtEmail.TextChanged += txtEmail_TextChanged;
            txtEmail.Validating += txtEmail_Validating;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(50, 69);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(381, 74);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Welcome Back,\r\nPlease login to your account";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.BurlyWood;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(350, 500);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Paint += PictureBox1_Paint;
            // 
            // picLeft
            // 
            picLeft.BackColor = Color.BurlyWood;
            picLeft.Dock = DockStyle.Left;
            picLeft.Location = new Point(0, 0);
            picLeft.Name = "picLeft";
            picLeft.Size = new Size(350, 503);
            picLeft.SizeMode = PictureBoxSizeMode.StretchImage;
            picLeft.TabIndex = 0;
            picLeft.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 503);
            Controls.Add(pictureBox1);
            Controls.Add(pnlRight);
            Controls.Add(picLeft);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login - QLCafe";
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlPassBg.ResumeLayout(false);
            pnlPassBg.PerformLayout();
            pnlEmailBg.ResumeLayout(false);
            pnlEmailBg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLeft).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlEmailBg;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Panel pnlPassBg;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSignIn;
        private PictureBox pictureBox1;
        private LinkLabel lblForgotPass;
        private Button btnShowPass;
        private Button btnClose;
        private PictureBox picLeft;
        private CheckBox chkRememberMe;
    }
}