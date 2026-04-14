using BUS;
using DTO;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace GUI
{
    public partial class AddEmployee : Form
    {
        private readonly EmployeeBUS _employeeBus = new EmployeeBUS();

        public AddEmployee()
        {
            InitializeComponent();
            btnCancel.CausesValidation = false; 
        }

        public AddEmployee(Employee emp)
        {
            InitializeComponent();
            btnCancel.CausesValidation = false;

            // Đổi tiêu đề giao diện
            textBox1.Text = "Update Account";
            btnSave.Text = "Update";

            // Đổ dữ liệu cũ lên giao diện 
            txtEmail.Text = emp.Email;
            txtFullName.Text = emp.FullName;
            txtPhone.Text = emp.PhoneNumber;
            txtPassword.Text = emp.Password;

            if (!string.IsNullOrEmpty(emp.Role))
                cboRole.SelectedItem = emp.Role;

            if (DateTime.TryParse(emp.HireDate, out DateTime parsedDate))
                dtpHireDate.Value = parsedDate;
        }

        private void frmAddEmployee_Load(object sender, EventArgs e)
        {
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Khóa nút để tránh spam click
                btnSave.Enabled = false;

                // 2. Thu thập dữ liệu từ Form
                Employee newEmp = new Employee
                {
                    Email = txtEmail.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    HireDate = dtpHireDate.Value.ToString("yyyy-MM-dd"),
                    PhoneNumber = txtPhone.Text.Trim(),
                    Role = cboRole.SelectedItem?.ToString() ?? "Staff",
                    Password = txtPassword.Text.Trim(),
                    AvatarUrl = ""
                };

                bool result = await _employeeBus.AddEmployeeAsync(newEmp);
                if (result)
                {
                    MessageBox.Show($"Employee {newEmp.FullName} added successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Bất kỳ lỗi nào (Form rỗng, Email sai, Mật khẩu yếu...) từ Server Cloud Functions trả về sẽ hiển thị tại đây
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtFullName_TextChanged(object sender, EventArgs e) { }
    }
}