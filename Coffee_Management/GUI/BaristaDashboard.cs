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
    public partial class BaristaDashboard : BaseDashboard
    {
        public BaristaDashboard()
        {
            InitializeComponent();
        }

        private void lblLogo_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form? Login = Application.OpenForms["Login"];
            if (Login != null)
            {
                Login.Show();
            }
            GlobalSession.Logout();
            //DUYỆT NGƯỢC TỪ CUỐI LÊN ĐỂ TẮT TẤT CẢ CÁC FORM KHÁC
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                Form? f = Application.OpenForms[i];

                // Nếu không phải là form Login thì đóng nó lại
                // (Dùng f.Name để kiểm tra)
                if (f.Name != "Login")
                {
                    f.Close(); // Đóng form
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void btnChat_Click(object sender, EventArgs e)
        {
            // Dùng UC chat chung cho toàn bộ nhân viên
            ucInternalChat uc = new ucInternalChat();
            AddUserControl(uc);
            lblTitle.Text = "Internal Chat";
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            ucAttendance uc = new ucAttendance();
            AddUserControl(uc);
            lblTitle.Text = "Timekeeping & Attendance";
        }

        private void btnLeaveRequest_Click(object sender, EventArgs e)
        {
            ucLeaveRequest uc = new ucLeaveRequest();
            AddUserControl(uc);
            lblTitle.Text = "Leave Request";
        }

        private void btnProfile_Click_1(object sender, EventArgs e)
        {
            ucProfile uc = new ucProfile();
            AddUserControl(uc);
            lblTitle.Text = "Personal Profile";
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
