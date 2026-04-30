using System.Collections.Generic;
using Newtonsoft.Json; // Thay đổi từ System.Text.Json sang Newtonsoft.Json

namespace DTO
{
    public class NhapKhoDTO
    {
        [JsonProperty("ghi_chu")] // Sử dụng [JsonProperty] thay vì [JsonPropertyName]
        public string GhiChu { get; set; }

        [JsonProperty("ngay_nhap")]
        public int NgayNhap { get; set; }

        [JsonProperty("nhanvien_id")]
        public string NhanVienId { get; set; }

        [JsonProperty("thanh_tien")]
        public long TongTien { get; set; }

        [JsonProperty("ds_nl")]
        public Dictionary<string, ChiTietNhapDTO> DanhSachNL { get; set; }
    }

    public class ChiTietNhapDTO
    {
        [JsonProperty("gia_nhap")]
        public long GiaNhap { get; set; }

        [JsonProperty("so_luong")]
        public int SoLuong { get; set; }

        [JsonProperty("thanh_tien")]
        public long ThanhTien { get; set; }
    }
}