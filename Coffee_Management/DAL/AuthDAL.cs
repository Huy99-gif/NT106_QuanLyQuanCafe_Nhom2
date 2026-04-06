using DTO;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class AuthDAL
    {
        public async Task<Employee> LoginDAL(string email, string password)
        {
            try
            {
                // 1. Cấu hình Firebase Authentication theo chuẩn thư viện mới
                var config = new FirebaseAuthConfig
                {
                    ApiKey = AppConfig.AuthSecret,         // VD: "AIzaSyD-..." (Lấy từ Firebase Console)
                    AuthDomain = "qlcafe - b621b.firebaseapp.com", // VD: "your-project.firebaseapp.com"
                    Providers = new FirebaseAuthProvider[]
                    {
                        new EmailProvider() // Khai báo sử dụng đăng nhập bằng Email/Password
                    }
                };

                // Khởi tạo Auth Client
                var authClient = new FirebaseAuthClient(config);

                // Thực hiện đăng nhập
                var userCredential = await authClient.SignInWithEmailAndPasswordAsync(email, password);

                // Lấy ID Token bảo mật từ user object sau khi đăng nhập thành công
                string token = await userCredential.User.GetIdTokenAsync();

                // 2. Khởi tạo kết nối Realtime Database, truyền Token vào để được phép đọc dữ liệu
                var firebaseClient = new FirebaseClient(
                    AppConfig.BasePath,
                    new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(token) }
                );

                // 3. Tìm nhân viên trong bảng "nhan_vien" có email trùng khớp
                var queryResult = await firebaseClient
                    .Child("nhan_vien")
                    .OrderBy("email")
                    .EqualTo(email)
                    .OnceAsync<Employee>();

                // 4. Nếu tìm thấy, lấy dữ liệu ra và trả về
                if (queryResult.Count > 0)
                {
                    var firstResult = queryResult.FirstOrDefault()!;
                    Employee loggedInUser = firstResult.Object;

                    // Gán Key của Firebase (VD: nv_001) vào thuộc tính EmployeeId
                    loggedInUser.EmployeeId = firstResult.Key;

                    return loggedInUser;
                }

                return null; // Không tìm thấy email này trong Realtime DB
            }
            catch (Exception ex)
            {
                // Sai mật khẩu, email chưa đăng ký trên Auth, hoặc mất mạng
                //throw new Exception(ex.Message); Thử lỗi để xem chi tiết lỗi bên Authenciation   
                return null;
            }
        }
    }
}