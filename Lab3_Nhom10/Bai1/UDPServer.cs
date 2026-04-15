using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Bai1
{
    public partial class UDPServer : Form
    {
        private Thread serverThread;
        private UdpClient udpServer;
        private bool isListening = false;

        public UDPServer()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            int port;
            if (!int.TryParse(txtPort.Text, out port))
            {
                MessageBox.Show("Vui lòng nhập Port hợp lệ (ví dụ: 8080)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnListen.Enabled = false;
            isListening = true;

            // Khởi tạo Thread lắng nghe
            serverThread = new Thread(new ThreadStart(StartServer));
            serverThread.IsBackground = true;
            serverThread.Start();

            AppendMessage($"[System] Server started listening on port {port}...\n");
        }

        private void StartServer()
        {
            try
            {
                int port = int.Parse(txtPort.Text);
                udpServer = new UdpClient(port);
                IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                while (isListening)
                {
                    // Block và chờ dữ liệu tới
                    Byte[] receiveBytes = udpServer.Receive(ref remoteIpEndPoint);

                    // Decode UTF8 để nhận Tiếng Việt có dấu
                    string returnData = Encoding.UTF8.GetString(receiveBytes);
                    string message = $"{remoteIpEndPoint.Address}: {returnData}\n";

                    AppendMessage(message);
                }
            }
            catch (SocketException)
            {
                // Xảy ra khi udpServer.Close() được gọi trong lúc đang Receive
                if (isListening)
                {
                    MessageBox.Show("Lỗi kết nối mạng!", "Lỗi Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                if (isListening)
                {
                    MessageBox.Show(ex.Message, "Lỗi Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Kỹ thuật Thread-safe call để cập nhật RichTextBox từ Thread phụ
        private void AppendMessage(string message)
        {
            if (rtbMessages.InvokeRequired)
            {
                rtbMessages.Invoke(new Action<string>(AppendMessage), message);
            }
            else
            {
                rtbMessages.AppendText(message);
                // Tự động cuộn xuống dòng mới nhất
                rtbMessages.SelectionStart = rtbMessages.Text.Length;
                rtbMessages.ScrollToCaret();
            }
        }

        // Đảm bảo đóng kết nối và tắt Thread khi đóng Form
        private void UDPServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            isListening = false;
            if (udpServer != null)
            {
                udpServer.Close();
            }
        }
    }
}