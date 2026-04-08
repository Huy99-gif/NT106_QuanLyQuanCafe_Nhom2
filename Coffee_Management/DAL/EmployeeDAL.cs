using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Net.Http; // Thêm thư viện này ở trên cùng
using Newtonsoft.Json;

namespace DAL
{
    public class EmployeeDAL
    {

        // Cấu hình Firebase Realtime Database
        private IFirebaseConfig dbConfig = new FirebaseConfig
        {
            AuthSecret = "dRepS8RkauZPZRHBfedxTsDTZ6r67VatFSP7LvNw", // Thay bằng Secret của bạn (nếu có)
            BasePath = "https://qlcafe-b621b-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        private IFirebaseClient dbClient;

        private string webApiKey = "AIzaSyBBAJYgrGmwOVvXGyapfqRhbBkKLS6qjaY";

        public EmployeeDAL()
        {
            dbClient = new FireSharp.FirebaseClient(dbConfig);
        }

        public async Task<bool> AddEmployeeAsync(Employee emp)
        {
            try
            {
                using (var http = new HttpClient())
                {
                    var authRequest = new
                    {
                        email = emp.Email,
                        password = emp.Password,
                        returnSecureToken = true
                    };

                    var json = JsonConvert.SerializeObject(authRequest);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Gọi API của Google Identity Toolkit để tạo User
                    var authResponse = await http.PostAsync(
                        $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={webApiKey}",
                        content);

                    if (!authResponse.IsSuccessStatusCode)
                    {
                        string errorMsg = await authResponse.Content.ReadAsStringAsync();
                        // Nếu email đã tồn tại hoặc pass yếu, Firebase sẽ báo lỗi ở đây
                        throw new Exception("Lỗi Firebase Auth: " + errorMsg);
                    }
                }
                SetResponse response = await dbClient.SetAsync("nhan_vien/" + emp.EmployeeId, emp);

                return response.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Dictionary<string, Employee>> GetAllEmployeesAsync()
        {
            try
            {
                // Lấy dữ liệu từ node "NhanVien"
                FirebaseResponse response = await dbClient.GetAsync("nhan_vien");

                // Nếu node chưa tồn tại hoặc trống, trả về null
                if (response.Body == "null") return null;

                // Firebase trả về một Dictionary với Key là ID (nv_001) và Value là object Employee
                return response.ResultAs<Dictionary<string, Employee>>();
            }
            catch
            {
                return null;
            }
        }
    }
}
