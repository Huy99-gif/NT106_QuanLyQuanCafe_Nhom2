using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class EmailCodeBUS
    {
        // URL lấy từ Firebase Console sau khi deploy hàm sendVerificationEmail
        private EmailCodeDAL _emailDAL = new EmailCodeDAL();
        public async Task<(bool IsSuccess, string? Code, string Message)> ProcessPasswordResetAsync(string email)
        {
            try
            {
                if (!Validation.IsAnyEmpty(email))
                {
                    if (!Validation.IsValidEmail(email))
                        return (false, "", "Invalid email format. Please enter a valid email address.");
                }
                else
                {
                    return (false, "", "Please enter your email address.");
                }
                // DAL đi kiểm tra email
                var checkResult = await _emailDAL.CheckEmailAPI(email);

                // Nếu email không tồn tại -> Chặn lại ngay lập tức
                if (checkResult.Exists == false)
                {
                    return (false, "", checkResult.Message);
                }

                //Vượt qua bài kiểm tra -> DAL đi gửi code
                var sendResult = await _emailDAL.SendOtpAPI(email);
                // Trả kết quả cuối cùng (kèm mã OTP) lên GUI
                return sendResult;
            }
            catch (Exception ex)
            {
                return (false, "", "An error occurred during sending code: " + ex.Message);
            }
        }
    }
}
