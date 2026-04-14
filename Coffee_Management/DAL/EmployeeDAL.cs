using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http; // Thêm thư viện này ở trên cùng
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeDAL
    {

        // Khai báo các Endpoints
        private readonly string _addEmployeeUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/addEmployee";
        private readonly string _getAllEmployeesUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/getAllEmployees";

        public async Task<(bool Success, string Message)> AddEmployeeCFAsync(EmployeeDTO emp)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Gắn Token vào Header 
                    if (!string.IsNullOrEmpty(GlobalSession.Token))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token);
                    }
                    // Chuyển đối tượng EmployeeDTO thành JSON
                    var content = new StringContent(JsonConvert.SerializeObject(emp), Encoding.UTF8, "application/json");
                    // Gửi yêu cầu POST đến Cloud Function
                    var response = await client.PostAsync(_addEmployeeUrl, content);
                    string resultStr = await response.Content.ReadAsStringAsync();

                    // Phòng thủ: Kiểm tra nếu Server sập hoặc trả về HTML
                    if (resultStr.TrimStart().StartsWith("<"))
                    {
                        return (false, $"Server Error ({response.StatusCode}): Access Denied or Invalid URL.");
                    }
                    // Cố gắng phân tích JSON trả về
                    dynamic? result = JsonConvert.DeserializeObject(resultStr);

                    if (response.IsSuccessStatusCode)
                    {
                        return (true, "Success");
                    }
                    else
                    {
                        string errorMessage = "Internal Server Error";
                        if (result != null)
                        {
                            if (result.message != null)
                                errorMessage = (string)result.message;
                            else if (result.error != null)
                                errorMessage = (string)result.error;
                        }
                        return (false, errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi ngoại lệ và trả về thông báo lỗi
                return (false, $"Exception: {ex.Message}");
            }
        }

        public async Task<Dictionary<string, EmployeeDTO>> GetAllEmployeesCFAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                // Gắn Token vào Header
                if (!string.IsNullOrEmpty(GlobalSession.Token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token);
                }
                // Gửi yêu cầu GET đến Cloud Function
                var response = await client.GetAsync(_getAllEmployeesUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    // Phòng thủ HTML
                    if (jsonResponse.TrimStart().StartsWith("<")) return null;
                    // Cố gắng phân tích JSON trả về
                    var employeesDictionary = JsonConvert.DeserializeObject<Dictionary<string, EmployeeDTO>>(jsonResponse);
                    return employeesDictionary;
                }

                return null;
            }
        }
    }
}
