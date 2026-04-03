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
        public ucProducts_Manager()
        {
            InitializeComponent();
            LoadDummyData(); 
        }
        private void LoadDummyData()
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
        }

    }
}
