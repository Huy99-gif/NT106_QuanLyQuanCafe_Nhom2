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
            switch (emp.Role)
            {
                case "manager": txtRole.Text = "Manager"; break;
                case "staff": txtRole.Text = "Order Staff"; break;
                case "barista": txtRole.Text = "Barista"; break;
                case "security": txtRole.Text = "Security"; break;
                default: txtRole.Text = emp.Role; break; // Nếu có role khác thì hiện nguyên gốc
            }

            // Chuyển đổi mã Status sang chữ hiển thị đẹp đẽ
            if (emp.Status == "active")
            {
                txtStatus.Text = "Active";
            }
            else
            {
                txtStatus.Text = "Inactive / Locked";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
