using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class AdminDashboard
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
            btnLogout = new Button();
            btnChatAndSettings = new Button();
            btnViewAttendance = new Button();
            btnOverview = new Button();
            pnlLogo = new Panel();
            lblLogo = new Label();
            pnlMainContent = new Panel();
            lblWelcome = new Label();
            pnlHeader = new Panel();
            btnClose = new Button();
            lblTitle = new Label();
            pnlSidebar.SuspendLayout();
            pnlLogo.SuspendLayout();
            pnlMainContent.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(30, 30, 30);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnChatAndSettings);
            pnlSidebar.Controls.Add(btnViewAttendance);
            pnlSidebar.Controls.Add(btnOverview);
            pnlSidebar.Controls.Add(pnlLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(220, 600);
            pnlSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F);
            btnLogout.ForeColor = Color.Gray;
            btnLogout.Location = new Point(0, 550);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(220, 50);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnChatAndSettings
            // 
            btnChatAndSettings.Cursor = Cursors.Hand;
            btnChatAndSettings.Dock = DockStyle.Top;
            btnChatAndSettings.FlatAppearance.BorderSize = 0;
            btnChatAndSettings.FlatStyle = FlatStyle.Flat;
            btnChatAndSettings.Font = new Font("Segoe UI", 11F);
            btnChatAndSettings.ForeColor = Color.White;
            btnChatAndSettings.Location = new Point(0, 170);
            btnChatAndSettings.Name = "btnChatAndSettings";
            btnChatAndSettings.Size = new Size(220, 50);
            btnChatAndSettings.TabIndex = 3;
            btnChatAndSettings.Text = "  Chat và Cài đặt";
            btnChatAndSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnChatAndSettings.UseVisualStyleBackColor = true;
            btnChatAndSettings.Click += BtnChatAndSettings_Click;
            // 
            // btnViewAttendance
            // 
            btnViewAttendance.Cursor = Cursors.Hand;
            btnViewAttendance.Dock = DockStyle.Top;
            btnViewAttendance.FlatAppearance.BorderSize = 0;
            btnViewAttendance.FlatStyle = FlatStyle.Flat;
            btnViewAttendance.Font = new Font("Segoe UI", 11F);
            btnViewAttendance.ForeColor = Color.White;
            btnViewAttendance.Location = new Point(0, 120);
            btnViewAttendance.Name = "btnViewAttendance";
            btnViewAttendance.Size = new Size(220, 50);
            btnViewAttendance.TabIndex = 2;
            btnViewAttendance.Text = "  Quản lý Chấm công";
            btnViewAttendance.TextAlign = ContentAlignment.MiddleLeft;
            btnViewAttendance.UseVisualStyleBackColor = true;
            btnViewAttendance.Click += BtnViewAttendance_Click;
            // 
            // btnOverview
            // 
            btnOverview.Cursor = Cursors.Hand;
            btnOverview.Dock = DockStyle.Top;
            btnOverview.FlatAppearance.BorderSize = 0;
            btnOverview.FlatStyle = FlatStyle.Flat;
            btnOverview.Font = new Font("Segoe UI", 11.25F);
            btnOverview.ForeColor = Color.White;
            btnOverview.Location = new Point(0, 70);
            btnOverview.Name = "btnOverview";
            btnOverview.Size = new Size(220, 50);
            btnOverview.TabIndex = 1;
            btnOverview.Text = "  Tổng quan";
            btnOverview.TextAlign = ContentAlignment.MiddleLeft;
            btnOverview.UseVisualStyleBackColor = true;
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
            pnlLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblLogo.ForeColor = Color.Goldenrod;
            lblLogo.Location = new Point(35, 19);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(147, 30);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "Quản trị viên";
            // 
            // pnlMainContent
            // 
            pnlMainContent.BackColor = Color.FromArgb(45, 45, 48);
            pnlMainContent.Controls.Add(lblWelcome);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(220, 70);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(804, 530);
            pnlMainContent.TabIndex = 2;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F);
            lblWelcome.ForeColor = Color.Gray;
            lblWelcome.Location = new Point(153, 230);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(522, 32);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Vui lòng chọn một mục từ thanh menu bên trái";
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
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 600);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Giao diện Quản trị viên";
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
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnOverview;
        private System.Windows.Forms.Button btnViewAttendance;
        private System.Windows.Forms.Button btnChatAndSettings;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Label lblWelcome;
        private Panel pnlHeader;
        private Button btnClose;
        private Label lblTitle;
    }
}