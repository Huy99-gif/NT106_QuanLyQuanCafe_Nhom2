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
        public ucStaff_Manager()
        {
            InitializeComponent();
            this.Load += async (s, e) => await LoadRealData();
            btnApproveLeave.Click += BtnApproveLeave_Click;
        }

        private async Task LoadRealData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dgvStaff.DataSource = null;

                // 1. Lấy TẤT CẢ danh sách từ Server về
                List<EmployeeDTO> fullList = await EmployeeBUS.GetAllEmployeesAsync();

                if (fullList == null || fullList.Count == 0) return;

                // 2. LỌC CHỈ LẤY NHÂN VIÊN "ACTIVE" VÀ KHÔNG PHẢI LÀ "ADMIN"
                var List = fullList.Where(emp => emp.Role != "admin").ToList();

                // 3. Tạo cấu trúc bảng
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã NV");
                dt.Columns.Add("Họ và Tên");
                dt.Columns.Add("Vị Trí");
                dt.Columns.Add("Trạng Thái");
                dt.Columns.Add("Số điện thoại");
                dt.Columns.Add("AuthUid");
                dt.Columns.Add("Email");

                // 4. Đổ danh sách ĐÃ LỌC (activeList) vào bảng
                foreach (var emp in List)
                {
                    dt.Rows.Add(
                        emp.EmployeeId,
                        emp.FullName,
                        emp.Role,
                        emp.Status,
                        emp.PhoneNumber,
                        emp.AuthUid,
                        emp.Email
                    );
                }

                dgvStaff.DataSource = dt;
                dgvStaff.Columns["AuthUid"].Visible = false; // Giấu đi không cho User thấy
                dgvStaff.Columns["Số điện thoại"].Visible = false;
                dgvStaff.Columns["Email"].Visible = false;
                dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Tổng FillWeight thường là 100 (tương đương 100%), chia tỷ lệ cho các cột:
                dgvStaff.Columns["Mã NV"].FillWeight = 10;
                dgvStaff.Columns["Họ và Tên"].FillWeight = 20;
                dgvStaff.Columns["Vị Trí"].FillWeight = 15;
                dgvStaff.Columns["Trạng Thái"].FillWeight = 15;

                // (Tùy chọn) Căn giữa cho các cột nhìn gọn gàng hơn
                dgvStaff.Columns["Mã NV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvStaff.Columns["Vị Trí"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvStaff.Columns["Trạng Thái"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                var activeList = fullList.Where(emp => emp.Status == "active" && emp.Role != "admin").ToList();
                // Cập nhật label đếm số lượng nhân viên đang làm
                lblPresentValue.Text = $"{activeList.Count} người";
            }
            catch (Exception ex)
            {
                MsgBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi hệ thống", MsgBox.MessageBoxType.Error);
            }
            finally
            {
                // Trả con trỏ chuột về bình thường
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnCheckIn_Click(object? sender, EventArgs e)
        {
            MsgBox.Show("Tính năng Quét thẻ RFID / Vân tay / Nhập mã NV để điểm danh ca làm việc.", "Chấm Công", MsgBox.MessageBoxType.Info);
        }

        private void BtnApproveLeave_Click(object? sender, EventArgs e)
        {
            MsgBox.Show("Đã DUYỆT đơn xin nghỉ của [NV03 Lê Văn C]. Dữ liệu đã cập nhật vào tính lương cuối tháng.", "Duyệt Nghỉ Phép", MsgBox.MessageBoxType.Success);
            lstLeaveq.Items.Clear();
            lstLeaveq.Items.Add("✔️ Không còn đơn xin nghỉ nào cần duyệt.");
            btnApproveLeave.Enabled = false;
        }

        private async void btnAddStaff_Click(object sender, EventArgs e)
        {
            AddEmployee frmAdd = new AddEmployee();
            // Mở form lên dưới dạng hộp thoại (người dùng phải đóng form này mới thao tác tiếp được với nền bên dưới)
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                // Đoạn code này sẽ chạy nếu bên form AddEmployee bạn lưu thành công 
                // và đã gán: this.DialogResult = DialogResult.OK;
                await LoadRealData();
                MsgBox.Show("Danh sách nhân viên mới đã được cập nhật!", "Thông báo", MsgBox.MessageBoxType.Success);

                // Gọi hàm load lại dữ liệu lên DataGridView ở đây (nếu có)
                // Ví dụ: LoadStaffData();
            }
        }



        private void lblPresentValue_Click(object sender, EventArgs e)
        {

        }

        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã chọn dòng nào chưa
            if (dgvStaff.CurrentRow == null || dgvStaff.CurrentRow.Index < 0)
            {
                MsgBox.Show("Vui lòng chọn một nhân viên từ danh sách để chỉnh sửa!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }

            // 2. Lấy dữ liệu từ dòng đang chọn
            DataGridViewRow row = dgvStaff.CurrentRow;

            // 3. Tạo đối tượng DTO chứa dữ liệu
            EmployeeDTO empToEdit = new EmployeeDTO
            {
                EmployeeId = row.Cells["Mã NV"].Value?.ToString(),
                FullName = row.Cells["Họ và Tên"].Value?.ToString(),
                Role = row.Cells["Vị Trí"].Value?.ToString(),
                Status = row.Cells["Trạng Thái"].Value?.ToString(),
                PhoneNumber = row.Cells["Số điện thoại"].Value?.ToString(), // Lấy SĐT ẩn
                AuthUid = row.Cells["AuthUid"].Value?.ToString()
            };

            // 4. Mở Form Edit
            EditEmployee frmEdit = new EditEmployee(empToEdit);
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                // Load lại danh sách nếu lưu thành công
                _ = LoadRealData();
            }
        }

        private void dgvStaff_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào tiêu đề cột
            if (e.RowIndex < 0) return;

            // Lấy dữ liệu dòng được click đúp
            DataGridViewRow row = dgvStaff.Rows[e.RowIndex];

            // Gói dữ liệu
            EmployeeDTO empDetails = new EmployeeDTO
            {
                EmployeeId = row.Cells["Mã NV"].Value?.ToString(),
                FullName = row.Cells["Họ và Tên"].Value?.ToString(),
                Role = row.Cells["Vị Trí"].Value?.ToString(),
                Status = row.Cells["Trạng Thái"].Value?.ToString(),
                PhoneNumber = row.Cells["Số điện thoại"].Value?.ToString(),
                AuthUid = row.Cells["AuthUid"].Value?.ToString()
            };

            // Mở Form CHỈ XEM CHI TIẾT (Read-only)
            // Giả sử bạn sẽ tạo một form tên là EmployeeDetail
            InformationStaff frmDetail = new InformationStaff(empDetails);
            frmDetail.ShowDialog();
        }
    }
}