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
using BUS;

namespace GUI
{
    public partial class AddMonUong : Form
    {
        private readonly FoodBUS _foodBus = new FoodBUS();
        public AddMonUong()
        {
            InitializeComponent();
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {

        }

        public event Action FoodAdded;
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
         
            var food = new FoodDTO
            {
                TenMon = txtTenMon.Text,
                Gia = decimal.TryParse(txtGia.Text, out decimal g) ? g : 0,
                MoTa = txtMoTa.Text,
                Loai = cmLoai.Text,
                HienThi = true,
                ConHang = true,
                HinhAnhUrl = ""
            };

            var result = await _foodBus.AddNewFood(food);

            MessageBox.Show(result.Message);

            if (result.Success)
            {
               
                FoodAdded?.Invoke();

                // Clear form
                txtTenMon.Clear();
                txtGia.Clear();
                txtMoTa.Clear();
                cmLoai.SelectedIndex = -1; // Reset combobox
            }

            btnAdd.Enabled = true;
        }

        private void bttnClear_Click(object sender, EventArgs e)
        {
            txtTenMon.Text = string.Empty;
            txtGia.Text = string.Empty;
            txtMoTa.Text = string.Empty; 
            cmLoai.Text = string.Empty; 
            txtTenMon.Focus();
        }
    }
}
