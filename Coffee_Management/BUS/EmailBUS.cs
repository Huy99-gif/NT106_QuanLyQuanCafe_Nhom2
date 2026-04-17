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
    public class EmailBUS
    {
        // URL lấy từ Firebase Console sau khi deploy hàm sendVerificationEmail
        public static async Task<(bool IsSuccess, string? Code, string Message)> ProcessPasswordResetAsync(string email)
        {
            try
            {
                if (!Validation.IsAnyEmpty(email))
                {
                    if (!Validation.IsValidEmail(email))
                        return (false, "", "Email không hợp lệ.\nVui lòng nhập lại địa chỉ email!");
                }
                else
                {
                    return (false, "", "Vui lòng nhập lại địa chỉ email!");
                }
                // DAL đi kiểm tra email
                var (Exists, Message) = await EmailDAL.CheckEmailAPI(email);

                // Nếu email không tồn tại -> Chặn lại ngay lập tức
                if (Exists == false)
                {
                    return (false, "", Message);
                }

                //Vượt qua bài kiểm tra -> DAL đi gửi code
                var sendResult = await EmailDAL.SendOtpAPI(email);
                // Trả kết quả cuối cùng (kèm mã OTP) lên GUI
                return sendResult;
            }
            catch (Exception ex)
            {
                return (false, "", "Lỗi trong quá trình gửi mã xác thực: " + ex.Message);
            }
        }
    }
}
