using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Bai3
{
    public partial class TCPServerForm : Form
    {
        private TcpListener listener;
        private Thread serverThread;
        private bool isListening = false;

        public TCPServerForm()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            btnListen.Enabled = false;
            isListening = true;

            // Chạy server trên một luồng riêng
            serverThread = new Thread(new ThreadStart(StartListening));
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void StartListening()
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
                listener.Start();
                UpdateMessageBoard("Server running on 127.0.0.1:8080\n");

                while (isListening)
                {
                    // Chấp nhận kết nối từ Client
                    TcpClient client = listener.AcceptTcpClient();
                    UpdateMessageBoard("New client connected\n");

                    // Tạo luồng riêng để nhận dữ liệu từ Client này
                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                if (isListening) MessageBox.Show("Lỗi Server: " + ex.Message);
            }
        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                while (client.Connected)
                {
                    // Đọc từng dòng dữ liệu từ Client gởi lên
                    string message = reader.ReadLine();

                    // Nếu Client gởi lệnh "quit" hoặc ngắt kết nối thì thoát vòng lặp
                    if (message == null || message == "quit") break;

                    UpdateMessageBoard(message + "\n");
                }
            }
            catch { /* Bỏ qua lỗi ngắt kết nối đột ngột */ }
            finally
            {
                client.Close();
            }
        }

        // Delegate cập nhật UI an toàn (Thread-safe)
        private void UpdateMessageBoard(string text)
        {
            if (rtbMessages.InvokeRequired)
            {
                rtbMessages.Invoke(new Action<string>(UpdateMessageBoard), text);
            }
            else
            {
                rtbMessages.AppendText(text);
                rtbMessages.SelectionStart = rtbMessages.Text.Length;
                rtbMessages.ScrollToCaret();
            }
        }

        private void TCPServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isListening = false;
            if (listener != null) listener.Stop();
        }
    }
}