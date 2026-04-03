using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucSettings_Manager : UserControl
    {
        public ucSettings_Manager()
        {
            InitializeComponent();

            // 1. Nạp dữ liệu mặc định
            LoadDummyData();

            // 2. Gắn sự kiện cho các nút bấm và ComboBox
            cmbChatMode.SelectedIndexChanged += CmbChatMode_SelectedIndexChanged;
            btnSend.Click += BtnSend_Click;
            btnOpenChatWindow.Click += BtnOpenChatWindow_Click;
            btnChangePassword.Click += BtnChangePassword_Click;
            btnUpdateProfile.Click += BtnUpdateProfile_Click;
        }
        private void LoadDummyData()
        {
            // Thiết lập mặc định là Chat Group
            if (cmbChatMode.Items.Count > 0)
            {
                cmbChatMode.SelectedIndex = 0; // Chọn "Group"
            }

            // Cập nhật danh sách đích đến tương ứng
            UpdateChatTargets();

            // Đổ lịch sử chat mẫu
            lstChatHistory.Items.Clear();
            lstChatHistory.Items.Add("[Hệ thống]: Chào mừng bạn đến với kênh Chat Nội Bộ.");
            lstChatHistory.Items.Add("");
            lstChatHistory.Items.Add("[Tất cả nhân sự] - Sếp Tổng: Chào mọi người, ca tối nay ráng cày nhé!");
            lstChatHistory.Items.Add("");
            lstChatHistory.Items.Add("[Private - Chú Hoàng]: Quản lý ra xem hộ chú cái xe của khách với.");
            lstChatHistory.Items.Add("");
        }

        private void CmbChatMode_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateChatTargets();
        }
        private void UpdateChatTargets()
        {
            cmbChatTarget.Items.Clear();
            if (cmbChatMode.SelectedItem != null && cmbChatMode.SelectedItem.ToString() == "Private")
            {
                cmbChatTarget.Items.Add("👑 Sếp Tổng");
                cmbChatTarget.Items.Add("👨‍🍳 Bếp Trưởng (Mr. Hùng)");
                cmbChatTarget.Items.Add("👩‍💼 Thu Ngân (Ms. Linh)");
                cmbChatTarget.Items.Add("👮 Bảo Vệ (Chú Hoàng)");
                cmbChatTarget.Items.Add("☕ Pha chế (Văn A)");
            }
            else
            {
                cmbChatTarget.Items.Add("Tất cả nhân sự");
                cmbChatTarget.Items.Add("Nhóm Bếp & Pha Chế");
                cmbChatTarget.Items.Add("Nhóm Phục Vụ & Thu Ngân");
            }
            if (cmbChatTarget.Items.Count > 0)
            {
                cmbChatTarget.SelectedIndex = 0;
            }
        }

        private void BtnSend_Click(object? sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();

            if (!string.IsNullOrEmpty(message))
            {
                string mode = cmbChatMode.SelectedItem?.ToString() ?? "Unknown";
                string target = cmbChatTarget.SelectedItem?.ToString() ?? "Unknown";
                string prefix = mode == "Private" ? $"[Gửi riêng tới {target}]" : $"[{target}]";
                lstChatHistory.Items.Add($"{prefix} - Bạn: {message}");
                lstChatHistory.Items.Add("");
                lstChatHistory.TopIndex = lstChatHistory.Items.Count - 1;
                txtMessage.Clear();
                txtMessage.Focus();
            }
        }

        private void BtnOpenChatWindow_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này sẽ bật riêng khung Chat ra một Cửa sổ (Form) mới giống như Messenger để bạn tiện vừa làm việc vừa chat!", "Mở cửa sổ Chat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnChangePassword_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Mở Form đổi mật khẩu.", "Đổi Mật Khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnUpdateProfile_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Mở Form cập nhật Hồ sơ.", "Cập Nhật Hồ Sơ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}