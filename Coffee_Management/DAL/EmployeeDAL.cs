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
        private static readonly HttpClient client = new();
        // Khai báo các Endpoints
        private static readonly string _addEmployeeUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/addEmployee";
        private static readonly string _getAllEmployeesUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/getAllEmployees";
        private static readonly string _updateEmployeeUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/updateEmployee";
        private static readonly string _lockEmployeeUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/lockEmployee";
        public static async Task<(bool Success, string Message)> AddEmployeeCFAsync(EmployeeDTO emp)
        {
            try
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
                if (resultStr.TrimStart().StartsWith('<'))
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
            catch (Exception ex)
            {
                // Bắt lỗi ngoại lệ và trả về thông báo lỗi
                return (false, $"Exception: {ex.Message}");
            }
        }

        public static async Task<Dictionary<string, EmployeeDTO>> GetAllEmployeesCFAsync()
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
                if (jsonResponse.TrimStart().StartsWith('<'))
                    return [];
                // Cố gắng phân tích JSON trả về
                var employeesDictionary = JsonConvert.DeserializeObject<Dictionary<string, EmployeeDTO>>(jsonResponse);
                return employeesDictionary ?? [];
            }

            return [];
        }

        public static async Task<(bool Success, string Message)> UpdateEmployeeCFAsync(string empId, EmployeeDTO updateData)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token);

            var payload = new { employeeId = empId, updateData };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(_updateEmployeeUrl, content);
            var resultStr = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return (true, "Updated successfull!");
            return (false, "Server Error: " + resultStr);
        }

        public static async Task<(bool Success, string Message)> LockEmployeeCFAsync(string empId, string authUid)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token);

            var payload = new { empId, authUid };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(_lockEmployeeUrl, content);
            var resultStr = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode) return (true, "Account Locked!");
            return (false, "Server Error: " + resultStr);
        }
    }
}
