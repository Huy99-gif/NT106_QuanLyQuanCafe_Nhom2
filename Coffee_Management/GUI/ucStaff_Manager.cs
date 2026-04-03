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
            LoadDummyData();
            btnAddStaff.Click += BtnAddStaff_Click;
            btnCheckIn.Click += BtnCheckIn_Click;
            btnApproveLeave.Click += BtnApproveLeave_Click;
        }

        private void LoadDummyData()
        {
            DataTable dtStaff = new DataTable();
            dtStaff.Columns.Add("Mã NV");
            dtStaff.Columns.Add("Họ và Tên");
            dtStaff.Columns.Add("Vị Trí");
            dtStaff.Columns.Add("Ca Làm");
            dtStaff.Rows.Add("NV01", "Nguyễn Văn A", "Pha Chế", "Ca Sáng");
            dtStaff.Rows.Add("NV02", "Trần Thị B", "Phục Vụ", "Ca Sáng");
            dtStaff.Rows.Add("NV03", "Lê Văn C", "Thu Ngân", "Ca Tối");
            dtStaff.Rows.Add("NV04", "Phạm Bảo D", "Bảo Vệ", "Full-time");
            dtStaff.Rows.Add("NV05", "Hoàng Kim E", "Phục Vụ", "Ca Tối");
            dgvStaff.DataSource = dtStaff;
            dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStaff.RowHeadersVisible = false;

            lstAttendance.Items.Clear();
            lstAttendance.Items.Add("✅ 06:45 - NV01 Nguyễn Văn A (Đúng giờ)");
            lstAttendance.Items.Add("✅ 06:55 - NV02 Trần Thị B (Đúng giờ)");
            lstAttendance.Items.Add("⚠️ 07:15 - NV04 Phạm Bảo D (Đi trễ)");
            lstAttendance.Items.Add("❌ NV05 Hoàng Kim E (Chưa check-in)");

            lstLeaveq.Items.Clear();
            lstLeaveq.Items.Add("📩 NV03 Lê Văn C");
            lstLeaveq.Items.Add("   Lý do: Đưa người nhà đi khám bệnh.");
            lstLeaveq.Items.Add("   Thời gian: Ca Tối (Hôm nay)");
        }

        private void BtnAddStaff_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Mở Form thêm nhân viên mới (Điền tên, tuổi, vị trí, mức lương...)", "Thêm Nhân Sự", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
