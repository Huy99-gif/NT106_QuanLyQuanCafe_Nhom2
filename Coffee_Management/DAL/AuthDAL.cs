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
        // Khởi tạo HttpClient duy nhất cho toàn bộ lớp này để tái sử dụng kết nối
        private static readonly HttpClient _httpClient = new();
        // Khai báo các Endpoints
        private static readonly string BaseUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/";
        // Lấy secretKey từ App.config để sử dụng trong việc xác thực khi gọi API cập nhật mật khẩu
        private static readonly string? _secretKey = ConfigurationManager.AppSettings["FirebaseSecretKey"];
        // Hàm đăng nhập, trả về một tuple chứa thông tin người dùng (EmployeeDTO) và token (string)
        public static async Task<(EmployeeDTO? User, string? Token)> LoginDAL(string email, string password)
        {
            try
            {
                var credentials = new { email, password };
                string jsonPayload = JsonConvert.SerializeObject(credentials);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(BaseUrl + "loginEmployee", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    // Phân tích JSON: { token: "...", user: { ... } }
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
        // Hàm cập nhật mật khẩu, trả về một tuple chứa thông tin thành công hay không và thông báo lỗi (nếu có)
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
                var response = await _httpClient.PostAsync(BaseUrl + "updateUserPassword", content);
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