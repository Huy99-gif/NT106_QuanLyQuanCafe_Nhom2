using DTO;
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
    public partial class BaristaDashboard : Form
    {
        private readonly BaseDashboard _dashboardManager;
        public BaristaDashboard()
        {
            InitializeComponent();
            _dashboardManager = new BaseDashboard(this);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Form? Login = Application.OpenForms["Login"];
            if (Login != null)
            {
                Login.Show();
            }
            else
            {
                Login loginForm = new();
                loginForm.Show();
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

        private void BtnChat_Click(object sender, EventArgs e)
        {
            // Dùng UC chat chung cho toàn bộ nhân viên
            ucInternalChat uc = new();
            AddUserControl(uc);
            lblTitle.Text = "Chat";
        }

        private void BtnAttendance_Click(object sender, EventArgs e)
        {
            ucAttendance uc = new();
            AddUserControl(uc);
            lblTitle.Text = "Chấm công";
        }

        private void BtnLeaveRequest_Click(object sender, EventArgs e)
        {
            ucLeaveRequest uc = new();
            AddUserControl(uc);
            lblTitle.Text = "Xin nghỉ";
        }

        private void BtnProfile_Click_1(object sender, EventArgs e)
        {
            ucProfile uc = new();
            AddUserControl(uc);
            lblTitle.Text = "Profile";
        }

        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOverview_Click(object sender, EventArgs e)
        {
            ucOverview_Staff uc = new();
            AddUserControl(uc);
            lblTitle.Text = "Tổng quan";
        }
    }
}
