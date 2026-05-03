using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucWorkTracking : UserControl
    {
        private bool _checkedIn = false;
        private DateTime _checkInTime;

        public ucWorkTracking()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadMockData();
            btnCheckIn.Click += btnCheckIn_Click;
            btnCheckOut.Click += btnCheckOut_Click;
        }

        private void LoadMockData()
        {
            lblTotalShiftsValue.Text = "22 ca";
            lblTotalHoursValue.Text = "176 giờ";
            lblCheckStatus.Text = "Chưa chấm công";
            lblCheckStatus.ForeColor = Color.Gray;
            lblCheckTime.Text = "";

            DataTable dt = new();
            dt.Columns.Add("Ngày");
            dt.Columns.Add("Check-in");
            dt.Columns.Add("Check-out");
            dt.Columns.Add("Số giờ");
            dt.Columns.Add("Trạng thái");

            dt.Rows.Add("02/05/2026", "07:55", "16:05", "8.2h", "Đủ giờ");
            dt.Rows.Add("01/05/2026", "08:10", "16:00", "7.8h", "Đủ giờ");
            dt.Rows.Add("30/04/2026", "07:50", "12:00", "4.2h", "Nửa ca");
            dt.Rows.Add("29/04/2026", "08:00", "16:15", "8.3h", "Đủ giờ");
            dt.Rows.Add("28/04/2026", "08:30", "16:00", "7.5h", "Đủ giờ");
            dt.Rows.Add("27/04/2026", "--", "--", "--", "Nghỉ phép");
            dt.Rows.Add("26/04/2026", "07:45", "16:10", "8.4h", "Đủ giờ");

            dgvWorkTracking.DataSource = dt;
            dgvWorkTracking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWorkTracking.RowHeadersVisible = false;
            dgvWorkTracking.ReadOnly = true;
            dgvWorkTracking.AllowUserToAddRows = false;

            foreach (DataGridViewRow row in dgvWorkTracking.Rows)
            {
                string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                if (status == "Đủ giờ")
                    row.DefaultCellStyle.ForeColor = Color.MediumSeaGreen;
                else if (status == "Nửa ca")
                    row.DefaultCellStyle.ForeColor = Color.Orange;
                else if (status == "Nghỉ phép")
                    row.DefaultCellStyle.ForeColor = Color.SteelBlue;
            }
        }

        private void btnCheckIn_Click(object? sender, EventArgs e)
        {
            if (_checkedIn)
            {
                MsgBox.Show("Bạn đã check-in rồi!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            _checkedIn = true;
            _checkInTime = DateTime.Now;
            lblCheckStatus.Text = "Đã check-in";
            lblCheckStatus.ForeColor = Color.MediumSeaGreen;
            lblCheckTime.Text = $"Vào lúc: {_checkInTime:HH:mm}";
            lblCheckTime.ForeColor = Color.White;
            btnCheckIn.Enabled = false;
            MsgBox.Show($"Check-in thành công lúc {_checkInTime:HH:mm}!", "Chấm công", MsgBox.MessageBoxType.Success);
        }

        private void btnCheckOut_Click(object? sender, EventArgs e)
        {
            if (!_checkedIn)
            {
                MsgBox.Show("Bạn chưa check-in!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            DateTime checkOutTime = DateTime.Now;
            double hours = (checkOutTime - _checkInTime).TotalHours;
            _checkedIn = false;
            btnCheckIn.Enabled = true;
            lblCheckStatus.Text = "Đã check-out";
            lblCheckStatus.ForeColor = Color.Orange;
            lblCheckTime.Text = $"Ra lúc: {checkOutTime:HH:mm} ({hours:F1}h)";

            MsgBox.Show($"Check-out thành công lúc {checkOutTime:HH:mm}!\nTổng giờ làm: {hours:F1} giờ", "Chấm công", MsgBox.MessageBoxType.Success);
        }
    }
}
