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

namespace BUS
{
    public class EmailCode
    {
        public async Task<(bool IsSuccess, string Code, string Message)> SendVerificationCodeAsync(string toEmail)
        {
            try
            {
                // 1. Tạo mã code ngẫu nhiên 6 số
                Random rand = new Random();
                string randomCode = rand.Next(10000000, 99999999).ToString();

                // 2. Cấu hình email gửi đi
                // Lấy ở:  https://myaccount.google.com/apppasswords
                string fromEmail = "kirak7264@gmail.com";
                string appPassword = "scmp tgwd sbdv anan"; 

                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromEmail, "Hệ thống QLCafe");
                message.To.Add(toEmail);
                message.Subject = "QLCafe - Password Reset Verification Code";
                message.Body = $"Hello, \n\nYour password reset verification code is: {randomCode} \n\nNote: This code is valid for 60 seconds only. After this time, it will expire and you will need to request a new one. \n\nPlease do not share this code with anyone. If you did not request this, please ignore this email. \n\nBest regards, \nQLCafe System";

                // 3. Cấu hình trạm phát SMTP của Google
                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromEmail, appPassword),
                    EnableSsl = true, // Bắt buộc phải có SSL
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                // 4. Bắt đầu gửi (Dùng Async để không đơ màn hình)
                await smtp.SendMailAsync(message);

                // Trả về mã code để lớp GUI cất đi tí nữa so sánh
                return (true, randomCode, "Verification code has been sent successfully! \nPlease check your inbox (and spam folder)");
            }
            catch (Exception ex)
            {
                return (false, "", "Failed to send email: " + ex.Message);
            }
        }
    }
}
