using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucSettings_Manager : UserControl
    {
        private readonly EmployeeBUS _employeeBus = new EmployeeBUS();
        private List<EmployeeDTO> _allEmployees = new List<EmployeeDTO>();

        // 1. GỌI ÔNG QUẢN LÝ CHAT LÊN
        private ChatManager _chatManager;

        public ucSettings_Manager()
        {
            InitializeComponent();

            // 2. GIAO PHÓ LISTBOX CHO ÔNG MANAGER
            _chatManager = new ChatManager(this, lstChatHistory);

            this.Load += async (s, e) =>
            {
                await LoadEmployeeData();
                await _chatManager.ConnectToChatServer(); // CHỈ 1 DÒNG
            };

            btnSend.Click += BtnSend_Click;
            btnOpenChatWindow.Click += BtnOpenChatWindow_Click;
            btnChangePassword.Click += BtnChangePassword_Click;
            btnUpdateProfile.Click += BtnUpdateProfile_Click;

            // CHỈ 1 DÒNG ĐỂ ĐỔI PHÒNG
            cmbChatTarget.SelectedIndexChanged += async (s, e) => await _chatManager.SwitchChatRoom(GetIdFromCombo());
        }

        private async Task LoadEmployeeData()
        {
            try
            {
                _allEmployees = await _employeeBus.GetAllEmployeesAsync();
                if (_allEmployees == null || _allEmployees.Count == 0) return;

                cmbChatTarget.Items.Clear();
                cmbChatTarget.Items.Add("--- Everyone (Group Chat) ---");

                foreach (var emp in _allEmployees.Where(x => x.Status == "active"))
                {
                    cmbChatTarget.Items.Add($"[{emp.EmployeeId}] {emp.FullName} ({emp.Role})");
                }

                if (cmbChatTarget.Items.Count > 0) cmbChatTarget.SelectedIndex = 0;

                lstChatHistory.Items.Clear();
                lstChatHistory.Items.Add("[System]: Internal communication channel connected.");
                lstChatHistory.Items.Add("");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load employee list: {ex.Message}", "System Error");
            }
        }

        private async void BtnSend_Click(object? sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(message)) return;

            // 3. ĐẨY MESSAGE CHO MANAGER GỬI ĐI
            await _chatManager.SendMessageAsync(message);

            txtMessage.Clear();
            txtMessage.Focus();
        }

        private void BtnOpenChatWindow_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("This feature will open a standalone Messenger-style window.", "Floating Chat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnChangePassword_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Opening Password Reset form...", "Security");
        }

        private void BtnUpdateProfile_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Opening Profile Editor...", "Account Settings");
        }

        private string GetIdFromCombo()
        {
            if (cmbChatTarget.SelectedIndex <= 0) return "Everyone";
            return cmbChatTarget.SelectedItem.ToString().Split(']')[0].Trim('[');
        }
    }
}