using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    
    public class AuthServiceBUS
    {
        private readonly AuthService authDAL = new AuthService();

        public async Task<(bool IsValid, string Message)> HandlePasswordReset(string email, string newPass, string confirmPass)
        {
            // Nếu mọi thứ ổn ở GUI, gọi xuống DAL để thực thi đẩy lên Cloud
            return await authDAL.UpdateFirebasePassword(email, newPass);
        }
    }
}
