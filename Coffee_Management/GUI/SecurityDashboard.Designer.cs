using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class SecurityDashboard
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
            pnlSidebar = new Panel();
            btnProfile = new Button();
            btnChat = new Button();
            btnAttendance = new Button();
            btnLeaveRequest = new Button();
            btnOverview = new Button();
            pnlLogo = new Panel();
            lblLogo = new Label();
            btnLogout = new Button();
            pnlMainContent = new Panel();
            lblWelcome = new Label();
            lblTitle = new Label();
            btnClose = new Button();
            pnlHeader = new Panel();
            pnlSidebar.SuspendLayout();
            pnlLogo.SuspendLayout();
            pnlMainContent.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(30, 30, 30);
            pnlSidebar.Controls.Add(btnProfile);
            pnlSidebar.Controls.Add(btnChat);
            pnlSidebar.Controls.Add(btnAttendance);
            pnlSidebar.Controls.Add(btnLeaveRequest);
            pnlSidebar.Controls.Add(btnOverview);
            pnlSidebar.Controls.Add(pnlLogo);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(220, 600);
            pnlSidebar.TabIndex = 0;
            // 
            // btnProfile
            // 
            btnProfile.Dock = DockStyle.Top;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI", 11F);
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(0, 270);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(220, 50);
            btnProfile.TabIndex = 4;
            btnProfile.Text = "   Profile";
            btnProfile.TextAlign = ContentAlignment.MiddleLeft;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnChat
            // 
            btnChat.Dock = DockStyle.Top;
            btnChat.FlatAppearance.BorderSize = 0;
            btnChat.FlatStyle = FlatStyle.Flat;
            btnChat.Font = new Font("Segoe UI", 11F);
            btnChat.ForeColor = Color.White;
            btnChat.Location = new Point(0, 220);
            btnChat.Name = "btnChat";
            btnChat.Size = new Size(220, 50);
            btnChat.TabIndex = 2;
            btnChat.Text = "   Chat";
            btnChat.TextAlign = ContentAlignment.MiddleLeft;
            btnChat.Click += btnChat_Click;
            // 
            // btnAttendance
            // 
            btnAttendance.Dock = DockStyle.Top;
            btnAttendance.FlatAppearance.BorderSize = 0;
            btnAttendance.FlatStyle = FlatStyle.Flat;
            btnAttendance.Font = new Font("Segoe UI", 11F);
            btnAttendance.ForeColor = Color.White;
            btnAttendance.Location = new Point(0, 170);
            btnAttendance.Name = "btnAttendance";
            btnAttendance.Size = new Size(220, 50);
            btnAttendance.TabIndex = 1;
            btnAttendance.Text = "   Chấm công";
            btnAttendance.TextAlign = ContentAlignment.MiddleLeft;
            btnAttendance.Click += btnAttendance_Click;
            // 
            // btnLeaveRequest
            // 
            btnLeaveRequest.Dock = DockStyle.Top;
            btnLeaveRequest.FlatAppearance.BorderSize = 0;
            btnLeaveRequest.FlatStyle = FlatStyle.Flat;
            btnLeaveRequest.Font = new Font("Segoe UI", 11F);
            btnLeaveRequest.ForeColor = Color.White;
            btnLeaveRequest.Location = new Point(0, 120);
            btnLeaveRequest.Name = "btnLeaveRequest";
            btnLeaveRequest.Size = new Size(220, 50);
            btnLeaveRequest.TabIndex = 3;
            btnLeaveRequest.Text = "   Xin nghỉ";
            btnLeaveRequest.TextAlign = ContentAlignment.MiddleLeft;
            btnLeaveRequest.Click += btnLeaveRequest_Click;
            // 
            // btnOverview
            // 
            btnOverview.Dock = DockStyle.Top;
            btnOverview.FlatAppearance.BorderSize = 0;
            btnOverview.FlatStyle = FlatStyle.Flat;
            btnOverview.Font = new Font("Segoe UI", 11F);
            btnOverview.ForeColor = Color.White;
            btnOverview.Location = new Point(0, 70);
            btnOverview.Name = "btnOverview";
            btnOverview.Size = new Size(220, 50);
            btnOverview.TabIndex = 6;
            btnOverview.Text = "  Tổng quan";
            btnOverview.TextAlign = ContentAlignment.MiddleLeft;
            btnOverview.Click += btnOverview_Click;
            // 
            // pnlLogo
            // 
            pnlLogo.BackColor = Color.FromArgb(20, 20, 20);
            pnlLogo.Controls.Add(lblLogo);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(220, 70);
            pnlLogo.TabIndex = 5;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblLogo.ForeColor = Color.MediumSeaGreen;
            lblLogo.Location = new Point(35, 20);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(151, 30);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "Security Staff";
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F);
            btnLogout.ForeColor = Color.Gray;
            btnLogout.Location = new Point(0, 550);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(220, 50);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Đăng xuất";
            btnLogout.Click += btnLogout_Click;
            // 
            // pnlMainContent
            // 
            pnlMainContent.BackColor = Color.FromArgb(45, 45, 48);
            pnlMainContent.Controls.Add(lblWelcome);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(220, 70);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(804, 530);
            pnlMainContent.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F);
            lblWelcome.ForeColor = Color.Gray;
            lblWelcome.Location = new Point(154, 205);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(522, 32);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Vui lòng chọn một mục từ thanh menu bên trái";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(25, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(178, 25);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "BẢNG ĐIỀU KHIỂN";
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(754, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(50, 70);
            btnClose.TabIndex = 0;
            btnClose.Text = "X";
            btnClose.Click += btnClose_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(220, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(804, 70);
            pnlHeader.TabIndex = 1;
            // 
            // SecurityDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 600);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SecurityDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Security Dashboard";
            pnlSidebar.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            pnlMainContent.ResumeLayout(false);
            pnlMainContent.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Button btnLeaveRequest;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnOverview;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Label lblWelcome;
        private Label lblTitle;
        private Button btnClose;
        private Panel pnlHeader;
    }
}