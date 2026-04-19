namespace GUI
{
    partial class ManagerDashboard
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
            btnSettings = new Button();
            btnWorkTracking = new Button();
            btnLeave = new Button();
            btnStaff = new Button();
            btnOrders = new Button();
            btnProducts = new Button();
            btnHome = new Button();
            pnlLogo = new Panel();
            lblLogo = new Label();
            pnlMainContent = new Panel();
            pnlHeader = new Panel();
            btnClose = new Button();
            lblTitle = new Label();
            lblWelcome = new Label();
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
            pnlSidebar.Controls.Add(btnSettings);
            pnlSidebar.Controls.Add(btnWorkTracking);
            pnlSidebar.Controls.Add(btnLeave);
            pnlSidebar.Controls.Add(btnStaff);
            pnlSidebar.Controls.Add(btnOrders);
            pnlSidebar.Controls.Add(btnProducts);
            pnlSidebar.Controls.Add(btnHome);
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
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += BtnLogout_Click;
            // 
            // btnSettings
            // 
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.Dock = DockStyle.Top;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 11F);
            btnSettings.ForeColor = Color.White;
            btnSettings.Location = new Point(0, 370);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(220, 50);
            btnSettings.TabIndex = 5;
            btnSettings.Text = "  Cài đặt và Chat";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += BtnSettings_Click;
            // 
            // btnWorkTracking
            // 
            btnWorkTracking.Cursor = Cursors.Hand;
            btnWorkTracking.Dock = DockStyle.Top;
            btnWorkTracking.FlatAppearance.BorderSize = 0;
            btnWorkTracking.FlatStyle = FlatStyle.Flat;
            btnWorkTracking.Font = new Font("Segoe UI", 11F);
            btnWorkTracking.ForeColor = Color.White;
            btnWorkTracking.Location = new Point(0, 320);
            btnWorkTracking.Name = "btnWorkTracking";
            btnWorkTracking.Size = new Size(220, 50);
            btnWorkTracking.TabIndex = 8;
            btnWorkTracking.Text = "  Theo dõi ngày làm việc";
            btnWorkTracking.TextAlign = ContentAlignment.MiddleLeft;
            btnWorkTracking.UseVisualStyleBackColor = true;
            btnWorkTracking.Click += BtnWorkTracking_Click;
            // 
            // btnLeave
            // 
            btnLeave.Cursor = Cursors.Hand;
            btnLeave.Dock = DockStyle.Top;
            btnLeave.FlatAppearance.BorderSize = 0;
            btnLeave.FlatStyle = FlatStyle.Flat;
            btnLeave.Font = new Font("Segoe UI", 11F);
            btnLeave.ForeColor = Color.White;
            btnLeave.Location = new Point(0, 270);
            btnLeave.Name = "btnLeave";
            btnLeave.Size = new Size(220, 50);
            btnLeave.TabIndex = 7;
            btnLeave.Text = "  Xin nghỉ";
            btnLeave.TextAlign = ContentAlignment.MiddleLeft;
            btnLeave.UseVisualStyleBackColor = true;
            btnLeave.Click += BtnLeave_Click;
            // 
            // btnStaff
            // 
            btnStaff.Cursor = Cursors.Hand;
            btnStaff.Dock = DockStyle.Top;
            btnStaff.FlatAppearance.BorderSize = 0;
            btnStaff.FlatStyle = FlatStyle.Flat;
            btnStaff.Font = new Font("Segoe UI", 11F);
            btnStaff.ForeColor = Color.White;
            btnStaff.Location = new Point(0, 220);
            btnStaff.Name = "btnStaff";
            btnStaff.Size = new Size(220, 50);
            btnStaff.TabIndex = 4;
            btnStaff.Text = "  Quản lý Nhân viên";
            btnStaff.TextAlign = ContentAlignment.MiddleLeft;
            btnStaff.UseVisualStyleBackColor = true;
            btnStaff.Click += BtnStaff_Click;
            // 
            // btnOrders
            // 
            btnOrders.Cursor = Cursors.Hand;
            btnOrders.Dock = DockStyle.Top;
            btnOrders.FlatAppearance.BorderSize = 0;
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.Font = new Font("Segoe UI", 11F);
            btnOrders.ForeColor = Color.White;
            btnOrders.Location = new Point(0, 170);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(220, 50);
            btnOrders.TabIndex = 3;
            btnOrders.Text = "  Đơn hàng và Hóa đơn";
            btnOrders.TextAlign = ContentAlignment.MiddleLeft;
            btnOrders.UseVisualStyleBackColor = true;
            btnOrders.Click += BtnOrders_Click;
            // 
            // btnProducts
            // 
            btnProducts.Cursor = Cursors.Hand;
            btnProducts.Dock = DockStyle.Top;
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Segoe UI", 11F);
            btnProducts.ForeColor = Color.White;
            btnProducts.Location = new Point(0, 120);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(220, 50);
            btnProducts.TabIndex = 2;
            btnProducts.Text = "  Sản phẩm và Thực đơn";
            btnProducts.TextAlign = ContentAlignment.MiddleLeft;
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += BtnProducts_Click;
            // 
            // btnHome
            // 
            btnHome.Cursor = Cursors.Hand;
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 11.25F);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(0, 70);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(220, 50);
            btnHome.TabIndex = 1;
            btnHome.Text = "  Tổng quan";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += BtnHome_Click;
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
            lblLogo.ForeColor = Color.Firebrick;
            lblLogo.Location = new Point(47, 19);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(92, 30);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "Quản lý";
            lblLogo.Click += LblLogo_Click;
            // 
            // pnlMainContent
            // 
            pnlMainContent.BackColor = Color.FromArgb(45, 45, 48);
            pnlMainContent.Controls.Add(pnlHeader);
            pnlMainContent.Controls.Add(lblWelcome);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(220, 0);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(804, 600);
            pnlMainContent.TabIndex = 2;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(804, 70);
            pnlHeader.TabIndex = 2;
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
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F);
            lblWelcome.ForeColor = Color.Gray;
            lblWelcome.Location = new Point(153, 288);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(522, 32);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Vui lòng chọn một mục từ thanh menu bên trái";
            // 
            // ManagerDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 600);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlSidebar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ManagerDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Giao diện Quản lý";
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
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnWorkTracking;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Label lblWelcome;
        private Panel pnlHeader;
        private Button btnClose;
        private Label lblTitle;
        private Button btnLeave;
    }
}