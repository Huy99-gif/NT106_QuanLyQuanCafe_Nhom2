using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Bai1
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            // Mở Form Server
            UDPServer serverForm = new UDPServer();
            serverForm.Show();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            // Mở Form Client
            UDPClient clientForm = new UDPClient();
            clientForm.Show();
        }
    }
}