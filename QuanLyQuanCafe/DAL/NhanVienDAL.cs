using Firebase.Auth;
using Firebase.Database; // Thêm cái này
using Firebase.Database.Query; // Thêm cái này
using QuanLyQuanCafe.Core;
using QuanLyQuanCafe.DTO; // Để dùng NhanVienDTO
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAL
{
    public class NhanVienDAL
    {
        private FirebaseAuthProvider _authProvider;
        private FirebaseClient _dbClient; // Thêm biến này để làm việc với Realtime DB

        public NhanVienDAL()
        {
            // 1. Khởi tạo Auth (Như cũ)
            _authProvider = new FirebaseAuthProvider(new FirebaseConfig(DatabaseConfig.WebApiKey));

            // 2. Khởi tạo Database Client (Thêm mới)
            // Thay link database của bạn vào đây
            _dbClient = new FirebaseClient(DatabaseConfig.DatabaseUrl);
        }

        // --- PHẦN 1: AUTHENTICATION (Xác thực Email/Pass) ---

        public async Task<FirebaseAuthLink> LoginAsync(string email, string password)
        {
            return await _authProvider.SignInWithEmailAndPasswordAsync(email, password);
        }

        // Lấy thông tin Manager/Staff

        public async Task<NhanVienDTO> GetThongTinNhanVienAsync(string email)
        {
            try
            {
                // Yêu cầu Firebase lọc trực tiếp bằng OrderBy và EqualTo
                var users = await _dbClient
                    .Child("nhan_vien")
                    .OrderBy("email") // Sắp xếp theo cột email
                    .EqualTo(email)   // Chỉ lấy những ai có email khớp
                    .OnceAsync<NhanVienDTO>();

                // Lúc này danh sách tải về chỉ có đúng 1 người (hoặc rỗng nếu sai email)
                var result = users.FirstOrDefault();

                return result?.Object;
            }
            catch (Exception ex)
            {
                // Nên log lỗi ra thay vì "nuốt" lỗi âm thầm, để sau này dễ sửa lỗi mạng
                Console.WriteLine("Lỗi truy vấn Firebase: " + ex.Message);
                return null;
            }
        }

        // Các hàm ResetPassword giữ nguyên như cũ của bạn.
        public async Task<FirebaseAuthLink> RegisterAsync(string email, string password)

        {
            return await _authProvider.CreateUserWithEmailAndPasswordAsync(email, password);

        }
        // Hàm gửi email đặt lại mật khẩu
        public async Task ResetPasswordAsync(string email)
        {
            // _authProvider là biến bạn đã khởi tạo trong Constructor của DAL
            await _authProvider.SendPasswordResetEmailAsync(email);
        }
    }
}