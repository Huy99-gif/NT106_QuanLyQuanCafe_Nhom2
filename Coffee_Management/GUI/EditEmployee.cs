using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class EditEmployee : Form
    {
        private readonly EmployeeBUS _employeeBus = new EmployeeBUS();

        // Biến lưu trữ ID nhân viên đang được sửa
        private string _currentEmpId;

        // Constructor nhận dữ liệu từ Form Main truyền sang
        public EditEmployee(EmployeeDTO emp)
        {
            InitializeComponent();
            LoadRolesAndStatus();
            BindData(emp);
        }

        // Cài đặt danh sách chức vụ và trạng thái
        private void LoadRolesAndStatus()
        {
            // Binding Chức vụ (Roles)
            Dictionary<string, string> roles = new Dictionary<string, string>
            {
                { "manager", "Manager" },
                { "staff", "Order Staff" },
                { "barista", "Barista" },
                { "security", "Security" }
            };
            cboRole.DataSource = new BindingSource(roles, null);
            cboRole.DisplayMember = "Value";
            cboRole.ValueMember = "Key";

            // Binding Trạng thái (Status)
            Dictionary<string, string> status = new Dictionary<string, string>
            {
                { "active", "Active" },
                { "inactive", "Inactive / Locked" }
            };
            cboStatus.DataSource = new BindingSource(status, null);
            cboStatus.DisplayMember = "Value";
            cboStatus.ValueMember = "Key";
        }

        // Điền dữ liệu cũ vào các TextBox
        private void BindData(EmployeeDTO emp)
        {
            _currentEmpId = emp.EmployeeId; // Lưu ID để lát gọi API

            txtEmpId.Text = emp.EmployeeId;
            txtFullName.Text = emp.FullName;
            txtPhone.Text = emp.PhoneNumber;

            cboRole.SelectedValue = emp.Role;
            cboStatus.SelectedValue = emp.Status ?? "active";
        }

        // Xử lý nút Lưu (Save)
        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnSave.Text = "SAVING...";

            try
            {
                // Sử dụng DTO để truyền xuống BUS thay vì tạo object ẩn danh
                EmployeeDTO empUpdate = new EmployeeDTO
                {
                    FullName = txtFullName.Text.Trim(),
                    PhoneNumber = txtPhone.Text.Trim(),
                    Role = cboRole.SelectedValue?.ToString(),
                    Status = cboStatus.SelectedValue?.ToString()
                };

                // Gọi hàm Update đã có Validation bên BUS
                var result = await _employeeBus.UpdateEmployeeAsync(_currentEmpId, empUpdate);

                if (result.Success)
                {
                    MessageBox.Show("Employee information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Báo hiệu cho Form cha biết đã sửa xong
                    this.Close();
                }
                else
                {
                    // Trả ra lỗi từ Validation hoặc từ Server
                    MessageBox.Show(result.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Enabled = true;
                    btnSave.Text = "SAVE CHANGES";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = true;
                btnSave.Text = "SAVE CHANGES";
            }
        }

        // Xử lý nút Hủy (Cancel)
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
