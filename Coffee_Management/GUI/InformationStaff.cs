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
    public partial class InformationStaff : Form
    {
        public InformationStaff(EmployeeDTO emp)
        {
            InitializeComponent();
            BindData(emp);
        }

        private void BindData(EmployeeDTO emp)
        {
            txtEmpId.Text = emp.EmployeeId;
            txtFullName.Text = emp.FullName;
            txtPhone.Text = emp.PhoneNumber;

            // Chuyển đổi mã Role từ DB sang chữ hiển thị đẹp đẽ
            txtRole.Text = emp.Role switch
            {
                "manager" => "Quản lý",
                "staff" => "Nhân viên order",
                "barista" => "Nhân viên pha chế",
                "security" => "Bảo vệ",
                _ => emp.Role // Nếu có role khác thì hiện nguyên gốc
            };

            // Chuyển đổi mã Status sang chữ hiển thị đẹp đẽ
            if (emp.Status == "active")
            {
                txtStatus.Text = "Đang hoạt động";
            }
            else
            {
                txtStatus.Text = "Không hoạt động";
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
