using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;


namespace QuanLyQuanCafe.GUI
{
    public partial class frmManager : Form
    {
        // Khai báo BLL
        private NhanVienBLL _nhanVienBLL = new NhanVienBLL();
        public frmManager()
        {
            InitializeComponent();
        }

        private async void frmManager_Load(object sender, EventArgs e)
        {

            // Lấy email lúc người dùng đăng nhập từ Settings
            string email = Properties.Settings.Default.UserEmail;

            if (string.IsNullOrEmpty(email)) return;

            try
            {
                // Gọi BLL lấy toàn bộ thông tin nhân viên (đã gói trong DTO)
                NhanVienDTO nv = await _nhanVienBLL.LayThongTinNhanVien(email);

                if (!string.IsNullOrEmpty(nv.avatar_url))
                {
                    // BƯỚC QUAN TRỌNG: Ép ứng dụng dùng chuẩn bảo mật TLS 1.2 để không bị server từ chối
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    // (Tùy chọn) In link ra TextBox để chắc chắn link lấy từ Firebase về là đúng và không bị dính khoảng trắng

                    // Tải ảnh không gây giật lag form
                    pictureBox2.LoadAsync(nv.avatar_url);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox2.Width, pictureBox2.Height);

            // Cắt cái PictureBox theo đúng cái viền hình tròn vừa tạo
            pictureBox2.Region = new Region(gp);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(pictureBox2, new Point(0, pictureBox2.Height));
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Hiện hộp thoại hỏi xác nhận để tránh người dùng bấm nhầm
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi tài khoản này?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn "Yes"
            if (result == DialogResult.Yes)
            {
                // 2. (Tùy chọn) NẾU bạn có lưu Token vào Settings ở Form Đăng nhập thì bạn phải xóa nó ở đây. 
                // Nếu bạn chỉ dùng Token trên RAM thì bỏ qua bước này.
                // QuanLyQuanCafe.Properties.Settings.Default.AuthToken = "";
                // QuanLyQuanCafe.Properties.Settings.Default.Save();

                // CHÚ Ý: Cố tình KHÔNG xóa UserEmail và UserPass để lần sau Form Login tự động điền sẵn cho người dùng.

                // 3. Khởi động lại toàn bộ phần mềm
                // Lệnh này sẽ:
                // - Quét sạch mọi Token, biến cục bộ đang lưu trên RAM.
                // - Tự động đóng frmManager/frmStaff hiện tại.
                // - Mở lại ứng dụng từ file Program.cs (tức là quay về màn hình Login ban đầu).
                Application.Restart();
            }
        }
    }
}
