using DTO;
using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GUI
{
    public partial class OrderStaffDashboard : Form
    {
        private readonly BaseDashboard _dashboardManager;
        public OrderStaffDashboard()
        {
            InitializeComponent();
            _dashboardManager = new BaseDashboard(this);
            this.Load += (s, e) => btnPOS.PerformClick();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Clear();
            pnlMainContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void BtnPOS_Click(object sender, EventArgs e)
        {
            ucPOS_OrStaff uc = new();
            AddUserControl(uc);
            lblTitle.Text = "Lên đơn / POS";
        }

        private void BtnChat_Click(object sender, EventArgs e)
        {
            // Load UserControl Chat đã tích hợp SignalR và Firebase
            ucInternalChat uc = new();
            AddUserControl(uc);
            lblTitle.Text = "Chat nội bộ";
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            Form? Login = Application.OpenForms["Login"];
            if (Login != null)
            {
                Login.Show();
            }
            else
            {
                Login login = new();
                login.Show();
            }
            GlobalSession.Logout();
            //DUYỆT NGƯỢC TỪ CUỐI LÊN ĐỂ TẮT TẤT CẢ CÁC FORM KHÁC
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                Form? f = Application.OpenForms[i];

                // Nếu không phải là form Login thì đóng nó lại
                // (Dùng f.Name để kiểm tra)
                if (f?.Name != "Login")
                {
                    f?.Close(); // Đóng form
                }
            }
        }

        private void BtnLogout_Click_1(object sender, EventArgs e)
        {
            // Giữ nguyên logic logout giống hàm trên
            Form? Login = Application.OpenForms["Login"];
            if (Login != null)
            {
                Login.Show();
            }
            else
            {
                Login = new();
                Login.Show();
            }
            GlobalSession.Logout();
            //DUYỆT NGƯỢC TỪ CUỐI LÊN ĐỂ TẮT TẤT CẢ CÁC FORM KHÁC
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                Form? f = Application.OpenForms[i];

                if (f?.Name != "Login")
                {
                    f?.Close(); // Đóng form
                }
            }
        }

        private void BtnOverview_Click(object sender, EventArgs e)
        {
            ucOverview_Staff uc = new();
            AddUserControl(uc);
            lblTitle.Text = "Tổng quan";
        }

        private void BtnLeave_Click(object sender, EventArgs e)
        {
            ucLeaveRequest uc = new();
            AddUserControl(uc);
            lblTitle.Text = "Xin nghỉ";
        }

        private void BtnWorkTracking_Click(object sender, EventArgs e)
        {
            ucWorkTracking uc = new();
            AddUserControl(uc);
            lblTitle.Text = "Theo dõi công việc";
        }
    }
}