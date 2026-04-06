using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DAL
{
    public class AuthService
    {
        // Link URL nhận được từ Firebase Console sau khi Deploy
        private readonly string _functionUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/updateUserPassword";

        // Mã bí mật phải khớp với file index.js trên Cloud Functions
        private readonly string _secretKey = "Chuoi_Bi_Mat_Cua_Ban_Vua_Tao";

        public async Task<(bool Success, string Message)> UpdateFirebasePassword(string email, string newPassword)
        {
            using (HttpClient client = new HttpClient())
            {
                // Đóng gói dữ liệu vào đối tượng ẩn danh
                var data = new
                {
                    email = email,
                    newPassword = newPassword,
                    secretKey = _secretKey
                };

                // Chuyển đối tượng thành chuỗi JSON
                string json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    // Gửi yêu cầu POST lên server
                    var response = await client.PostAsync(_functionUrl, content);
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
}