using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class AuthBUS
    {
        private AuthDAL authDAL = new AuthDAL();

        public async Task<(bool IsSuccess, string Message, EmployeeDTO? UserData)> LoginBUS(string email, string password)
        {
            try
            {
                //Kiểm tra định dạng email nếu người dùng nhập
                if (!Validation.IsAnyEmpty(email))
                {
                    if (!Validation.IsValidEmail(email))
                        return (false, "Invalid email format. Please enter a valid email address.", null);
                }
                else
                {
                    return (false, "Please enter your email address.", null);
                }
                // Kiểm tra độ mạnh của mật khẩu nếu người dùng nhập
                if (!Validation.IsAnyEmpty(password))
                {
                    if (!Validation.IsValidPassword(password))
                    {
                        return (false, "Password must be at least 8 characters long, and include an uppercase letter, a lowercase letter, a number, and a special character.", null);
                    }
                }
                else
                {
                    return (false, "Please enter your password.", null);
                }
                // 1. Gọi DAL thực hiện đăng nhập
                var loginResult = await authDAL.LoginDAL(email, password);
                // 2. Xử lý các nghiệp vụ sau khi có kết quả từ Database
                if (loginResult.User == null)
                {
                    return (false, "Invalid email or password.", null);
                }

                // 3. KIỂM TRA NGHIỆP VỤ: Trạng thái tài khoản
                if (loginResult.User.Status != "active")
                {
                    return (false, "Your account has been locked or disabled. Please contact your Manager.", null);
                }
                GlobalSession.Token = loginResult.Token;
                GlobalSession.CurrentUser = loginResult.User;
                // 5. Nếu vượt qua mọi cửa ải -> Thành công
                return (true, "Login successful.", loginResult.User);
            }
            catch (System.Exception ex)
            {
                // 4. Xử lý lỗi hệ thống
                return (false, $"An error occurred during login: {ex.Message}", null);
            }
        }
    }
}
