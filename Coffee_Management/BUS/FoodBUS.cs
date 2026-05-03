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
        // Lấy danh sách món ăn để hiển thị lên DataGridView
        public static async Task<List<FoodDTO>> GetListFoods()
        {
            var dict = await FoodDAL.GetAllFoodsCFAsync();
            return [.. dict.Select(x => {
            x.Value.Id = x.Key;
            return x.Value;
            })];
        }
        // Xóa món ăn dựa trên ID
        public static async Task<(bool Success, string Message)> DeleteFood(string id)
        {
            if (Validation.IsAnyEmpty(id)) 
                return (false, "Không tìm thấy mã món ăn!");
            return await FoodDAL.DeleteFoodCFAsync(id);
        }
        public static async Task<(bool Success, string Message)> UpdateFood(FoodDTO food)
        {
            if (Validation.IsAnyEmpty(food.Id))
            {
                return (false, "Không tìm thấy mã món ăn cần cập nhật!");
            }

            if (Validation.IsAnyEmpty(food.TenMon))
            {
                return (false, "Tên món không được để trống!");
            }

            if (food.Gia < 0)
            {
                return (false, "Giá món ăn không hợp lệ!");
            }

            return await FoodDAL.UpdateFoodCFAsync(food.Id ?? "", food);
        }
        // Thêm món ăn mới
        public static async Task<(bool Success, string Message)> AddFood(FoodDTO food)
        {
            // Kiểm tra nghiệp vụ: Tên món không được trống
            if (Validation.IsAnyEmpty(food.TenMon))
            {
                return (false, "Tên món không được để trống!");
            }

            // Kiểm tra giá: Không được âm
            if (food.Gia < 0)
            {
                return (false, "Giá món ăn không hợp lệ!");
            }

            return await FoodDAL.AddFoodCFAsync(food);
        }
    }
}