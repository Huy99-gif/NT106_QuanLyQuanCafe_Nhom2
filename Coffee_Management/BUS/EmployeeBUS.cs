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

        public async Task<bool> AddEmployeeAsync(Employee emp)
        {
            // Gọi DAL kết nối tới Cloud Functions
            var result = await _employeeDal.AddEmployeeCFAsync(emp);

            // Nếu Server trả về lỗi (Ví dụ: Password yếu, Email đã tồn tại)
            if (!result.Success)
            {
                throw new Exception(result.Message);
            }

            return true;
        }

        public async Task<Dictionary<string, Employee>> GetAllEmployeesAsync()
        {
            return await _employeeDal.GetAllEmployeesCFAsync();
        }
    }
}