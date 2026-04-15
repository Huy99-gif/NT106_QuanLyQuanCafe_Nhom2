using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Sockets;

namespace QLCafe.ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Thêm dịch vụ SignalR và CORS (Mở cửa cho máy khác truy cập)
            builder.Services.AddSignalR();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(_ => true).AllowCredentials();
                });
            });

            var app = builder.Build();

            // Kích hoạt CORS và tạo đường dẫn Hub
            app.UseCors();
            app.MapHub<ChatHub>("/chathub");

            // Tự động tìm IP mạng LAN của máy chủ
            string myIP = "localhost";
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork) { myIP = ip.ToString(); break; }
            }

            // Mở cổng 8080
            string serverUrl = $"http://{myIP}:8080";
            app.Urls.Add(serverUrl);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Starting server...");
            Console.WriteLine($"Server started at: {serverUrl}");
            Console.ResetColor();

            app.Run(); // Lệnh này giúp treo màn hình đen và chạy Server
        }
    }

    // Lớp xử lý nhận và phát tin nhắn
    public class ChatHub : Hub
    {
        public async Task SendMessage(string senderName, string message)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {senderName}: {message}");
            // Phát tin nhắn về tất cả máy trạm với sự kiện "ReceiveMessage"
            await Clients.All.SendAsync("ReceiveMessage", senderName, message);
        }

        public async Task SendMessageWithRoom(string senderName, string message, string roomId)
        {
            // In ra màn hình đen để bạn dễ debug
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [Room: {roomId}] {senderName}: {message}");

            // Phát tin nhắn này tới TẤT CẢ mọi người, kèm theo cái roomId để máy nhận biết đường mà lọc
            await Clients.All.SendAsync("ReceiveMessageWithRoom", senderName, message, roomId);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }
    }
}