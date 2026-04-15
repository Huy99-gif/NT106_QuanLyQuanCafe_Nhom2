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
    public partial class OrderStaffDashboard : BaseDashboard
    {
        public OrderStaffDashboard()
        {
            InitializeComponent();
            this.Load += (s, e) => btnPOS.PerformClick();
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

        private void btnPOS_Click(object sender, EventArgs e)
        {
            ucPOS_OrStaff uc = new ucPOS_OrStaff();
            AddUserControl(uc);
            lblTitle.Text = "POS / Order";
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            Form? Login = Application.OpenForms["Login"];
            if (Login != null)
            {
                Login.Show();
            }
            this.Close();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
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
    }
}