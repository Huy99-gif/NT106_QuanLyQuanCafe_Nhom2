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
    public class ChatManager(Control uiControl, ListBox lstChatHistory)
    {
        private HubConnection? _connection;
        // Ai xài lớp này cũng có thể lấy được ID phòng hiện tại
        public string CurrentRoomId { get; private set; } = "room_global";

        // --- HÀM 1: KẾT NỐI SERVER---
        public async Task ConnectToChatServer()
        {
            try
            {
                // Đọc IP hoặc Link từ file App.config
                string? savedIP = ConfigurationManager.AppSettings["ChatServerIP"] ?? "";
                string? serverUrl = savedIP.StartsWith("http") ? savedIP : $"http://{savedIP}:8080/chathub";

                _connection = new HubConnectionBuilder()
                    .WithUrl(serverUrl)
                    .WithAutomaticReconnect()
                    .Build();

                _connection.On<string, string, string>("ReceiveMessageWithRoom", (senderId, message, roomId) =>
                {
                    if (uiControl.IsHandleCreated)
                    {
                        uiControl.Invoke(new Action(() => {
                            if (roomId == CurrentRoomId)
                            {
                                string currentTime = DateTime.Now.ToString("dd/MM HH:mm");
                                string myId = GlobalSession.CurrentUser?.EmployeeId ?? "Unknown";

                                // Phân biệt Tôi và Người khác khi nhận tin
                                if (senderId == myId)
                                {
                                    lstChatHistory.Items.Add($"[{currentTime}] ▶ Tôi: {message}");
                                }
                                else
                                {
                                    lstChatHistory.Items.Add($"[{currentTime}] 👤 {senderId}: {message}");
                                }

                                lstChatHistory.Items.Add("");
                                lstChatHistory.TopIndex = lstChatHistory.Items.Count - 1;
                            }
                        }));
                    }
                });

                await _connection.StartAsync();
                lstChatHistory.Items.Add($"[Hệ thống]: Đã kết nối thành công tới máy chủ trò chuyện ({savedIP}).");
            }
            catch (Exception ex)
            {
                lstChatHistory.Items.Add($"[Lỗi]: Mất kết nối server chat\n{ex.Message}");
            }
        }

        // --- HÀM 2: CHUYỂN PHÒNG & TẢI LỊCH SỬ---
        public async Task SwitchChatRoom(string targetId)
        {
            if (GlobalSession.CurrentUser == null) return;

            string? myId = GlobalSession.CurrentUser.EmployeeId;
            if (myId == null) 
                return;
            CurrentRoomId = ChatBUS.GetRoomId(myId, targetId);

            // Gọi BUS để lấy RoomID chuẩn
            lstChatHistory.Items.Clear();
            lstChatHistory.Items.Add($"[Hệ thống]: Đang tải lịch sử trò chuyện với {targetId}...");

            try
            {
                var history = await ChatBUS.GetHistory(CurrentRoomId);

                //SỬ DỤNG BeginUpdate/EndUpdate để tránh nhấp nháy khi load nhiều tin nhắn
                lstChatHistory.BeginUpdate();
                lstChatHistory.Items.Clear();

                foreach (var msg in history)
                {
                    DateTime msgTime = DateTimeOffset.FromUnixTimeMilliseconds(msg.Timestamp).LocalDateTime;

                    // Phân biệt Tôi và Người khác khi load lịch sử
                    if (msg.SenderId == myId)
                    {
                        lstChatHistory.Items.Add($"[{msgTime:dd/MM HH:mm}] ▶ Tôi: {msg.Message}");
                    }
                    else
                    {
                        lstChatHistory.Items.Add($"[{msgTime:dd/MM HH:mm}] 👤 {msg.SenderId}: {msg.Message}");
                    }
                    lstChatHistory.Items.Add("");
                }

                lstChatHistory.TopIndex = lstChatHistory.Items.Count - 1;

                // Nếu không có tin nhắn nào thì hiển thị thông báo
                lstChatHistory.EndUpdate();
            }
            catch (Exception ex)
            {
                lstChatHistory.Items.Add("[Lỗi]: Không thể tải lịch sử. " + ex.Message);
            }
        }

        // --- HÀM 3: GỬI TIN NHẮN---
        public async Task SendMessageAsync(string message)
        {
            if (_connection != null && _connection.State == HubConnectionState.Connected)
            {
                string myId = GlobalSession.CurrentUser?.EmployeeId ?? "";
                if (Validation.IsAnyEmpty(message))
                {
                    MsgBox.Show("Không thể gửi tin nhắn trống!", "Lỗi xác thực", MsgBox.MessageBoxType.Warning);
                    return;
                }

                // Gửi tin nhắn lên màn hình qua SignalR
                await _connection.InvokeAsync("SendMessageWithRoom", myId, message, CurrentRoomId);

                // Giao việc lưu Firebase cho luồng chạy ngầm
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
                        await ChatBUS.SaveMessage(CurrentRoomId, chatDto);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi lưu tin nhắn: " + ex.Message);
                    }
                });
            }
            else
            {
                MsgBox.Show("Mất kết nối tới server! Vui lòng kiểm tra mạng của bạn.", "Lỗi mạng", MsgBox.MessageBoxType.Warning);
            }
        }
    }
}