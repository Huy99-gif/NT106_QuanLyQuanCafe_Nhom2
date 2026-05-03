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
        private static readonly string BaseUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/";
        //Thêm thông tin nhân viên
        public static async Task<(bool Success, string Message)> AddEmployeeCFAsync(EmployeeDTO emp)
        {
            try
            {
                // Gắn Token vào Header 
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token ?? "");
                // Chuyển đối tượng EmployeeDTO thành JSON
                var content = new StringContent(JsonConvert.SerializeObject(emp), Encoding.UTF8, "application/json");
                // Gửi yêu cầu POST đến Cloud Function
                var response = await client.PostAsync(BaseUrl + "addEmployee", content);
                string resultStr = await response.Content.ReadAsStringAsync();

                // Phòng thủ: Kiểm tra nếu Server sập hoặc trả về HTML
                if (resultStr.TrimStart().StartsWith('<'))
                {
                    return (false, $"Lỗi Server ({response.StatusCode}): Bị từ chối hoặc URL không hợp lệ.");
                }
                // Cố gắng phân tích JSON trả về
                dynamic? result = JsonConvert.DeserializeObject(resultStr);

                if (response.IsSuccessStatusCode)
                {
                    return (true, "Thành công");
                }
                else
                {
                    string errorMessage = "Lỗi Server";
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
                return (false, $"Lỗi ngoại lệ: {ex.Message}");
            }
        }
        // Lấy tất cả nhân viên
        public static async Task<Dictionary<string, EmployeeDTO>> GetAllEmployeesCFAsync()
        {
            // Gắn Token vào Header
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token ?? "");
            // Gửi yêu cầu GET đến Cloud Function
            var response = await client.GetAsync(BaseUrl + "getAllEmployees");

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
        // Cập nhật thông tin nhân viên
        public static async Task<(bool Success, string Message)> UpdateEmployeeCFAsync(string empId, EmployeeDTO updateData)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token);

            var payload = new { employeeId = empId, updateData };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(BaseUrl + "updateEmployee", content);
            var resultStr = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return (true, "Cập nhật thành công!");
            return (false, "Lỗi Server: " + resultStr);
        }
        // Khóa tài khoản nhân viên
        public static async Task<(bool Success, string Message)> LockEmployeeCFAsync(string empId, string authUid)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token);

            var payload = new { empId, authUid };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(BaseUrl + "lockEmployee", content);
            var resultStr = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode) return (true, "Tài khoản đã bị khóa!");
            return (false, "Lỗi Server: " + resultStr);
        }
        // Xóa tài khoản nhân viên
        public static async Task<(bool Success, string Message)> DeleteEmployeeCFAsync(string empId, string authUid)
        {
            // Gắn Token xác thực quyền quản lý
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token);

            var payload = new { empId, authUid };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(BaseUrl + "deleteEmployee", content);
            var resultStr = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return (true, "Đã xóa nhân viên thành công!");
            return (false, "Lỗi Server: " + resultStr);
        }
    }
}
