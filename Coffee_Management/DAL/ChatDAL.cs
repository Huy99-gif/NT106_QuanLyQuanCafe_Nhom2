using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace DAL
{
    public class ChatDAL
    {
        private static readonly HttpClient _client = new();
        private static readonly string _baseUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/";

        // Hàm lưu tin nhắn vào Firebase Realtime thông qua Cloud Function
        public static async Task SaveMessageAsync(string roomId, ChatMessageDTO chatData)
        {
            try
            {
                // Gắn Token vào Header cho mỗi request
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token ?? "");
                var json = JsonSerializer.Serialize(new { roomId, chatData });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(_baseUrl + "saveChatMessage", content);
                response.EnsureSuccessStatusCode(); // Ném lỗi nếu không phải 200 OK
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lưu tin nhắn: " + ex.Message);
            }
        }

        // Hàm lấy lịch sử chat từ Firebase Realtime thông qua Cloud Function
        public static async Task<List<ChatMessageDTO>> GetHistoryAsync(string roomId)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token ?? "");
                var response = await _client.GetAsync(_baseUrl + $"getChatHistory?roomId={roomId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<ChatMessageDTO>>(json) ?? [];
                }
                return [];
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy lịch sử chat: " + ex.Message);
            }
        }
    }
}
