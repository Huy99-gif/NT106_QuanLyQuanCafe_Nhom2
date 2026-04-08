using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Text.RegularExpressions;

namespace BUS
{
    public class EmployeeBUS
    {
        // Khởi tạo đối tượng DAL để giao tiếp với Firebase
        private EmployeeDAL employeeDal = new EmployeeDAL();

        /// <summary>
        /// Hàm xử lý thêm nhân viên mới
        /// </summary>
        public async Task<bool> AddEmployeeAsync(Employee emp)
        {
            try
            {
                // 1. Kiểm tra nghiệp vụ (Validation)
                if (string.IsNullOrWhiteSpace(emp.Email))
                    throw new Exception("Email không được để trống.");

                if (!IsValidEmail(emp.Email))
                    throw new Exception("Định dạng Email không hợp lệ.");

                if (string.IsNullOrWhiteSpace(emp.Password) || emp.Password.Length < 8)
                    throw new Exception("Mật khẩu phải có ít nhất 8 ký tự.");

                if (string.IsNullOrWhiteSpace(emp.FullName))
                    throw new Exception("Họ tên không được để trống.");

                if (string.IsNullOrWhiteSpace(emp.PhoneNumber))
                    throw new Exception("Số điện thoại không được để trống.");

                // 2. Tự động sinh mã nhân viên (nv_xxx)
                emp.EmployeeId = await GenerateNextEmployeeId();

                // 3. Thiết lập các giá trị mặc định
                emp.Status = "active"; // Mặc định là đang hoạt động

                // Nếu không nhập link ảnh, dùng ảnh mặc định
                if (string.IsNullOrWhiteSpace(emp.AvatarUrl))
                {
                    emp.AvatarUrl = "";
                }

                // 4. Gọi xuống DAL để lưu dữ liệu
                return await employeeDal.AddEmployeeAsync(emp);
            }
            catch (Exception ex)
            {
                // Đẩy lỗi về phía GUI để hiển thị MessageBox
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Hàm tự động tạo mã nhân viên tiếp theo dựa trên dữ liệu hiện có
        /// </summary>
        public async Task<string> GenerateNextEmployeeId()
        {
            // Lấy danh sách tất cả nhân viên từ Firebase
            var allEmployees = await employeeDal.GetAllEmployeesAsync();

            // Nếu chưa có nhân viên nào, bắt đầu bằng nv_001
            if (allEmployees == null || allEmployees.Count == 0)
            {
                return "nv_001";
            }
            try
            {
                // Lấy danh sách các Key (nv_001, nv_002,...)
                var keys = allEmployees.Keys;

                // Tách phần số, tìm số lớn nhất
                int maxNumber = keys
                    .Select(k => {
                        // Tìm các con số trong chuỗi (ví dụ "nv_015" -> "015")
                        string numberPart = Regex.Match(k, @"\d+").Value;
                        return int.TryParse(numberPart, out int n) ? n : 0;
                    })
                    .Max();

                // Mã tiếp theo = Số lớn nhất + 1, định dạng thành 3 chữ số (D3)
                int nextNumber = maxNumber + 1;
                return $"nv_{nextNumber:D3}";
            }
            catch
            {
                // Trường hợp có lỗi định dạng mã trong DB, fallback về một mã ngẫu nhiên hoặc mặc định
                return "nv_" + DateTime.Now.Ticks.ToString().Substring(10);
            }
        }

        /// <summary>
        /// Hàm kiểm tra định dạng email bằng Regex
        /// </summary>
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
