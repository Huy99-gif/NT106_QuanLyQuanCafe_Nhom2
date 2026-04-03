using System;

namespace QuanLyQuanCafe.Core
{
    public static class DatabaseConfig
    {
        // 1. Dùng cho Firebase Authentication (Xác thực tài khoản)
        // Lấy tại: Project Settings (Cài đặt dự án) > Thẻ General > Mục Web API Key
        public const string WebApiKey = "AIzaSyBBAJYgrGmwOVvXGyapfqRhbBkKLS6qjaY";

        // 2. Dùng cho Firebase Realtime Database (Truy xuất dữ liệu)
        // Lấy tại: Trang Realtime Database > Copy cái link ở đầu trang
        public const string DatabaseUrl = "https://qlcafe-b621b-default-rtdb.asia-southeast1.firebasedatabase.app/";

    }
}