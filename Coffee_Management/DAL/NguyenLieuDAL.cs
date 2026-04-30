using DTO;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class NguyenLieuDAL
    {
        private readonly string FireBaseUrl = "https://qlcafe-b621b-default-rtdb.asia-southeast1.firebasedatabase.app/";
        private readonly FirebaseClient _client;

        public NguyenLieuDAL()
        {
            _client = new FirebaseClient(FireBaseUrl);
        }

        // Lấy tất cả nguyên liệu
        public async Task<List<NguyenLieuDTO>> GetAllNguyenLieuAsync()
        {
            // Bỏ try-catch ở đây để lỗi (nếu có) bị đẩy ngược lên trên GUI
            var data = await _client.Child("nguyen_lieu").OnceAsync<NguyenLieuDTO>();

            return data.Select(item => new NguyenLieuDTO
            {
                Id = item.Key,
                TenNguyenLieu = item.Object.TenNguyenLieu,
                GiaNhap = item.Object.GiaNhap,
                DonVi = item.Object.DonVi,
                TonKho = item.Object.TonKho,
                TonKhoToiThieu = item.Object.TonKhoToiThieu
            }).ToList();
        }
    }
}