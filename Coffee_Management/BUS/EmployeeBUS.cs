using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class EmployeeBUS
    {
        private readonly EmployeeDAL _employeeDal = new EmployeeDAL();

        public async Task<bool> AddEmployeeAsync(EmployeeDTO emp)
        {
            if (Validation.IsAnyEmpty(emp.Email, emp.Password, emp.FullName, emp.PhoneNumber, emp.HireDate, emp.Role))
            {
                throw new Exception("Please fill in all the information");
            }
            else
            {
                if (!Validation.IsValidEmail(emp.Email))
                {
                    throw new Exception("Invalid email format. Please enter a valid email address.");
                }
                if (!Validation.IsValidPassword(emp.Password))
                {
                    throw new Exception("Password must be at least 8 characters long, and include an uppercase letter, a lowercase letter, a number, and a special character.");
                }
                if (!Validation.IsValidPhoneNumber(emp.PhoneNumber))
                {
                    throw new Exception("Invalid phone number format. Please enter a valid phone number.");
                }
                if (!Validation.IsValidHireDate(emp.HireDate))
                {
                    throw new Exception("Invalid hire date format. Please enter a valid date (e.g., YYYY-MM-DD).");
                }
            }
            // Gọi DAL kết nối tới Cloud Functions
            var result = await _employeeDal.AddEmployeeCFAsync(emp);

            // Nếu Server trả về lỗi (Ví dụ: Password yếu, Email đã tồn tại)
            if (!result.Success)
            {
                throw new Exception(result.Message);
            }

            return true;
        }

        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var dict = await _employeeDal.GetAllEmployeesCFAsync();

            if (dict == null) return new List<EmployeeDTO>();

            // Chuyển Dictionary thành List và gán Key của Firebase vào EmployeeId
            var list = dict.Select(x => {
                x.Value.EmployeeId = x.Key; // Lấy 'nv_001' làm ID
                return x.Value;
            }).ToList();

            return list;
        }

        public async Task<(bool Success, string Message)> UpdateEmployeeAsync(string empId, EmployeeDTO updateData)
        {
            if (Validation.IsAnyEmpty(empId))
                return (false, "Employee ID not found!");
            if (Validation.IsAnyEmpty(updateData.FullName, updateData.PhoneNumber, updateData.Role, updateData.Status))
            {
                return (false, "Please fill in all required information.");
            }
            //Ràng buộc định dạng dữ liệu
            if (!Validation.IsValidPhoneNumber(updateData.PhoneNumber))
            {
                return (false, "Invalid phone number format. Please enter a valid phone number.");
            }
            return await _employeeDal.UpdateEmployeeCFAsync(empId, updateData);
        }

        public async Task<(bool Success, string Message)> LockEmployeeAsync(string empId, string authUid)
        {
            if (Validation.IsAnyEmpty(empId, authUid))
                return (false, "Invalid employee data!");
            return await _employeeDal.LockEmployeeCFAsync(empId, authUid);
        }
    }
}