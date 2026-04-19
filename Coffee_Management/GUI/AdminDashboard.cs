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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AddUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Clear();
            pnlMainContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void BtnOverview_Click(object sender, EventArgs e)
        {
            ucOverview_Manager uc = new();
            AddUserControl(uc);
            lblTitle.Text = "Tổng quan";
        }

        private void BtnViewAttendance_Click(object sender, EventArgs e)
        {
            ucStaff_Manager uc = new();
            AddUserControl(uc);
            lblTitle.Text = "Quản lý nhân viên";
        }

        private void BtnChatAndSettings_Click(object sender, EventArgs e)
        {
            ucSettings_Manager uc = new();
            AddUserControl(uc);
            lblTitle.Text = "Cài đặt và Chat nội bộ";
        }
    }
}
