using BUS;
using DTO;
using Microsoft.AspNetCore.SignalR.Client; // Thêm thư viện SignalR Client
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucChatOrderStaff : UserControl
    {
        private readonly EmployeeBUS _employeeBus = new EmployeeBUS();
        private HubConnection _connection; // Biến giữ kết nối SignalR

        public ucChatOrderStaff()
        {
            InitializeComponent();

            this.Load += async (s, e) =>
            {
                await LoadStaffData();
                await ConnectToChatServer(); // Khởi chạy nối mạng Chat
            };

            btnSend.Click += BtnSend_Click;
            btnOpenChatWindow.Click += (s, e) => MessageBox.Show("Opening Messenger window...");
            txtMessage.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BtnSend_Click(s, e); } };
        }

        // --- HÀM KẾT NỐI TỚI SERVER MÀN HÌNH ĐEN ---
        private async Task ConnectToChatServer()
        {
            try
            {
                // Gắn IP từ màn hình Console của bạn vào đây
                string serverUrl = "http://192.168.2.24:8080/chathub";

                _connection = new HubConnectionBuilder()
                    .WithUrl(serverUrl)
                    .WithAutomaticReconnect()
                    .Build();

                _connection.On<string, string>("ReceiveMessage", (senderName, message) =>
                {
                    this.Invoke(new Action(() => {
                        lstChatHistory.Items.Add($"[{senderName}]: {message}");
                        lstChatHistory.Items.Add("");
                        lstChatHistory.TopIndex = lstChatHistory.Items.Count - 1;
                    }));
                });

                await _connection.StartAsync();
                lstChatHistory.Items.Add("[System]: Successfully connected to the Chat Server (192.168.2.24)");
            }
            catch (Exception ex)
            {
                lstChatHistory.Items.Add($"[Error]: Lost connection to the chat server. {ex.Message}");
            }
        }

        private async Task LoadStaffData()
        {
            try
            {
                List<EmployeeDTO> allEmployees = await _employeeBus.GetAllEmployeesAsync();

                cmbChatTarget.Items.Clear();
                cmbChatTarget.Items.Add("--- Send to Everyone (Group Chat) ---");

                if (allEmployees != null)
                {
                    foreach (var emp in allEmployees.Where(x => x.Status == "active"))
                    {
                        cmbChatTarget.Items.Add($"[{emp.EmployeeId}] {emp.FullName} ({emp.Role})");
                    }
                }

                if (cmbChatTarget.Items.Count > 0) cmbChatTarget.SelectedIndex = 0;

                lstChatHistory.Items.Clear();
                lstChatHistory.Items.Add("[System]: Connected to QLCafe Chat.");
            }
            catch (Exception ex)
            {
                lstChatHistory.Items.Add($"[Error]: Cannot load staff list. {ex.Message}");
            }
        }

        // Đổi thành async void để gửi tin
        private async void BtnSend_Click(object? sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(message)) return;

            if (_connection != null && _connection.State == HubConnectionState.Connected)
            {
                string senderName = "Order Staff: " + GlobalSession.CurrentUser.FullName;
                // Truyền tên người gửi là Order Staff
                await _connection.InvokeAsync("SendMessage", senderName, message);
            }
            else
            {
                MessageBox.Show("Losing connection to the chat server!", "Network error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtMessage.Clear();
            txtMessage.Focus();
        }
    }
}