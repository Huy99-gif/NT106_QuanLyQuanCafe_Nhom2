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
    }
}