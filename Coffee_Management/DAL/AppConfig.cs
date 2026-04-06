namespace DAL
{
    public class AppConfig
    {
        // 1. Dùng cho Firebase Authentication (Xác thực tài khoản)
        // Lấy tại: Project Settings (Cài đặt dự án) > Thẻ General > Mục Web API Key
        public const string AuthSecret = "AIzaSyBBAJYgrGmwOVvXGyapfqRhbBkKLS6qjaY";

        // 2. Dùng cho Firebase Realtime Database (Truy xuất dữ liệu)
        // Lấy tại: Trang Realtime Database > Copy cái link ở đầu trang
        public const string BasePath = "https://qlcafe-b621b-default-rtdb.asia-southeast1.firebasedatabase.app/";
    }
}
