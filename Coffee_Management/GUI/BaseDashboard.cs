using DTO; // Chứa GlobalSession
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUI
{
    // Kế thừa từ Form mặc định của Windows
    public partial class BaseDashboard : Form
    {
        private System.Windows.Forms.Timer sessionTimer;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        protected void HandleFormDrag(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0xA1, 0x2, 0);
            }
        }

        public BaseDashboard()
        {

            // Thêm đoạn "tự động hóa" này vào đây
            this.Load += (s, e) =>
                ApplyDragToAllControls(this);
            // Mẹo cực quan trọng: Thuộc tính DesignMode giúp Timer KHÔNG chạy 
            // lúc bạn đang kéo thả giao diện trong Visual Studio, tránh gây lỗi Designer.
            if (!this.DesignMode)
            {
                SetupSessionTimer();
            }
        }

        // Hàm đệ quy: Đi xuyên qua tất cả các lớp Panel, GroupBox, PictureBox...
        private void ApplyDragToAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                // Quy tắc: Chỉ gắn vào những thứ không phải là nút bấm hay ô nhập liệu
                // Để ông còn bấm nút hay gõ chữ được chứ!
                if (!(c is Button || c is TextBox || c is ComboBox || c is CheckBox || c is LinkLabel))
                {
                    c.MouseDown += HandleFormDrag;

                    // Nếu bên trong cái này còn có con nữa, thì đi vào tiếp (Đệ quy)
                    if (c.HasChildren)
                    {
                        ApplyDragToAllControls(c);
                    }
                }
            }

            // Gắn luôn vào chính cái Form nền
            this.MouseDown += HandleFormDrag;
        }

        private void SetupSessionTimer()
        {
            sessionTimer = new System.Windows.Forms.Timer();
            sessionTimer.Interval = 1000; // 1 giây
            sessionTimer.Tick += SessionTimer_Tick;
            sessionTimer.Start();
        }

        private void SessionTimer_Tick(object sender, EventArgs e)
        {
            // Nếu chưa đăng nhập hoặc không có thời gian thì bỏ qua
            if (GlobalSession.ExpiryTime == DateTime.MinValue)
                return;

            TimeSpan remaining = GlobalSession.ExpiryTime - DateTime.Now;

            if (remaining.TotalSeconds <= 0)
            {
                // Dừng bộ đếm
                sessionTimer.Stop();

                // Xóa sạch dữ liệu phiên làm việc hiện tại để bảo mật
                GlobalSession.Token = "";
                GlobalSession.CurrentUser = null;
                GlobalSession.ExpiryTime = DateTime.MinValue;

                // Hiển thị thông báo
                MessageBox.Show("Your session has expired for security reasons. Please log in again!",
                "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // 4. Tìm lại Form Login đang bị ẩn và hiển thị nó lên
                bool isLoginFound = false;
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Name == "Login")
                    {
                        frm.Show(); // Bật lại màn hình Login
                        isLoginFound = true;
                        break;
                    }
                }
                // Dự phòng: Nếu Form Login không còn trong bộ nhớ, ta tạo mới
                if (!isLoginFound)
                {
                    Login loginForm = new Login();
                    loginForm.Show();
                }
                // Đóng tất cả Form hiện tại (Out tab)
                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    Form? frm = Application.OpenForms[i];

                    // Nếu không phải là màn hình Login thì "trảm" hết
                    if (frm.Name != "Login")
                    {
                        // Ép DialogResult về Abort để phá vỡ thế phòng thủ của ShowDialog()
                        frm.DialogResult = DialogResult.Abort;
                        frm.Close();
                    }
                }
                // Đóng Form Dashboard hiện tại (Out tab)
                this.Close();
            }
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // BaseDashboard
            // 
            ClientSize = new Size(284, 261);
            Name = "BaseDashboard";
            ResumeLayout(false);

        }

        // Tự động dọn dẹp Timer khi Form đóng để giải phóng RAM
        protected override void Dispose(bool disposing)
        {
            if (disposing && (sessionTimer != null))
            {
                sessionTimer.Stop();
                sessionTimer.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}