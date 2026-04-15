using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Bai1
{
    public partial class UDPClient : Form
    {
        public UDPClient()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIP.Text) || string.IsNullOrWhiteSpace(txtPort.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ IP và Port!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UdpClient udpClient = new UdpClient();

                // Chuẩn hóa tiếng Việt bằng UTF-8
                Byte[] sendBytes = Encoding.UTF8.GetBytes(txtMessage.Text);

                string ipHost = txtIP.Text.Trim();
                int port = int.Parse(txtPort.Text.Trim());

                // Gửi gói tin đi
                udpClient.Send(sendBytes, sendBytes.Length, ipHost, port);

                // Đóng kết nối sau khi gửi
                udpClient.Close();

            }
            catch (FormatException)
            {
                MessageBox.Show("Port phải là một số nguyên!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}