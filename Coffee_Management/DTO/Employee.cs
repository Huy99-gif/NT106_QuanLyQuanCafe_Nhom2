using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Employee
    {
        // Không tạo thêm thuộc tính cho EmployeeId vì nó không cần thiết
        [JsonIgnore]
        public string? EmployeeId { get; set; }
        // Ánh xạ các thuộc tính JSON với tên khác nhau
        [JsonProperty("avatar_url")]
        public string? AvatarUrl { get; set; }

        [JsonIgnore] // RẤT QUAN TRỌNG: Chỉ dùng để tạo Auth, không đẩy lên Database
        public string? Password { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("ho_ten")]
        public string? FullName { get; set; }

        [JsonProperty("ngay_vao_lam")]
        public string? HireDate { get; set; }

        [JsonProperty("so_dien_thoai")]
        public string? PhoneNumber { get; set; }

        [JsonProperty("trang_thai")]
        public string? Status { get; set; }

        [JsonProperty("vai_tro")]
        public string? Role { get; set; }
    }
}
