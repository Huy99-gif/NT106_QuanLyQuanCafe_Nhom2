using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class VerifyCode : Form
    {
        private DateTime _expiryTime; // Biến lưu thời điểm mã sẽ hết hạn
        private int timeLeft = 60;
        private EmailCode emailBUS = new EmailCode();
        // 2 Biến toàn cục để hứng dữ liệu từ Form 1 truyền sang
        private string _systemCode;
        private string _userEmail;

        // Sửa lại hàm khởi tạo để nhận dữ liệu
        public VerifyCode(string systemCode, string userEmail)
        {
            InitializeComponent();

            // Cất dữ liệu nhận được vào biến toàn cục để dùng cho nút Xác nhận
            _systemCode = systemCode;
            _userEmail = userEmail;
            _expiryTime = DateTime.Now.AddSeconds(60);
        }

        private void lblBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form? ConfirmForm = Application.OpenForms["ConfirmEmail"];
            if (ConfirmForm != null)
            {
                ConfirmForm.Show();
            }
            this.Close();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string userCode = txtCode.Text;

            if (string.IsNullOrWhiteSpace(userCode))
            {
                MessageBox.Show("Please enter the verification code!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // KIỂM TRA THỜI GIAN HẾT HẠN
            if (DateTime.Now > _expiryTime)
            {
                MessageBox.Show("The verification code has expired (60s). Please click 'Resend Code' to get a new one.",
                                "Code Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Có thể xóa mã hệ thống để đảm bảo người dùng không thể dùng lại mã cũ
                _systemCode = "";
                return;
            }

            if (userCode == _systemCode)
            {
                ResetPassword reset = new ResetPassword(_userEmail);
                reset.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid verification code. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidVerificationCode(string code)
        {
            // Giải thích Regex:
            // ^      : Bắt đầu chuỗi
            // \d{8}  : Chính xác 8 chữ số (từ 0-9)
            // $      : Kết thúc chuỗi
            string pattern = @"^\d{8}$";
            return Regex.IsMatch(code, pattern);
        }

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            string code = txtCode.Text;
            if (!string.IsNullOrWhiteSpace(code))
            {
                if (!IsValidVerificationCode(code))
                {
                    MessageBox.Show("Invalid verification code!\nThe code must be exactly 8 digits, including both letters and numbers.", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    txtCode.SelectAll();
                }
            }
        }

        private async void lblResend_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 1. Vô hiệu hóa nút để tránh người dùng bấm nhiều lần
            lblResend.Enabled = false;
            lblResend.Text = "Sending...";

            try
            {
                // 2. Gọi lại hàm gửi mã từ BUS (sử dụng email đã nhận từ Form trước)
                // result.Code sẽ là mã mới được sinh ra
                var result = await emailBUS.SendVerificationCodeAsync(_userEmail);

                if (result.IsSuccess)
                {
                    // 3. QUAN TRỌNG: Cập nhật lại mã hệ thống mới vào biến cục bộ
                    _systemCode = result.Code;

                    MessageBox.Show("A new code has been sent to your email.", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Bắt đầu đếm ngược (Optional - xem hướng dẫn ở mục 2)
                    lblResend.Enabled = false;
                    resendTimer.Start();
                }
                else
                {
                    MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblResend.Enabled = true;
                    lblResend.Text = "Resend Code";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblResend.Enabled = true;
                lblResend.Text = "Resend Code";
            }
        }

        private void VerifyCode_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                // Mỗi giây trôi qua, trừ đi 1
                timeLeft--;
                // Cập nhật chữ trên nút bấm để người dùng thấy
                lblResend.Text = $"Resend in ({timeLeft}s)";
            }
            else
            {
                // Khi hết thời gian (về 0)
                resendTimer.Stop(); // Dừng bộ đếm
                lblResend.Enabled = true; // Cho phép bấm lại
                lblResend.Text = "Resend Code"; // Trả lại chữ ban đầu
                timeLeft = 60; // Reset lại biến thời gian cho lần sau
            }
        }
    }
}
