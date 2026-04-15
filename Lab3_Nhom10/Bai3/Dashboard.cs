using System;
using System.Windows.Forms;

namespace Bai3
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            TCPServerForm server = new TCPServerForm();
            server.Show();
        }

        private void btnOpenClient_Click(object sender, EventArgs e)
        {
            TCPClientForm client = new TCPClientForm();
            client.Show();
        }
    }
}