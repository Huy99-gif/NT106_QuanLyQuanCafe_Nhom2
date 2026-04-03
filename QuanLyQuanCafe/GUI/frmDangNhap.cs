using QuanLyQuanCafe.BLL;
using QuanLyQuanCafe.DTO;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;



namespace QuanLyQuanCafe.GUI
{

    public partial class frmDangNhap : Form
    {
        private NhanVienBLL _nhanVienBLL = new NhanVienBLL();

        public frmDangNhap()
        {
            InitializeComponent();
        }


        private async void btnDangNhap_Click(object sender, EventArgs e)
        {

            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Email và Mật khẩu!", "Thông báo");
                return;
            }

            try
            {
                btnDangNhap.Enabled = false; // Khóa nút tránh spam

                // 2. Thực hiện đăng nhập (Lấy authLink từ DAL)
                var authLink = await _nhanVienBLL.DangNhap(email, password);

                if (authLink != null)
                {
                    // 3. Đăng nhập thành công -> Lưu thông tin Load Login
                    QuanLyQuanCafe.Properties.Settings.Default.UserEmail = email;
                    QuanLyQuanCafe.Properties.Settings.Default.UserPass = password;
                    QuanLyQuanCafe.Properties.Settings.Default.Save();

                    this.Hide();

                    if (authLink.vai_tro.ToLower() == "manager")
                    {
                        frmManager fManager = new frmManager();
                        fManager.ShowDialog();
                    }
                    else
                    {
                        frmStaff fStaff = new frmStaff();
                        fStaff.ShowDialog();
                    }

                    this.Close();
 
                }
                else
                {
                        MessageBox.Show("Tài khoản có thật nhưng chưa có thông tin trong bảng Nhân Viên!", "Cảnh báo");
                }
            }
            catch (Exception ex)
            {
          
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDangNhap.Enabled = true; // Mở lại nút
            }
        }

        private async void lblQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                bool isSuccess = await _nhanVienBLL.QuenMatKhau(txtEmail.Text.Trim());
                if (isSuccess)
                {
                    MessageBox.Show("Đã gửi email khôi phục! Vui lòng kiểm tra hộp thư của bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            string email = QuanLyQuanCafe.Properties.Settings.Default.UserEmail;
            string pass = QuanLyQuanCafe.Properties.Settings.Default.UserPass;

            // Nếu có dữ liệu thì điền vào 2 ô TextBox
            if (!string.IsNullOrEmpty(email))
            {
                txtEmail.Text = email;
                txtPassword.Text = pass; // Lưu ý: Trong code của bạn ô pass là txtPassword

                // Nếu muốn nó tự bấm nút đăng nhập luôn thì bỏ dấu // ở dòng dưới:
                // btnDangNhap.PerformClick();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
