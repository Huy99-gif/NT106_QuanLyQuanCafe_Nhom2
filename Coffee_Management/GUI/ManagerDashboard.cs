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
    public partial class ManagerDashboard : Form
    {
        public ManagerDashboard()
        {
            InitializeComponent();
        }

        private void lblLogo_Click(object sender, EventArgs e)
        {

        }

        private void AddUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Clear();
            pnlMainContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ucOverview_Manager uc = new ucOverview_Manager();
            AddUserControl(uc);
            lblTitle.Text = "Overview";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ucProducts_Manager uc = new ucProducts_Manager();
            AddUserControl(uc);
            lblTitle.Text = "Product and Menu";
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            ucOrders_Manager uc = new ucOrders_Manager();
            AddUserControl(uc);
            lblTitle.Text = "Orders and Bills";
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            ucStaff_Manager uc = new ucStaff_Manager();
            AddUserControl(uc);
            lblTitle.Text = "Manage Staff";
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ucSettings_Manager uc = new ucSettings_Manager();
            AddUserControl(uc);
            lblTitle.Text = "Settings";
        }

        private void btnLogout_Click(object? sender, EventArgs e)
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
