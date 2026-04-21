using DTO;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class FoodDAL
    {
        private readonly string FireBaseUrl = "https://qlcafe-b621b-default-rtdb.asia-southeast1.firebasedatabase.app/";
        private readonly FirebaseClient _client;

        public FoodDAL()
        {
            _client = new FirebaseClient(FireBaseUrl);
        }

        // Lấy tất cả món để phục vụ việc đếm STT
        public async Task<List<FoodDTO>> GetAllFoodsAsync()
        {
            try
            {
                var foods = await _client.Child("mon_uong").OnceAsync<FoodDTO>();
                return foods.Select(item => new FoodDTO
                {
                    Id = item.Key,
                    TenMon = item.Object.TenMon,
                    Gia = item.Object.Gia,
                    MoTa = item.Object.MoTa,
                    Loai = item.Object.Loai,
                    HinhAnhUrl = item.Object.HinhAnhUrl,
                    HienThi = item.Object.HienThi,
                    ConHang = item.Object.ConHang
                }).ToList();
            }
            catch { return new List<FoodDTO>(); }
        }

        // Lưu món ăn với Key tùy chỉnh (mon_xxx)
        public async Task<bool> InsertFoodAsync(FoodDTO food)
        {
            try
            {
                await _client.Child("mon_uong").Child(food.Id).PutAsync(food);
                return true;
            }
            catch { return false; }
        }
        public async Task<bool> DeleteFoodAsync(string id)
        {
            try
            {
                await _client
                    .Child("mon_uong")
                    .Child(id)
                    .DeleteAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa Firebase: {ex.Message}");
                return false;
            }
        }
    }
}