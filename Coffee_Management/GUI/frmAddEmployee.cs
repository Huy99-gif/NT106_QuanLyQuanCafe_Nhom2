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
    public partial class frmAddEmployee : Form
    {
        private EmployeeBUS employeeBus = new EmployeeBUS();
        public frmAddEmployee()
        {
            InitializeComponent();
            this.Load += async (s, e) => await LoadNextEmployeeId();
        }

        private async void frmAddEmployee_Load(object sender, EventArgs e)
        {
            await LoadNextEmployeeId();
        }

        private async Task LoadNextEmployeeId()
        {
            try
            {
                string nextId = await employeeBus.GenerateNextEmployeeId();
                txtEmpID.Text = nextId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mã nhân viên: " + ex.Message);
            }
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {         
            this.Close(); 
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Khóa nút để tránh nhấn nhiều lần
                btnSave.Enabled = false;

                // 2. Thu thập dữ liệu từ các Control
                Employee newEmp = new Employee
                {
                    EmployeeId = txtEmpID.Text, // Lấy mã đã tự động tạo
                    Email = txtEmail.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    HireDate = dtpHireDate.Value.ToString("yyyy-MM-dd"),
                    PhoneNumber = txtPhone.Text.Trim(),
                    Role = cboRole.SelectedItem?.ToString() ?? "Staff",
                    Password = txtPassword.Text.Trim(),
                    // Avatar mặc định hoặc bạn có thể thêm nút chọn ảnh sau
                    AvatarUrl = ""
                };

                // 3. Gọi BUS để thực hiện lưu
                bool result = await employeeBus.AddEmployeeAsync(newEmp);

                if (result)
                {
                    MessageBox.Show($"Thêm nhân viên {newEmp.FullName} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Trả về kết quả để Form danh sách cập nhật lại
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Hiển thị các lỗi Validation từ BUS (ví dụ: thiếu email, sai định dạng...)
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
    }
}
