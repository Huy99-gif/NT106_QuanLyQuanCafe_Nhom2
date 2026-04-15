using BUS;
using DTO;
using Microsoft.AspNetCore.SignalR.Client; // Thêm thư viện SignalR Client
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text; // THÊM MỚI
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucSettings_Manager : UserControl
    {
        private readonly EmployeeBUS _employeeBus = new EmployeeBUS();
        private List<EmployeeDTO> _allEmployees = new List<EmployeeDTO>();
        private HubConnection _connection; // Biến giữ kết nối SignalR

        // --- THÊM MỚI: CÁC BIẾN CHO FIREBASE VÀ PHÒNG CHAT ---
        private readonly ChatBUS _chatBus = new ChatBUS();
        private string _currentRoomId = "room_global";
        // --------------------------------------------------

        public ucSettings_Manager()
        {
            InitializeComponent();

            // Nạp dữ liệu Employee VÀ kết nối Chat Server khi mở Tab
            this.Load += async (s, e) =>
            {
                await LoadEmployeeData();
                await ConnectToChatServer();
            };

            btnSend.Click += BtnSend_Click;
            btnOpenChatWindow.Click += BtnOpenChatWindow_Click;
            btnChangePassword.Click += BtnChangePassword_Click;
            btnUpdateProfile.Click += BtnUpdateProfile_Click;

            // --- THÊM MỚI: SỰ KIỆN CHỌN NGƯỜI ĐỂ TẢI LỊCH SỬ RIÊNG ---
            cmbChatTarget.SelectedIndexChanged += async (s, e) => await SwitchChatRoom();
            // -------------------------------------------------------
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
                    .WithAutomaticReconnect() // Tự động kết nối lại nếu rớt mạng
                    .Build();

                // Lắng nghe tin nhắn từ Server trả về
                _connection.On<string, string>("ReceiveMessage", (senderName, message) =>
                {
                    // Phải dùng Invoke để đưa tin nhắn lên UI an toàn
                    this.Invoke(new Action(() => {
                        lstChatHistory.Items.Add($"[{senderName}]: {message}");
                        lstChatHistory.Items.Add(""); // Dòng trống cho thoáng
                        lstChatHistory.TopIndex = lstChatHistory.Items.Count - 1; // Cuộn xuống cuối
                    }));
                });

                // --- THÊM MỚI: LẮNG NGHE TIN NHẮN THEO PHÒNG (ROOMID) ---
                _connection.On<string, string, string>("ReceiveMessageWithRoom", (senderId, message, roomId) =>
                {
                    this.Invoke(new Action(() => {
                        if (roomId == _currentRoomId) // Chỉ hiện nếu đang mở đúng phòng
                        {
                            lstChatHistory.Items.Add($"[{senderId}]: {message}");
                            lstChatHistory.Items.Add("");
                            lstChatHistory.TopIndex = lstChatHistory.Items.Count - 1;
                        }
                    }));
                });
                // ------------------------------------------------------

                await _connection.StartAsync();
                lstChatHistory.Items.Add("[System]: Successfully connected to the Chat Server (192.168.2.24).");
            }
            catch (Exception ex)
            {
                lstChatHistory.Items.Add($"[Error]: Lost connection to the chat server. {ex.Message}");
            }
        }

        private async Task LoadEmployeeData()
        {
            try
            {
                _allEmployees = await _employeeBus.GetAllEmployeesAsync();
                if (_allEmployees == null || _allEmployees.Count == 0) return;

                cmbChatTarget.Items.Clear();
                cmbChatTarget.Items.Add("--- Everyone (Group Chat) ---");

                foreach (var emp in _allEmployees.Where(x => x.Status == "active"))
                {
                    cmbChatTarget.Items.Add($"[{emp.EmployeeId}] {emp.FullName} ({emp.Role})");
                }

                if (cmbChatTarget.Items.Count > 0) cmbChatTarget.SelectedIndex = 0;

                lstChatHistory.Items.Clear();
                lstChatHistory.Items.Add("[System]: Internal communication channel connected.");
                lstChatHistory.Items.Add("");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load employee list: {ex.Message}", "System Error");
            }
        }

        // Đổi thành async void để xài được lệnh await gửi tin nhắn
        private async void BtnSend_Click(object? sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(message)) return;

            // Kiểm tra xem đã nối mạng với Server chưa
            if (_connection != null && _connection.State == HubConnectionState.Connected)
            {
                string senderName = "Manager: " + GlobalSession.CurrentUser.FullName;
                // Gửi tên Manager và nội dung lên Server
                await _connection.InvokeAsync("SendMessage", senderName, message);

                // --- THÊM MỚI: LƯU VÀO FIREBASE VÀ GỬI KÈM ROOMID ---
                string myId = GlobalSession.CurrentUser.EmployeeId;
                await _connection.InvokeAsync("SendMessageWithRoom", myId, message, _currentRoomId);

                var chatDto = new ChatMessageDTO
                {
                    SenderId = myId,
                    Message = message,
                    Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                };
                await _chatBus.SaveMessage(_currentRoomId, chatDto);
            }
            else
            {
                MessageBox.Show("Losing connection to the chat server!", "Network error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtMessage.Clear();
            txtMessage.Focus();
        }

        private void BtnOpenChatWindow_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("This feature will open a standalone Messenger-style window.", "Floating Chat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnChangePassword_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Opening Password Reset form...", "Security");
        }

        private void BtnUpdateProfile_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Opening Profile Editor...", "Account Settings");
        }

        // --- THÊM MỚI: CÁC HÀM XỬ LÝ CHUYỂN PHÒNG CHAT ---
        private async Task SwitchChatRoom()
        {
            string myId = GlobalSession.CurrentUser.EmployeeId;
            string targetId = GetIdFromCombo();
            _currentRoomId = _chatBus.GetRoomId(myId, targetId);

            lstChatHistory.Items.Clear();
            lstChatHistory.Items.Add($"[System]: Loading chat history with {targetId}...");

            try
            {
                var history = await _chatBus.GetHistory(_currentRoomId);
                lstChatHistory.Items.Clear();
                foreach (var msg in history)
                {
                    string sender = (msg.SenderId == myId) ? "Me" : msg.SenderId;
                    lstChatHistory.Items.Add($"[{sender}]: {msg.Message}");
                    lstChatHistory.Items.Add("");
                }
                lstChatHistory.TopIndex = lstChatHistory.Items.Count - 1;
            }
            catch (Exception ex)
            {
                lstChatHistory.Items.Add("[Error]: Fail to load history. " + ex.Message);
            }
        }

        private string GetIdFromCombo()
        {
            if (cmbChatTarget.SelectedIndex <= 0) return "Everyone";
            return cmbChatTarget.SelectedItem.ToString().Split(']')[0].Trim('[');
        }
    }
}