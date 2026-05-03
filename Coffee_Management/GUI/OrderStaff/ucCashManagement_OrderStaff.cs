using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucCashManagement_OrderStaff : UserControl
    {
        private bool _shiftStarted = false;

        public ucCashManagement_OrderStaff()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadMockData();
        }

        private void LoadMockData()
        {
            lblOpenCash.Text = "2,000,000 đ";
            lblCurrentCash.Text = "3,450,000 đ";
            lblRevenue.Text = "1,450,000 đ";
            lblDifference.Text = "0 đ";
            lblDifference.ForeColor = Color.MediumSeaGreen;

            DataTable dt = new();
            dt.Columns.Add("Thời gian");
            dt.Columns.Add("Loại");
            dt.Columns.Add("Số tiền", typeof(decimal));
            dt.Columns.Add("Ghi chú");

            dt.Rows.Add("02/05/2026 08:00", "Mở ca", 2000000m, "Tiền đầu ca");
            dt.Rows.Add("02/05/2026 08:15", "Thu", 85000m, "Đơn #1001 - Tiền mặt");
            dt.Rows.Add("02/05/2026 08:32", "Thu", 120000m, "Đơn #1002 - Tiền mặt");
            dt.Rows.Add("02/05/2026 09:05", "Thu", 55000m, "Đơn #1003 - Tiền mặt");
            dt.Rows.Add("02/05/2026 09:45", "Chi", -50000m, "Mua đá viên");
            dt.Rows.Add("02/05/2026 10:10", "Thu", 195000m, "Đơn #1005 - Tiền mặt");
            dt.Rows.Add("02/05/2026 10:30", "Thu", 45000m, "Đơn #1006 - Tiền mặt");

            dgvTransactions.DataSource = dt;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.RowHeadersVisible = false;

            dgvTransactions.Columns["Số tiền"].DefaultCellStyle.Format = "N0";
            dgvTransactions.Columns["Số tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransactions.Columns["Ghi chú"].FillWeight = 35;
        }

        private void btnStartShift_Click(object sender, EventArgs e)
        {
            if (_shiftStarted)
            {
                MsgBox.Show("Ca làm việc đã được bắt đầu rồi!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            _shiftStarted = true;
            btnStartShift.Enabled = false;
            MsgBox.Show("Đã bắt đầu ca làm việc!\nTiền đầu ca: 2,000,000 đ", "Thành công", MsgBox.MessageBoxType.Success);
        }

        private void btnEndShift_Click(object sender, EventArgs e)
        {
            if (!_shiftStarted)
            {
                MsgBox.Show("Chưa bắt đầu ca làm việc!", "Thông báo", MsgBox.MessageBoxType.Warning);
                return;
            }
            var result = MessageBox.Show("Bạn có chắc muốn kết thúc ca?\nTiền cuối ca: 3,450,000 đ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _shiftStarted = false;
                btnStartShift.Enabled = true;
                MsgBox.Show("Đã kết thúc ca làm việc!\nDoanh thu ca: 1,450,000 đ\nChênh lệch: 0 đ", "Kết ca", MsgBox.MessageBoxType.Success);
            }
        }
    }
}
