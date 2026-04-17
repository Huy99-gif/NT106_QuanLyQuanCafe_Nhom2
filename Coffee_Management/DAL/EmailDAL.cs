using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmailDAL
    {
        private static readonly HttpClient client = new();
        private static readonly string _checkEmailUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/checkEmailExists";
        private static readonly string _sendOtpUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/generateAndSendOTP";
        // Gọi API kiểm tra
        public static async Task<(bool Exists, string Message)> CheckEmailAPI(string email)
        {
            var data = new { email };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync(_checkEmailUrl, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(responseBody);
                string message = json["message"]?.ToString() ?? "Không có phản hồi từ hệ thống.";

                return (response.IsSuccessStatusCode, message);
            }
            catch (Exception ex)
            {
                return (false, "Lỗi kết nối: " + ex.Message);
            }
        }

        // Gọi API phát mail
        public static async Task<(bool Success, string Code, string Message)> SendOtpAPI(string email)
        {
            var data = new { toEmail = email };
            using var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync(_sendOtpUrl, content);
                string responseBody = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(responseBody);
                string message = json["message"]?.ToString() ?? "Gửi mã thất bại.";
                string code = json["code"]?.ToString() ?? "";

                if (response.IsSuccessStatusCode)
                    return (true, code, message);
                else
                    return (false, "", message);
            }
            catch (Exception ex)
            {
                return (false, "", "Lỗi kết nối: " + ex.Message);
            }
        }
    }
}
