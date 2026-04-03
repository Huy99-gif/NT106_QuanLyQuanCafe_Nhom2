using QuanLyQuanCafe.DTO;

public static class SessionContext
{
    // Giả sử bạn đã có NhanVienDTO ở thư mục DTO
    public static NhanVienDTO NhanVienHienTai { get; set; }

    // Hàm kiểm tra xem đã đăng nhập chưa
    public static bool IsLoggedIn()
    {
        return NhanVienHienTai != null;
    }
}
