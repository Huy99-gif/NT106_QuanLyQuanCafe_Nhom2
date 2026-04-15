using BUS;
using DTO;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    // Lớp này là "Trái tim" xử lý Chat cho toàn bộ App QLCafe
    public class ChatManager
    {
        private HubConnection _connection;
        private readonly ChatBUS _chatBus = new ChatBUS();

        // Ai xài lớp này cũng có thể lấy được ID phòng hiện tại
        public string CurrentRoomId { get; private set; } = "room_global";

        private readonly Control _uiControl; // Lưu form gọi nó để Invoke an toàn
        private readonly ListBox _lstChatHistory; // Lưu cái ListBox để nó tự nhét chữ vào

        // Khởi tạo: Truyền form và cái ListBox vào đây
        public ChatManager(Control uiControl, ListBox lstChatHistory)
        {
            _uiControl = uiControl;
            _lstChatHistory = lstChatHistory;
        }

        // --- HÀM 1: KẾT NỐI SERVER (HỖ TRỢ CẢ LOCAL LẪN CLOUD) ---
        public async Task ConnectToChatServer()
        {
            try
            {
                // Đọc IP hoặc Link từ file App.config
                string savedIP = ConfigurationManager.AppSettings["ChatServerIP"];

                // Nếu trong config là IP (vd: 192.168.x.x) thì ráp thêm cổng 8080.
                // Nếu trong config là Link Render (bắt đầu bằng http) thì xài luôn.
                string serverUrl = savedIP.StartsWith("http") ? savedIP : $"http://{savedIP}:8080/chathub";

                _connection = new HubConnectionBuilder()
                    .WithUrl(serverUrl)
                    .WithAutomaticReconnect()
                    .Build();

                _connection.On<string, string, string>("ReceiveMessageWithRoom", (senderId, message, roomId) =>
                {
                    if (_uiControl.IsHandleCreated)
                    {
                        _uiControl.Invoke(new Action(() => {
                            if (roomId == CurrentRoomId)
                            {
                                string currentTime = DateTime.Now.ToString("dd/MM HH:mm");
                                string myId = GlobalSession.CurrentUser?.EmployeeId ?? "Unknown";

                                // Phân biệt Tôi và Người khác khi nhận tin
                                if (senderId == myId)
                                {
                                    _lstChatHistory.Items.Add($"[{currentTime}] ▶ Tôi: {message}");
                                }
                                else
                                {
                                    _lstChatHistory.Items.Add($"[{currentTime}] 👤 {senderId}: {message}");
                                }

                                _lstChatHistory.Items.Add("");
                                _lstChatHistory.TopIndex = _lstChatHistory.Items.Count - 1;
                            }
                        }));
                    }
                });

                await _connection.StartAsync();
                _lstChatHistory.Items.Add($"[System]: Successfully connected to Chat Server ({savedIP}).");
            }
            catch (Exception ex)
            {
                _lstChatHistory.Items.Add($"[Error]: Lost connection to the chat server. {ex.Message}");
            }
        }

        // --- HÀM 2: CHUYỂN PHÒNG & TẢI LỊCH SỬ (TỐI ƯU GIAO DIỆN) ---
        public async Task SwitchChatRoom(string targetId)
        {
            if (GlobalSession.CurrentUser == null) return;

            string myId = GlobalSession.CurrentUser.EmployeeId;
            CurrentRoomId = _chatBus.GetRoomId(myId, targetId);

            // Gọi BUS để lấy RoomID chuẩn
            _lstChatHistory.Items.Clear();
            _lstChatHistory.Items.Add($"[System]: Loading chat history with {targetId}...");

            try
            {
                var history = await _chatBus.GetHistory(CurrentRoomId);

                // TỐI ƯU 1: KHÓA VẼ GIAO DIỆN (CHỐNG GIẬT LAG)
                _lstChatHistory.BeginUpdate();
                _lstChatHistory.Items.Clear();

                foreach (var msg in history)
                {
                    DateTime msgTime = DateTimeOffset.FromUnixTimeMilliseconds(msg.Timestamp).LocalDateTime;

                    // Phân biệt Tôi và Người khác khi load lịch sử
                    if (msg.SenderId == myId)
                    {
                        _lstChatHistory.Items.Add($"[{msgTime:dd/MM HH:mm}] ▶ Tôi: {msg.Message}");
                    }
                    else
                    {
                        _lstChatHistory.Items.Add($"[{msgTime:dd/MM HH:mm}] 👤 {msg.SenderId}: {msg.Message}");
                    }
                    _lstChatHistory.Items.Add("");
                }

                _lstChatHistory.TopIndex = _lstChatHistory.Items.Count - 1;

                // TỐI ƯU 1: MỞ LẠI GIAO DIỆN
                _lstChatHistory.EndUpdate();
            }
            catch (Exception ex)
            {
                _lstChatHistory.Items.Add("[Error]: Fail to load history. " + ex.Message);
            }
        }

        // --- HÀM 3: GỬI TIN NHẮN (TỐI ƯU XỬ LÝ NGẦM) ---
        public async Task SendMessageAsync(string message)
        {
            if (_connection != null && _connection.State == HubConnectionState.Connected)
            {
                string myId = GlobalSession.CurrentUser.EmployeeId;

                // 1. Nhảy tin nhắn lên màn hình qua SignalR (Mất 0.01 giây)
                await _connection.InvokeAsync("SendMessageWithRoom", myId, message, CurrentRoomId);

                // 2. TỐI ƯU 2: FIRE AND FORGET (Giao việc lưu Firebase cho luồng chạy ngầm)
                _ = Task.Run(async () =>
                {
                    try
                    {
                        var chatDto = new ChatMessageDTO
                        {
                            SenderId = myId,
                            Message = message,
                            Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
                        };
                        await _chatBus.SaveMessage(CurrentRoomId, chatDto);
                    }
                    catch (Exception ex)
                    {
                        // Lỗi mạng ẩn thì ghi log, không làm đứng App của người dùng
                        Console.WriteLine("Firebase save error: " + ex.Message);
                    }
                });
            }
            else
            {
                MessageBox.Show("Mất kết nối với Server! Vui lòng kiểm tra lại mạng.", "Network error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}