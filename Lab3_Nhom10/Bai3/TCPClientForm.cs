using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Bai3
{
    public partial class TCPClientForm : Form
    {
        // Khai báo sẵn các đối tượng trong Class theo Ghi chú
        private TcpClient tcpClient;
        private NetworkStream ns;

        public TCPClientForm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước 1 & 2: Khởi tạo và Kết nối (nếu chưa kết nối)
                if (tcpClient == null || !tcpClient.Connected)
                {
                    tcpClient = new TcpClient();
                    IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                    IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8080);

                    tcpClient.Connect(ipEndPoint);

                    // Bước 3: Lấy luồng giao tiếp
                    ns = tcpClient.GetStream();
                }

                // Bước 4: Gửi dữ liệu đến Server (kèm ký tự \n để Server dùng ReadLine)
                Byte[] data = Encoding.UTF8.GetBytes("Hello server\n");
                ns.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối Server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TCPClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Bước 5: Gửi thông điệp kết thúc và đóng kết nối
                if (ns != null && tcpClient.Connected)
                {
                    Byte[] quitData = Encoding.UTF8.GetBytes("quit\n");
                    ns.Write(quitData, 0, quitData.Length);

                    ns.Close();
                }
                if (tcpClient != null)
                {
                    tcpClient.Close();
                }
            }
            catch { /* Bỏ qua lỗi nếu Server đã đóng trước */ }
        }
    }
}