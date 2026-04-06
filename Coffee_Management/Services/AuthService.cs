using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; 

namespace Services
{
    public class AuthService
    {
        // 1. Thay thế bằng URL bạn nhận được sau khi chạy lệnh 'firebase deploy'
        private readonly string _functionUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/updateUserPassword";

        // 2. Thay thế bằng mã bí mật bạn đã đặt trong file index.js (Node.js)
        private readonly string _secretKey = "Chuoi_Bi_Mat_Cua_Ban_Vua_Tao";

        /// <summary>
        /// Gửi yêu cầu cập nhật mật khẩu lên Firebase thông qua Cloud Functions
        /// </summary>
        /// <param name="email">Email của tài khoản cần đổi mật khẩu</param>
        /// <param name="newPassword">Mật khẩu mới</param>
        /// <returns>Trả về một Tuple gồm kết quả thành công/thất bại và thông báo đi kèm</returns>
        public async Task<(bool Success, string Message)> UpdatePasswordAsync(string email, string newPassword)
        {
            using (HttpClient client = new HttpClient())
            {
                // Chuẩn bị dữ liệu gửi đi (phải khớp với tên biến trong Node.js)
                var data = new
                {
                    email = email,
                    newPassword = newPassword,
                    secretKey = _secretKey
                };

                string json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    // Gửi yêu cầu POST đến Cloud Function
                    var response = await client.PostAsync(_functionUrl, content);
                    string responseText = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return (true, "Password updated successfully!");
                    }
                    else
                    {
                        // Trả về lỗi chi tiết từ server (ví dụ: User not found)
                        return (false, $"Server error: {responseText}");
                    }
                }
                catch (Exception ex)
                {
                    // Trả về lỗi kết nối mạng hoặc lỗi hệ thống
                    return (false, $"Connection error: {ex.Message}");
                }
            }
        }
    }
}