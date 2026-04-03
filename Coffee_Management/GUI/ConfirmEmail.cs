using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ConfirmEmail : Form
    {
        public ConfirmEmail()
        {
            InitializeComponent();
        }

        private void lblBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form? loginForm = Application.OpenForms["Login"];
            if (loginForm != null)
            {
                loginForm.Show();
            }
            this.Close();
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your email address!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (email == "kirak7264@gmail.com")
            {
                VerifyCode verifyCode = new VerifyCode();
                verifyCode.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Email not found. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private bool IsValidEmail(string email)
        {
            // Kiểm tra định dạng: chữ/số/dấu_chấm @ chữ/số . chữ/số
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEmail.Text;
            if (!string.IsNullOrWhiteSpace(email))
            {
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Invalid email format! Please enter email following the format: example@gmail.com", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    txtEmail.SelectAll();
                }
            }
        }

        private void ConfirmEmail_Load(object sender, EventArgs e)
        {

        }
    }
}
