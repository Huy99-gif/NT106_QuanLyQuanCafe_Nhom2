using DTO;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http; // Thêm thư viện này ở trên cùng
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    public class EmployeeDAL
    {

        // Khai báo các Endpoints
        private readonly string _addEmployeeUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/addEmployeee";
        private readonly string _getAllEmployeesUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/getAllEmployees";
        // Mã bí mật phải khớp với file index.js trên Cloud Functions
        private readonly string? _secretKey = ConfigurationManager.AppSettings["MANAGER_SECRET_KEY"];
        public async Task<(bool Success, string Message)> AddEmployeeCFAsync(Employee emp)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-manager-secret", _secretKey);

                var content = new StringContent(JsonConvert.SerializeObject(emp), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(_addEmployeeUrl, content);
                dynamic? result = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                if (response.IsSuccessStatusCode)
                {
                    return (true, "Success");
                }
                else
                {
                    // Gán sẵn thông báo lỗi mặc định
                    string errorMessage = "Internal Server Error";

                    // Phải kiểm tra result có tồn tại không trước khi làm việc khác
                    if (result != null)
                    {
                        // Ưu tiên lấy biến message nếu server có trả về
                        if (result.message != null)
                        {
                            errorMessage = (string)result.message;
                        }
                        //Nếu không có message, thử lấy biến error
                        else if (result.error != null)
                        {
                            errorMessage = (string)result.error;
                        }
                    }
                    return (false, errorMessage);
                }
            }
        }

        public async Task<Dictionary<string, Employee>> GetAllEmployeesCFAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-manager-secret", _secretKey);

                var response = await client.GetAsync(_getAllEmployeesUrl);

                if (response.IsSuccessStatusCode)
                {
                    //Đọc nội dung phản hồi từ Server dưới dạng chuỗi thô 
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    //Chuyển đổi chuỗi JSON thành Dictionary object
                    var employeesDictionary = JsonConvert.DeserializeObject<Dictionary<string, Employee>>(jsonResponse);
                    //Trả về kết quả
                    return employeesDictionary;
                }
                return null;
            }
        }
    }
}
