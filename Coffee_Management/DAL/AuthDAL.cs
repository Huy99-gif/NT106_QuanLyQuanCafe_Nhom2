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
        private static readonly HttpClient _httpClient = new HttpClient();
        public async Task<(EmployeeDTO? User, string? Token)> LoginDAL(string email, string password)
        {
            try
            {
                // Dán URL Cloud Function của bạn vào đây
                string functionUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/loginEmployee";

                var credentials = new { email = email, password = password };
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
                throw new Exception("Error server connection: " + ex.Message);
            }
        }
    }
}