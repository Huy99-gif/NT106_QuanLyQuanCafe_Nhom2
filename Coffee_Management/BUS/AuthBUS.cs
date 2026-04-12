using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class AuthBUS
    {
        private AuthDAL authDAL = new AuthDAL();

        public async Task<(bool IsSuccess, string Message, Employee? UserData)> LoginBUS(string email, string password)
        {
            try
            {
                // 1. Gọi DAL thực hiện đăng nhập
                Employee? user = await authDAL.LoginDAL(email, password);

                // 2. Xử lý các nghiệp vụ sau khi có kết quả từ Database
                if (user == null)
                {
                    return (false, "Invalid email or password.", null);
                }

                // 3. KIỂM TRA NGHIỆP VỤ: Trạng thái tài khoản
                if (user.Status != "active")
                {
                    return (false, "Your account has been locked or disabled. Please contact your Manager.", null);
                }

                // 5. Nếu vượt qua mọi cửa ải -> Thành công
                return (true, "Login successful.", user);
            }
            catch (System.Exception ex)
            {
                // 4. Xử lý lỗi hệ thống
                return (false, $"An error occurred during login: {ex.Message}", null);
            }
        }
    }
}
