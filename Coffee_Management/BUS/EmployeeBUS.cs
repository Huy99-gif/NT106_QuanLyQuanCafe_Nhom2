using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class EmployeeBUS
    {

        public static async Task<bool> AddEmployeeAsync(EmployeeDTO emp)
        {
            if (Validation.IsAnyEmpty(emp.Email, emp.Password, emp.FullName, emp.PhoneNumber, emp.HireDate, emp.Role))
            {
                throw new Exception("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                if (!Validation.IsValidEmail(emp.Email))
                {
                    throw new Exception("Địa chỉ email không hợp lệ.\nVui lòng nhập lại địa chỉ email!");
                }
                if (!Validation.IsValidPassword(emp.Password))
                {
                    throw new Exception("Mật khẩu phải dài ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, chữ số và một ký tự đặc biệt.");
                }
                if (!Validation.IsValidPhoneNumber(emp.PhoneNumber))
                {
                    throw new Exception("Số điện thoại không hợp lệ.\nVui lòng nhập lại số điện thoại hợp lệ!");
                }
                if (!Validation.IsValidHireDate(emp.HireDate))
                {
                    throw new Exception("Ngày bắt đầu làm việc không hợp lệ.\nVui lòng nhập lại ngày hợp lệ (ví dụ: YYYY-MM-DD)!");
                }
            }
            // Gọi DAL kết nối tới Cloud Functions
            var (Success, Message) = await EmployeeDAL.AddEmployeeCFAsync(emp);

            // Nếu Server trả về lỗi (Ví dụ: Password yếu, Email đã tồn tại)
            if (!Success)
            {
                throw new Exception(Message);
            }

            return true;
        }

        public static async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var dict = await EmployeeDAL.GetAllEmployeesCFAsync();

            // Nếu Server trả về null (Không có nhân viên nào hoặc lỗi kết nối), trả về List rỗng
            if (dict == null) 
                return [];

            // Chuyển Dictionary thành List và gán Key của Firebase vào EmployeeId
            var list = dict.Select(x => {
                x.Value.EmployeeId = x.Key; // Lấy 'nv_001' làm ID
                return x.Value;
            }).ToList();

            return list;
        }

        public static async Task<(bool Success, string Message)> UpdateEmployeeAsync(string empId, EmployeeDTO updateData)
        {
            if (Validation.IsAnyEmpty(empId))
                return (false, "Không tìm thấy mã nhân viên.");
            if (Validation.IsAnyEmpty(updateData.FullName, updateData.PhoneNumber, updateData.Role, updateData.Status))
            {
                return (false, "Vui lòng điền đầy đủ thông tin bắt buộc.");
            }
            //Ràng buộc định dạng dữ liệu
            if (!Validation.IsValidPhoneNumber(updateData.PhoneNumber))
            {
                return (false, "Số điện thoại không hợp lệ.\nVui lòng nhập lại số điện thoại hợp lệ!");
            }
            return await  EmployeeDAL.UpdateEmployeeCFAsync(empId, updateData);
        }

        public static async Task<(bool Success, string Message)> LockEmployeeAsync(string empId, string authUid)
        {
            if (Validation.IsAnyEmpty(empId, authUid))
                return (false, "Không tìm thấy mã nhân viên hoặc mã xác thực.");
            return await EmployeeDAL.LockEmployeeCFAsync(empId, authUid);
        }
    }
}