using BUS;
using DTO;
using Microsoft.AspNetCore.SignalR.Client; // Thêm thư viện SignalR Client
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucInternalChat : UserControl
    {
        private readonly EmployeeBUS _employeeBus = new EmployeeBUS();
        private HubConnection _connection; // Biến giữ kết nối SignalR

        // 1. GỌI ÔNG QUẢN LÝ CHAT LÊN
        private ChatManager _chatManager;

        public ucInternalChat()
        {
            InitializeComponent();

            // 2. GIAO PHÓ LISTBOX CHO ÔNG MANAGER
            _chatManager = new ChatManager(this, lstChatHistory);

            this.Load += async (s, e) =>
            {
                await LoadStaffData();
                await _chatManager.ConnectToChatServer(); // CHỈ 1 DÒNG
            };

            btnSend.Click += BtnSend_Click;
            btnOpenChatWindow.Click += (s, e) => MessageBox.Show("Opening Messenger window...");
            txtMessage.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BtnSend_Click(s, e); } };
            // CHỈ 1 DÒNG ĐỂ ĐỔI PHÒNG
            cmbChatTarget.SelectedIndexChanged += async (s, e) => await _chatManager.SwitchChatRoom(GetIdFromCombo());
        }

        private async Task LoadStaffData()
        {
            try
            {
                List<EmployeeDTO> allEmployees = await _employeeBus.GetAllEmployeesAsync();

                cmbChatTarget.Items.Clear();
                cmbChatTarget.Items.Add("--- Send to Everyone (Group Chat) ---");

                if (allEmployees != null)
                {
                    foreach (var emp in allEmployees.Where(x => x.Status == "active"))
                    {
                        cmbChatTarget.Items.Add($"[{emp.EmployeeId}] {emp.FullName} ({emp.Role})");
                    }
                }

                if (cmbChatTarget.Items.Count > 0) cmbChatTarget.SelectedIndex = 0;

                lstChatHistory.Items.Clear();
                lstChatHistory.Items.Add("[System]: Connected to QLCafe Chat.");
            }
            catch (Exception ex)
            {
                lstChatHistory.Items.Add($"[Error]: Cannot load staff list. {ex.Message}");
            }
        }

        // Đổi thành async void để gửi tin
        private async void BtnSend_Click(object? sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(message)) return;

            // 3. ĐẨY MESSAGE CHO MANAGER GỬI ĐI
            await _chatManager.SendMessageAsync(message);

            txtMessage.Clear();
            txtMessage.Focus();
        }

        private string GetIdFromCombo()
        {
            if (cmbChatTarget.SelectedIndex <= 0) return "Everyone";
            return cmbChatTarget.SelectedItem.ToString().Split(']')[0].Trim('[');
        }
    }
}