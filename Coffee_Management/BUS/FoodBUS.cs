using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class FoodBUS
    {
        private readonly FoodDAL _foodDAL = new FoodDAL();

        private async Task<string> CreateAutoId()
        {
            var list = await _foodDAL.GetAllFoodsAsync();
            if (list == null || list.Count == 0) return "mon_001";

            // Lấy danh sách các số từ ID (mon_001 -> 1)
            var ids = list.Select(f => {
                int.TryParse(f.Id.Replace("mon_", ""), out int num);
                return num;
            });

            int nextNumber = ids.Max() + 1;
            return $"mon_{nextNumber:D3}"; // D3 giúp định dạng 1 thành 001
        }

        public async Task<(bool Success, string Message)> AddNewFood(FoodDTO food)
        {
            // 1. Validate dữ liệu
            if (string.IsNullOrWhiteSpace(food.TenMon))
                return (false, "Tên món không được để trống!");

            // 2. Tạo ID tự động
            food.Id = await CreateAutoId();

            // 3. Gọi DAL lưu vào Firebase
            bool result = await _foodDAL.InsertFoodAsync(food);

            if (result) return (true, $"Thêm thành công món {food.Id}!");
            return (false, "Đã xảy ra lỗi khi lưu vào Database.");
        }
    }
}