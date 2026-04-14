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
    public partial class ucStaff_Manager : UserControl
    {
        private readonly EmployeeBUS _employeeBus = new EmployeeBUS();
        public ucStaff_Manager()
        {
            InitializeComponent();
            this.Load += async (s, e) => await LoadRealData();
            btnAddStaff.Click += btnAddStaff_Click;
            btnCheckIn.Click += BtnCheckIn_Click;
            btnApproveLeave.Click += BtnApproveLeave_Click;
        }

        private async Task LoadRealData()
        {
            try
            {
                // Thay đổi con trỏ chuột sang trạng thái chờ
                this.Cursor = Cursors.WaitCursor;

                // Xóa DataSource cũ để người dùng thấy dữ liệu đang được làm mới
                dgvStaff.DataSource = null;
                // Gọi BUS để lấy danh sách từ Cloud Functions
                List<EmployeeDTO> list = await _employeeBus.GetAllEmployeesAsync();

                // Tạo DataTable để hiển thị lên GridView
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã NV");
                dt.Columns.Add("Họ và Tên");
                dt.Columns.Add("Email");
                dt.Columns.Add("Vị Trí");
                dt.Columns.Add("Trạng Thái");

                foreach (var emp in list)
                {
                    dt.Rows.Add(
                        emp.EmployeeId,
                        emp.FullName,
                        emp.Email,
                        emp.Role,
                        emp.Status ?? "active" // Nếu null thì mặc định active
                    );
                }

                dgvStaff.DataSource = dt;

                // Cập nhật số lượng nhân viên lên label nếu cần
                lblPresentValue.Text = $"{list.Count} người";
                // 5. Tinh chỉnh giao diện Grid (Cái này giúp App đẹp hơn)
                dgvStaff.Columns["Mã NV"].Width = 80;
                dgvStaff.Columns["Trạng Thái"].Width = 100;
                // Tự động kéo giãn các cột còn lại
                dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "System Error");
            }
            finally
            {
                // Trả con trỏ chuột về bình thường
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnCheckIn_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Tính năng Quét thẻ RFID / Vân tay / Nhập mã NV để điểm danh ca làm việc.", "Chấm Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnApproveLeave_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Đã DUYỆT đơn xin nghỉ của [NV03 Lê Văn C]. Dữ liệu đã cập nhật vào tính lương cuối tháng.", "Duyệt Nghỉ Phép", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lstLeaveq.Items.Clear();
            lstLeaveq.Items.Add("✔️ Không còn đơn xin nghỉ nào cần duyệt.");
            btnApproveLeave.Enabled = false;
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            AddEmployee frmAdd = new AddEmployee();
            // Mở form lên dưới dạng hộp thoại (người dùng phải đóng form này mới thao tác tiếp được với nền bên dưới)
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                // Đoạn code này sẽ chạy nếu bên form AddEmployee bạn lưu thành công 
                // và đã gán: this.DialogResult = DialogResult.OK;

                MessageBox.Show("The new employee list has been updated!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Gọi hàm load lại dữ liệu lên DataGridView ở đây (nếu có)
                // Ví dụ: LoadStaffData();
            }
        }

        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
