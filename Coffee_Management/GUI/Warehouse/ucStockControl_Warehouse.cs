using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucStockControl_Warehouse : UserControl
    {
        public ucStockControl_Warehouse()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadMockData();
        }

        private void LoadMockData()
        {
            DataTable dt = new();
            dt.Columns.Add("Mã NL");
            dt.Columns.Add("Tên nguyên liệu");
            dt.Columns.Add("Đơn vị");
            dt.Columns.Add("Tồn kho", typeof(decimal));
            dt.Columns.Add("Tối thiểu", typeof(decimal));
            dt.Columns.Add("Trạng thái");
            dt.Columns.Add("Cập nhật");

            dt.Rows.Add("NL001", "Cà phê hạt Arabica", "kg", 25.5m, 10m, "Đủ hàng", "02/05/2026");
            dt.Rows.Add("NL002", "Sữa tươi", "lít", 8m, 15m, "Sắp hết", "02/05/2026");
            dt.Rows.Add("NL003", "Sữa đặc", "lon", 45m, 20m, "Đủ hàng", "01/05/2026");
            dt.Rows.Add("NL004", "Đường", "kg", 18m, 10m, "Đủ hàng", "01/05/2026");
            dt.Rows.Add("NL005", "Bột cacao", "kg", 2.5m, 5m, "Sắp hết", "02/05/2026");
            dt.Rows.Add("NL006", "Trà đào", "gói", 30m, 10m, "Đủ hàng", "30/04/2026");
            dt.Rows.Add("NL007", "Sả tươi", "bó", 3m, 5m, "Sắp hết", "02/05/2026");
            dt.Rows.Add("NL008", "Đào ngâm", "hộp", 12m, 5m, "Đủ hàng", "30/04/2026");
            dt.Rows.Add("NL009", "Trân châu", "kg", 1.2m, 3m, "Sắp hết", "02/05/2026");
            dt.Rows.Add("NL010", "Syrup vanilla", "chai", 8m, 3m, "Đủ hàng", "01/05/2026");
            dt.Rows.Add("NL011", "Đá viên", "bao", 4m, 10m, "Sắp hết", "02/05/2026");
            dt.Rows.Add("NL012", "Bơ", "kg", 6m, 3m, "Đủ hàng", "01/05/2026");

            dgvStock.DataSource = dt;
            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStock.RowHeadersVisible = false;

            dgvStock.Columns["Mã NL"].FillWeight = 8;
            dgvStock.Columns["Tên nguyên liệu"].FillWeight = 25;
            dgvStock.Columns["Tồn kho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStock.Columns["Tối thiểu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Color rows by status
            foreach (DataGridViewRow row in dgvStock.Rows)
            {
                if (row.Cells["Trạng thái"].Value?.ToString() == "Sắp hết")
                    row.DefaultCellStyle.ForeColor = Color.IndianRed;
            }

            // Update summary
            int lowStockCount = 0;
            foreach (DataRow r in dt.Rows)
                if (r["Trạng thái"].ToString() == "Sắp hết") lowStockCount++;

            lblTotalItems.Text = dt.Rows.Count.ToString();
            lblLowStock.Text = lowStockCount.ToString();
            lblLastUpdate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnNewImport_Click(object sender, EventArgs e)
        {
            StockTransaction frm = new(StockTransaction.TransactionType.Import);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadMockData();
        }

        private void btnNewExport_Click(object sender, EventArgs e)
        {
            StockTransaction frm = new(StockTransaction.TransactionType.Export);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadMockData();
        }

        private void btnNewWaste_Click(object sender, EventArgs e)
        {
            StockTransaction frm = new(StockTransaction.TransactionType.Waste);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadMockData();
        }

        private void btnAttachPhoto_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new();
            ofd.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Title = "Chọn ảnh đính kèm";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                MsgBox.Show($"Đã đính kèm ảnh: {System.IO.Path.GetFileName(ofd.FileName)}", "Thành công", MsgBox.MessageBoxType.Success);
            }
        }
    }
}
