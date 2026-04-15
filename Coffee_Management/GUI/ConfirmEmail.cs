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
using BUS;

namespace GUI
{
    public partial class ConfirmEmail : Form
    {
        private EmailCodeBUS emailBUS = new EmailCodeBUS();
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

        private async void btnSendCode_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            btnSendCode.Enabled = false;
            btnSendCode.Text = "Sending...";

            // Gọi BUS gửi mail
            var result = await emailBUS.ProcessPasswordResetAsync(email);

            if (result.IsSuccess)
            {
                MessageBox.Show(result.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // QUAN TRỌNG: Mở Form 2 và truyền Mã code + Email sang đó
                VerifyCode verifyForm = new VerifyCode(result.Code, email);
                verifyForm.Show();
                this.Hide(); // Ẩn Form 1 đi
            }
            else
            {
                MessageBox.Show(result.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSendCode.Enabled = true;
                btnSendCode.Text = "Send Code";
            }
        }

        private void ConfirmEmail_Load(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
