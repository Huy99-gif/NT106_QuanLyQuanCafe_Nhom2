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
        private readonly HttpClient _client = new HttpClient();
        private string _baseUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/";

        // Gắn Token vào Header cho mỗi request
        private void SetAuthorizationHeader(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task SaveMessageAsync(string roomId, ChatMessageDTO chatData, string token)
        {
            try
            {
                SetAuthorizationHeader(token);

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

        public async Task<List<ChatMessageDTO>> GetHistoryAsync(string roomId, string token)
        {
            try
            {
                SetAuthorizationHeader(token);

                var response = await _client.GetAsync(_baseUrl + $"getChatHistory?roomId={roomId}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<ChatMessageDTO>>(json) ?? new List<ChatMessageDTO>();
                }
                return new List<ChatMessageDTO>();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy lịch sử chat: " + ex.Message);
            }
        }
    }
}
