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
    public partial class ucProducts_Manager : UserControl
    {

        private readonly FoodBUS _foodBus = new FoodBUS();

        public ucProducts_Manager()
        {
            InitializeComponent();
            this.Load += UcProducts_Manager_Load;
            //LoadDummyData();
        }
        /*private void LoadDummyData()
        {
            DataTable dtMenu = new DataTable();
            dtMenu.Columns.Add("Món");
            dtMenu.Columns.Add("Giá Bán");
            dtMenu.Columns.Add("Đã Bán HN");
            dtMenu.Rows.Add("Cà phê Đen", "20,000 đ", "45 ly");
            dtMenu.Rows.Add("Cà phê Sữa", "25,000 đ", "80 ly");
            dtMenu.Rows.Add("Trà Đào", "30,000 đ", "30 ly");
            dtMenu.Rows.Add("Bạc Xỉu", "25,000 đ", "55 ly");
            dgvMenu.DataSource = dtMenu;
            dgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMenu.RowHeadersVisible = false;
            DataTable dtKho = new DataTable();
            dtKho.Columns.Add("Nguyên Liệu");
            dtKho.Columns.Add("Tồn Kho");
            dtKho.Columns.Add("Chi Phí Nhập");
            dtKho.Rows.Add("Cà phê hạt", "5 kg (Sắp hết)", "500,000 đ");
            dtKho.Rows.Add("Sữa đặc", "20 hộp", "0 đ");
            dtKho.Rows.Add("Trà lài", "2 kg", "0 đ");
            dtKho.Rows.Add("Đường cát", "1 kg (Hết)", "350,000 đ");
            dgvInventory.DataSource = dtKho;
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.RowHeadersVisible = false;
        }*/

        private void UcProducts_Manager_Load(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        public async void LoadDataToGrid()
        {
            // Gọi BUS lấy danh sách
            List<FoodDTO> list = await _foodBus.GetListFoods();
            dgvMenu.DataSource = null;
            if (list != null && list.Count > 0)
            {
                dgvMenu.DataSource = list;
                SetupGridColumns();
            }
        }

        private void SetupGridColumns()
        {
            // 1. Ẩn cột ID để người dùng không thấy mã mon_xxx
            if (dgvMenu.Columns["Id"] != null)
                dgvMenu.Columns["Id"].Visible = false;

            // 2. Ẩn các cột kỹ thuật không cần hiện lên bảng Menu
            string[] hideCols = { "HinhAnhUrl", "Loai", "MoTa", "HienThi", "ConHang" };
            foreach (var col in hideCols)
            {
                if (dgvMenu.Columns[col] != null) dgvMenu.Columns[col].Visible = false;
            }

            // 3. Đặt lại tên tiêu đề cột khớp với UI yêu cầu
            if (dgvMenu.Columns["TenMon"] != null)
                dgvMenu.Columns["TenMon"].HeaderText = "Món";

            if (dgvMenu.Columns["Gia"] != null)
            {
                dgvMenu.Columns["Gia"].HeaderText = "Giá Bán";
                dgvMenu.Columns["Gia"].DefaultCellStyle.Format = "N0"; // Hiển thị 20,000
            }

            // Tự động giãn các cột cho vừa khung hình
            dgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMenu.RowHeadersVisible = false; // Ẩn cột đầu dòng cho giống UI mẫu
        }
        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            AddMonUong aFood = new AddMonUong();
            aFood.FoodAdded += LoadDataToGrid;
            aFood.Show();
        }

        private async void btnDeleteMenu_Click(object sender, EventArgs e)
        {
            if (dgvMenu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một món trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy ID (từ cột ẩn) và tên món để xác nhận
            string idCanXoa = dgvMenu.CurrentRow.Cells["Id"].Value?.ToString();
            string tenMon = dgvMenu.CurrentRow.Cells["TenMon"].Value?.ToString();

            // 3. Hỏi xác nhận để tránh xóa nhầm
            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa '{tenMon}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                btnDeleteMenu.Enabled = false; // Chặn bấm liên tục

                // 4. Gọi BUS thực hiện xóa trên Firebase
                var result = await _foodBus.DeleteFood(idCanXoa);

                if (result.Success)
                {
                    MessageBox.Show(result.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataToGrid(); // Refresh lại bảng sau khi xóa thành công
                }
                else
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                btnDeleteMenu.Enabled = true;
            }
        }

        private void btnImportMaterial_Click(object sender, EventArgs e)
        {
            AddIngredient aIngredient = new AddIngredient();
            aIngredient.ShowDialog();
        }
    }
}
