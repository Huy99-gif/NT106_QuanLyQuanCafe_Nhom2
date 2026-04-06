using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using DTO;
using BUS;


namespace GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            //Khi nhập pass chuyển thành dấu chấm
        }

        private AuthBUS authBUS = new AuthBUS();

        // Biến static lưu trữ phiên đăng nhập hiện tại cho toàn bộ ứng dụng
        public static Employee? CurrentUser;

        //Hàm tạo sự kiện cho UI
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int fadeWidth = 60;
            Rectangle fadeArea = new Rectangle(pictureBox1.Width - fadeWidth, 0, fadeWidth, pictureBox1.Height);
            Color pnlRightColor = Color.FromArgb(30, 30, 30);
            using (LinearGradientBrush brush = new LinearGradientBrush(
                fadeArea,
                Color.Transparent,
                pnlRightColor,
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, fadeArea);
            }
        }
        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }
        private void btnShowPass_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void btnShowPass_MouseUp(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ConfirmEmail ConfirmEmail = new ConfirmEmail();
            this.Hide();
            ConfirmEmail.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your email address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Khóa nút bấm trong lúc chờ mạng
            btnSignIn.Enabled = false;
            btnSignIn.Text = "Processing...";

            // 3. Gọi BUS thực hiện đăng nhập
            // Vì BUS trả về 1 Tuple (IsSuccess, Message, UserData), ta dùng 'var result' để hứng
            var result = await authBUS.LoginBUS(email, password);

            // 4. Xử lý kết quả và Phân quyền
            if (result.IsSuccess == true)
            {
                // Đăng nhập và qua các ải kiểm tra nghiệp vụ thành công
                CurrentUser = result.UserData!; // Lưu vào biến hệ thống

                // Điều hướng dựa vào Role
                if (CurrentUser.Role == "manager")
                {
                    ManagerDashboard managerDashboard = new ManagerDashboard();
                    managerDashboard.Show();
                    this.Hide();
                }
                else if (CurrentUser.Role == "staff")
                {
                    MessageBox.Show($"Hello {CurrentUser.FullName}!\n{result.Message}", "Login Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OrderStaffDashboard orstaffDashboard = new OrderStaffDashboard();
                    orstaffDashboard.Show();
                    this.Hide();
                }
            }
            else
            {
                // Nếu IsSuccess == false (Sai pass, tài khoản bị khóa, rỗng...)
                // Chỉ cần lấy đúng câu Message từ lớp BUS và in ra
                MessageBox.Show(result.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 5. Mở lại nút bấm
            btnSignIn.Enabled = true;
            btnSignIn.Text = "Sign in";
        }

        private bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        private bool IsValidEmail(string email)
        {
            // Kiểm tra định dạng: chữ/số/dấu_chấm @ chữ/số . chữ/số
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string email = txtEmail.Text;
            if (!string.IsNullOrWhiteSpace(email))
            {
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Invalid email format. Please enter a valid email address.", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    txtEmail.SelectAll();
                }
            }
        }

        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string password = txtPassword.Text;
            if (!string.IsNullOrWhiteSpace(password))
            {
                if (!IsValidPassword(password))
                {
                    MessageBox.Show("Password must be at least 8 characters long, and include an uppercase letter, a lowercase letter, a number, and a special character.",
                                "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    txtPassword.SelectAll();
                }
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
