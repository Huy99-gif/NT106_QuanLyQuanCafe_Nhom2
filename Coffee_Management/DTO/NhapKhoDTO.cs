using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DTO
{
    public class NhapKhoDTO
    {
        [JsonPropertyName("ghi_chu")]
        public string GhiChu { get; set; }

        [JsonPropertyName("ngay_nhap")]
        public int NgayNhap { get; set; }

        [JsonPropertyName("nhanvien_id")]
        public string NhanVienId { get; set; }

        [JsonPropertyName("thanh_tien")]
        public long TongTien { get; set; }

        [JsonPropertyName("ds_nl")]
        public Dictionary<string, ChiTietNhapDTO> DanhSachNL { get; set; }
    }

    public class ChiTietNhapDTO
    {
        [JsonPropertyName("gia_nhap")]
        public long GiaNhap { get; set; }

        [JsonPropertyName("so_luong")]
        public int SoLuong { get; set; }

        [JsonPropertyName("thanh_tien")]
        public long ThanhTien { get; set; }
    }
}