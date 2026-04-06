using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BUS;

namespace GUI
{
    public partial class ResetPassword : Form
    {
        private string userEmail;
        public ResetPassword(string email)
        {
            InitializeComponent();
            this.userEmail = email;
        }

        private void txtConfirmPass_Enter(object sender, EventArgs e)
        {
            txtConfirmPass.UseSystemPasswordChar = true;
        }

        private void btnShowConfirmPass_MouseDown(object sender, MouseEventArgs e)
        {
            txtConfirmPass.UseSystemPasswordChar = false;
        }

        private void btnShowConfirmPass_MouseUp(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                txtConfirmPass.UseSystemPasswordChar = true;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string newPass = txtNewPass.Text;
            string confirmPass = txtConfirmPass.Text;

            if (string.IsNullOrWhiteSpace(newPass) || string.IsNullOrWhiteSpace(confirmPass))
            {
                MessageBox.Show("Please enter your new password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnSave.Text = "Saving...";
            btnSave.Enabled = false;

            // Khởi tạo lớp xử lý logic
            AuthServiceBUS authBUS = new AuthServiceBUS();

            // Gọi hàm xử lý (truyền email, pass mới, và xác nhận pass)
            var result = await authBUS.HandlePasswordReset(userEmail, txtNewPass.Text, txtConfirmPass.Text);

            if (result.IsValid)
            {
                MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form? loginForm = Application.OpenForms["Login"];
                if (loginForm != null)
                {
                    loginForm.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: " + result.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnSave.Text = "Save";
            btnSave.Enabled = true;

        }

        private bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        private void txtNewPass_Validating(object sender, CancelEventArgs e)
        {
            string newPass = txtNewPass.Text;
            if (!string.IsNullOrWhiteSpace(newPass))
            {
                if (!IsValidPassword(newPass))
                {
                    MessageBox.Show("Password must be at least 8 characters long, and include an uppercase letter, a lowercase letter, a number, and a special character.",
                                "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    txtNewPass.SelectAll();
                }
            }
        }

        private void lblBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form? VerifyForm = Application.OpenForms["VerifyCode"];
            if (VerifyForm != null)
            {
                VerifyForm.Show();
            }
            this.Close();
        }
    }
}
