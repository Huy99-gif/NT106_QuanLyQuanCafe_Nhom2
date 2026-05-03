using DTO;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FoodDAL
    {
        private static readonly string BaseUrl = "https://us-central1-qlcafe-b621b.cloudfunctions.net/";
        private static readonly HttpClient client = new();
        // Lấy tất cả món để phục vụ việc đếm STT
        public static async Task<Dictionary<string, FoodDTO>> GetAllFoodsCFAsync()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token);
            var response = await client.GetAsync(BaseUrl + "getAllFoods");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Dictionary<string, FoodDTO>>(json) ?? [];
            }
            return [];
        }
        // Thêm món mới
        public static async Task<(bool Success, string Message)> AddFoodCFAsync(object foodData)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token);

                var json = JsonConvert.SerializeObject(foodData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Gọi đúng endpoint addFood mà anh em mình đã viết bên Node.js
                var response = await client.PostAsync(BaseUrl + "addFood", content);
                var resultStr = await response.Content.ReadAsStringAsync();

                return (response.IsSuccessStatusCode, resultStr);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi kết nối khi thêm món: {ex.Message}");
            }
        }
        // 
        public static async Task<(bool Success, string Message)> DeleteFoodCFAsync(string foodId)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token);
            var payload = new { foodId };
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(BaseUrl + "deleteFood", content);
            var resultStr = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, resultStr);
        }
        // Cập nhật món ăn
        public static async Task<(bool Success, string Message)> UpdateFoodCFAsync(string foodId, object updateData)
        {
            try
            {
                // Gán Token xác thực vào Header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSession.Token);

                // Tạo payload khớp với yêu cầu của Node.js (foodId và updateData)
                var payload = new{foodId,updateData};

                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                //Gọi API updateFood
                var response = await client.PostAsync(BaseUrl + "updateFood", content);
                var resultStr = await response.Content.ReadAsStringAsync();

                return (response.IsSuccessStatusCode, resultStr);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi kết nối Server: {ex.Message}");
            }
        }

    }
}