using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class OrderStaffDashboard
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

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            btnProfile = new Button();
            btnWorkTracking = new Button();
            btnLeave = new Button();
            btnLogout = new Button();
            btnChat = new Button();
            btnTables = new Button();
            btnPOS = new Button();
            btnOverview = new Button();
            pnlLogo = new Panel();
            lblLogo = new Label();
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
            pnlSidebar.Controls.Add(btnWorkTracking);
            pnlSidebar.Controls.Add(btnLeave);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnChat);
            pnlSidebar.Controls.Add(btnTables);
            pnlSidebar.Controls.Add(btnPOS);
            pnlSidebar.Controls.Add(btnOverview);
            pnlSidebar.Controls.Add(pnlLogo);
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
            btnProfile.Location = new Point(0, 370);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(220, 50);
            btnProfile.TabIndex = 6;
            btnProfile.Text = "  Hồ sơ";
            btnProfile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnWorkTracking
            // 
            btnWorkTracking.Dock = DockStyle.Top;
            btnWorkTracking.FlatAppearance.BorderSize = 0;
            btnWorkTracking.FlatStyle = FlatStyle.Flat;
            btnWorkTracking.Font = new Font("Segoe UI", 11F);
            btnWorkTracking.ForeColor = Color.White;
            btnWorkTracking.Location = new Point(0, 320);
            btnWorkTracking.Name = "btnWorkTracking";
            btnWorkTracking.Size = new Size(220, 50);
            btnWorkTracking.TabIndex = 9;
            btnWorkTracking.Text = "  Theo dõi ngày làm việc";
            btnWorkTracking.TextAlign = ContentAlignment.MiddleLeft;
            btnWorkTracking.Click += BtnWorkTracking_Click;
            // 
            // btnLeave
            // 
            btnLeave.Dock = DockStyle.Top;
            btnLeave.FlatAppearance.BorderSize = 0;
            btnLeave.FlatStyle = FlatStyle.Flat;
            btnLeave.Font = new Font("Segoe UI", 11F);
            btnLeave.ForeColor = Color.White;
            btnLeave.Location = new Point(0, 270);
            btnLeave.Name = "btnLeave";
            btnLeave.Size = new Size(220, 50);
            btnLeave.TabIndex = 8;
            btnLeave.Text = "  Xin nghỉ";
            btnLeave.TextAlign = ContentAlignment.MiddleLeft;
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
            btnLogout.Click += BtnLogout_Click_1;
            // 
            // btnChat
            // 
            btnChat.Dock = DockStyle.Top;
            btnChat.FlatAppearance.BorderSize = 0;
            btnChat.FlatStyle = FlatStyle.Flat;
            btnChat.Font = new Font("Segoe UI", 11F);
            btnChat.ForeColor = Color.White;
            btnChat.ImageAlign = ContentAlignment.MiddleLeft;
            btnChat.Location = new Point(0, 220);
            btnChat.Name = "btnChat";
            btnChat.Size = new Size(220, 50);
            btnChat.TabIndex = 1;
            btnChat.Text = "  Chat";
            btnChat.TextAlign = ContentAlignment.MiddleLeft;
            btnChat.Click += BtnChat_Click;
            // 
            // btnTables
            // 
            btnTables.Dock = DockStyle.Top;
            btnTables.FlatAppearance.BorderSize = 0;
            btnTables.FlatStyle = FlatStyle.Flat;
            btnTables.Font = new Font("Segoe UI", 11F);
            btnTables.ForeColor = Color.White;
            btnTables.Location = new Point(0, 170);
            btnTables.Name = "btnTables";
            btnTables.Size = new Size(220, 50);
            btnTables.TabIndex = 3;
            btnTables.Text = "  Sơ đồ bàn";
            btnTables.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnPOS
            // 
            btnPOS.Dock = DockStyle.Top;
            btnPOS.FlatAppearance.BorderSize = 0;
            btnPOS.FlatStyle = FlatStyle.Flat;
            btnPOS.Font = new Font("Segoe UI", 11F);
            btnPOS.ForeColor = Color.White;
            btnPOS.Location = new Point(0, 120);
            btnPOS.Name = "btnPOS";
            btnPOS.Size = new Size(220, 50);
            btnPOS.TabIndex = 4;
            btnPOS.Text = "  Lên đơn / POS";
            btnPOS.TextAlign = ContentAlignment.MiddleLeft;
            btnPOS.Click += BtnPOS_Click;
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
            btnOverview.TabIndex = 7;
            btnOverview.Text = "  Tổng quan";
            btnOverview.TextAlign = ContentAlignment.MiddleLeft;
            btnOverview.Click += BtnOverview_Click;
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
            lblLogo.Location = new Point(12, 18);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(184, 30);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "Nhân viên Order";
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
            lblWelcome.Location = new Point(142, 218);
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
            btnClose.Click += BtnClose_Click;
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
            // OrderStaffDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 600);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "OrderStaffDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Giao diện Nhân viên Order";
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
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Button btnTables;
        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.Button btnOverview;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Label lblWelcome;
        private Label lblTitle;
        private Button btnClose;
        private Panel pnlHeader;
        private Button btnProfile;
        private Button btnLeave;
        private Button btnWorkTracking;
    }
}