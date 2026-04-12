using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DAL
{
    public class EmailCodeDAL
    {
        private readonly string _checkEmailUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/checkEmailExists";
        private readonly string _sendOtpUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/generateAndSendOTP";
        // Gọi API kiểm tra
        public async Task<(bool Exists, string Message)> CheckEmailAPI(string email)
        {
            using (HttpClient client = new HttpClient())
            {
                var data = new { email = email };
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(_checkEmailUrl, content);
                dynamic? result = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

                return (response.IsSuccessStatusCode, (string)result.message);
            }
        }

        // Gọi API phát mail
        public async Task<(bool Success, string Code, string Message)> SendOtpAPI(string email)
        {
            using (HttpClient client = new HttpClient())
            {
                var data = new { toEmail = email };
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(_sendOtpUrl, content);
                dynamic? result = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

                if (response.IsSuccessStatusCode)
                    return (true, (string)result.code, (string)result.message);
                else
                    return (false, "", (string)result.message);
            }
        }
    }
}
