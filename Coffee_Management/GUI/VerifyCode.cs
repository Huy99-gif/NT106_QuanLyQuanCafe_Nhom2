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
        public VerifyCode()
        {
            InitializeComponent();
        }

        private void lblBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string inputCode = txtCode.Text;

            if (string.IsNullOrWhiteSpace(inputCode))
            {
                MessageBox.Show("Please enter the verification code!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (inputCode == "code1234")
            {
                ResetPassword reset = new ResetPassword();
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
            // (?=.*[a-zA-Z]) : Phải chứa ít nhất 1 chữ cái (hoa hoặc thường)
            // (?=.*\d)       : Phải chứa ít nhất 1 chữ số
            // [a-zA-Z\d]{8}  : Chỉ cho phép chữ và số, và phải dài CHÍNH XÁC 8 ký tự
            string pattern = @"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{8}$";
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
                    MessageBox.Show("Invalid verification code!\nThe code must be exactly 8 characters long, including both letters and numbers.", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    txtCode.SelectAll();
                }
            }
        }
    }
}
