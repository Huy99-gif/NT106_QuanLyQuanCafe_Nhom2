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
        private static readonly string BaseUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/";
        // Gọi API kiểm tra
        public static async Task<(bool Exists, string Message)> CheckEmailAPI(string email)
        {
            try
            {
                var data = new { email };
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(BaseUrl + "checkEmailExists", content);
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
            try
            {
                var data = new { toEmail = email };
                using var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(BaseUrl + "generateAndSendOTP", content);
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
