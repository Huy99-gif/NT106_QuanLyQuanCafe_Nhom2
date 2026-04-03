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
    public partial class ucOrders_Manager : UserControl
    {
        public ucOrders_Manager()
        {
            InitializeComponent();
            LoadDummyData();
        }

        private void LoadDummyData()
        {
            DataTable dtTables = new DataTable();
            dtTables.Columns.Add("Bàn");
            dtTables.Columns.Add("Trạng Thái");
            dtTables.Columns.Add("Tiến độ món");
            dtTables.Columns.Add("Tạm Tính");
            dtTables.Rows.Add("Bàn 01", "Đang phục vụ", "Đã lên đủ", "150,000 đ");
            dtTables.Rows.Add("Bàn 02", "Chờ lên món", "Thiếu 2 món", "85,000 đ");
            dtTables.Rows.Add("Bàn 05", "Chờ lên món", "Thiếu 1 món", "45,000 đ");
            dtTables.Rows.Add("Bàn 08", "Đang phục vụ", "Đã lên đủ", "210,000 đ");
            dtTables.Rows.Add("Bàn 12", "Chờ thanh toán", "Đã xong", "320,000 đ");
            dgvTableStatus.DataSource = dtTables;
            dgvTableStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTableStatus.RowHeadersVisible = false;
            lstSoldOut.Items.Clear();
            lstSoldOut.Items.Add("❌ Bánh ngọt Tiramisu");
            lstSoldOut.Items.Add("❌ Sinh tố Bơ");
            lstSoldOut.Items.Add("❌ Trà sen vàng (Hết hạt sen)");
            lstKitchenWarning.Items.Clear();
            lstKitchenWarning.Items.Add("⚠️ Bàn 02: Cà phê sữa đá (Đợi 18 phút)");
            lstKitchenWarning.Items.Add("⚠️ Bàn 05: Trà đào cam sả (Đợi 15 phút)");
            lstKitchenWarning.Items.Add("🔥 Bàn 15: Sinh tố dâu (Đợi 25 phút - Quá lâu!)");
        }

        private void lstSoldOut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
