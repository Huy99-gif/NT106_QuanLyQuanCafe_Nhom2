using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    
    public class AuthServiceBUS
    {
        private readonly AuthServiceDAL authDAL = new AuthServiceDAL();

        public async Task<(bool IsValid, string Message)> HandlePasswordReset(string email, string newPass, string confirmPass)
        {
            if (Validation.IsAnyEmpty(newPass, confirmPass))
            {
                return (false, "Please enter your new password and confirm password fully.");
            }
            if (!Validation.IsAnyEmpty(newPass, confirmPass))
            {
                if (!Validation.IsValidPassword(newPass))
                {
                    return (false, "Password must be at least 8 characters long, and include an uppercase letter, a lowercase letter, a number, and a special character.\",\r\n                                \"Weak Password");
                }
            }
            if (newPass != confirmPass)
            {
                return (false, "Passwords do not match. Please try again.");
            }
            else
            // Nếu mọi thứ ổn ở GUI, gọi xuống DAL để thực thi đẩy lên Cloud
            return await authDAL.UpdateFirebasePassword(email, newPass);
        }
    }
}
