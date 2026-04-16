using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class OrderStaffDashboard
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
            pnlSidebar = new Panel();
            btnProfile = new Button();
            btnLogout = new Button();
            btnChat = new Button();
            btnTables = new Button();
            btnPOS = new Button();
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
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnChat);
            pnlSidebar.Controls.Add(btnTables);
            pnlSidebar.Controls.Add(btnPOS);
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
            btnProfile.Location = new Point(0, 220);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(220, 50);
            btnProfile.TabIndex = 6;
            btnProfile.Text = "  Profile ";
            btnProfile.TextAlign = ContentAlignment.MiddleLeft;
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
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click_1;
            // 
            // btnChat
            // 
            btnChat.Dock = DockStyle.Top;
            btnChat.FlatAppearance.BorderSize = 0;
            btnChat.FlatStyle = FlatStyle.Flat;
            btnChat.Font = new Font("Segoe UI", 11F);
            btnChat.ForeColor = Color.White;
            btnChat.ImageAlign = ContentAlignment.MiddleLeft;
            btnChat.Location = new Point(0, 170);
            btnChat.Name = "btnChat";
            btnChat.Size = new Size(220, 50);
            btnChat.TabIndex = 1;
            btnChat.Text = "  Chat";
            btnChat.TextAlign = ContentAlignment.MiddleLeft;
            btnChat.Click += btnChat_Click;
            // 
            // btnTables
            // 
            btnTables.Dock = DockStyle.Top;
            btnTables.FlatAppearance.BorderSize = 0;
            btnTables.FlatStyle = FlatStyle.Flat;
            btnTables.Font = new Font("Segoe UI", 11F);
            btnTables.ForeColor = Color.White;
            btnTables.Location = new Point(0, 120);
            btnTables.Name = "btnTables";
            btnTables.Size = new Size(220, 50);
            btnTables.TabIndex = 3;
            btnTables.Text = "  Tables Map";
            btnTables.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnPOS
            // 
            btnPOS.Dock = DockStyle.Top;
            btnPOS.FlatAppearance.BorderSize = 0;
            btnPOS.FlatStyle = FlatStyle.Flat;
            btnPOS.Font = new Font("Segoe UI", 11F);
            btnPOS.ForeColor = Color.White;
            btnPOS.Location = new Point(0, 70);
            btnPOS.Name = "btnPOS";
            btnPOS.Size = new Size(220, 50);
            btnPOS.TabIndex = 4;
            btnPOS.Text = "  POS / Order";
            btnPOS.TextAlign = ContentAlignment.MiddleLeft;
            btnPOS.Click += btnPOS_Click;
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
            lblLogo.Location = new Point(43, 19);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(128, 30);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "Order Staff";
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
            lblWelcome.Location = new Point(260, 220);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(280, 32);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Select a tab from the left";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(25, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(130, 25);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "DASHBOARD";
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
            this.Text = "Order Staff Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Label lblWelcome;
        private Label lblTitle;
        private Button btnClose;
        private Panel pnlHeader;
        private Button btnProfile;
    }
}