using System;
using System.Threading.Tasks;
using QuanLyQuanCafe.DAL;
using QuanLyQuanCafe.Core;
namespace QuanLyQuanCafe.DTO
{
    public class NhanVienBLL
    {
        private NhanVienDAL _nhanVienDAL = new NhanVienDAL();

        public async Task<NhanVienDTO> DangNhap(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Vui lòng nhập đầy đủ Email và Mật khẩu!");

            try
            {
                var authLink = await _nhanVienDAL.LoginAsync(email, password);

                if (authLink != null)
                {
                    
                    var nhanVien = await _nhanVienDAL.GetThongTinNhanVienAsync(email);
                    return nhanVien;
                }
                return null;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("INVALID_LOGIN_CREDENTIALS") || ex.Message.Contains("INVALID_PASSWORD"))
                    throw new Exception("Email hoặc mật khẩu không chính xác!");
                throw new Exception("Lỗi đăng nhập: Kiểm tra lại kết nối mạng hoặc thông tin.");
            }
        }

        public async Task<bool> DangKy(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Vui lòng nhập đầy đủ Email và Mật khẩu!");

            if (password.Length < 6)
                throw new Exception("Mật khẩu phải có ít nhất 6 ký tự!");

            try
            {
                await _nhanVienDAL.RegisterAsync(email, password);
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("EMAIL_EXISTS"))
                    throw new Exception("Email này đã được sử dụng!");
                throw new Exception("Lỗi đăng ký: " + ex.Message);
            }
        }

        public async Task<bool> QuenMatKhau(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Vui lòng nhập Email để khôi phục mật khẩu!");

            try
            {
                await _nhanVienDAL.ResetPasswordAsync(email);
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("EMAIL_NOT_FOUND"))
                    throw new Exception("Không tìm thấy tài khoản với Email này!");
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public async Task<NhanVienDTO> LayThongTinNhanVien(string email)
        {
            // Xử lý logic: Rào chắn nếu ai đó truyền email rỗng
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email không hợp lệ để tìm thông tin!");

            // Gọi DAL thực thi công việc
            return await _nhanVienDAL.GetThongTinNhanVienAsync(email);
        }
    }
}