using Newtonsoft.Json;

namespace DTO
{
    public class NguyenLieuDTO
    {
        public string Id { get; set; }

        [JsonProperty("ten_nguyen_lieu")]
        public string TenNguyenLieu { get; set; }

        [JsonProperty("gia_nhap")]
        public long GiaNhap { get; set; }

        [JsonProperty("don_vi")]
        public string DonVi { get; set; }

        // Đổi từ int sang double để chứa được số lẻ như 2.2, 1.5 kg...
        [JsonProperty("ton_kho")]
        public double TonKho { get; set; }

        // Đổi từ int sang double
        [JsonProperty("ton_kho_toi_thieu")]
        public double TonKhoToiThieu { get; set; }
    }
}