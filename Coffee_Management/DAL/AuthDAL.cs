using DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AuthDAL
    {

        private static readonly HttpClient _httpClient = new();
        private static readonly string functionUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/loginEmployee";
        // Link URL nhận được từ Firebase Console sau khi Deploy
        private static readonly string _functionUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/updateUserPassword";

        // Mã bí mật phải khớp với file index.js trên Cloud Functions
        private static readonly string? _secretKey = ConfigurationManager.AppSettings["FirebaseSecretKey"];
        public static async Task<(EmployeeDTO? User, string? Token)> LoginDAL(string email, string password)
        {
            try
            {
                var credentials = new { email, password };
                string jsonPayload = JsonConvert.SerializeObject(credentials);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(functionUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    // PHÂN TÍCH JSON: { token: "...", user: { ... } }
                    JObject json = JObject.Parse(responseData);

                    string? token = json["token"]?.ToString();
                    EmployeeDTO? user = json["user"]?.ToObject<EmployeeDTO>();

                    // Trả về cả 2 giá trị cùng lúc
                    return (user, token);
                }

                return (null, null);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kêt nối trong quá trình đăng nhập: " + ex.Message);
            }
        }

        public static async Task<(bool Success, string Message)> UpdateFirebasePassword(string email, string newPassword)
        {
            // Đóng gói dữ liệu vào đối tượng ẩn danh
            var data = new { email, newPassword, secretKey = _secretKey };

            // Chuyển đối tượng thành chuỗi JSON
            string json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                // Gửi yêu cầu POST lên server
                var response = await _httpClient.PostAsync(_functionUrl, content);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return (true, "Update successful");
                }
                else
                {
                    // Trả về lỗi chi tiết từ Firebase Admin SDK
                    return (false, responseBody);
                }
            }
            catch (Exception ex)
            {
                // Lỗi kết nối mạng hoặc server không phản hồi
                return (false, ex.Message);
            }
        }
    }
}