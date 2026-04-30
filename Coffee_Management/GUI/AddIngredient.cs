using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace GUI
{
    public partial class AddIngredient : Form
    {
        private NhapKhoBUS _bus = new NhapKhoBUS();
        public AddIngredient()
        {
            InitializeComponent();
            this.Load += AddIngredient_Load;

        }

        private async void AddIngredient_Load(object sender, EventArgs e)
        {
            try
            {
                // Gọi BUS lấy danh sách nhân viên (Trả về List<EmployeeDTO>)
                var dsNhanVien = await _bus.LấyDanhSachNhanVien();

                cboNhanVien.DataSource = dsNhanVien;

                // Cập nhật lại cho đúng với thuộc tính của EmployeeDTO
                cboNhanVien.DisplayMember = "FullName";
                cboNhanVien.ValueMember = "EmployeeId";

                // Reset mặc định không chọn ai
                cboNhanVien.SelectedIndex = -1;
                cboNhanVien.Text = "Chọn nhân viên";

                var dsNguyenLieu = await _bus.LayDanhSachNguyenLieu();

                // Thêm check: Nếu danh sách rỗng, báo ngay để biết lỗi do Firebase chứ không phải do giao diện
                if (dsNguyenLieu == null || dsNguyenLieu.Count == 0)
                {
                    MessageBox.Show("Firebase không trả về nguyên liệu nào, hãy kiểm tra lại DAL!", "Cảnh báo");
                }

                // Ép kiểu cột đó thành DataGridViewComboBoxColumn (thay "colMaNL" bằng tên thật của cột nếu bạn đặt khác)
                DataGridViewComboBoxColumn cboNguyenLieuCol = (DataGridViewComboBoxColumn)dgvChiTietNhap.Columns["colMaNL"];

                cboNguyenLieuCol.DataSource = dsNguyenLieu;

                // CÁI NÀY LÀ QUAN TRỌNG NHẤT NÈ:
                cboNguyenLieuCol.DisplayMember = "TenNguyenLieu"; // Hiển thị chữ "Cà phê hạt" cho người dùng chọn
                cboNguyenLieuCol.ValueMember = "Id";

                // THÊM 2 DÒNG NÀY ĐỂ FIX LỖI GIAO DIỆN XỔ XUỐNG:
                // 1. Luôn hiện cái mũi tên xổ xuống giống nhân viên
                cboNguyenLieuCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                // 2. Bấm 1 phát là xổ danh sách ra luôn (không cần click 3 lần như mặc định)
                dgvChiTietNhap.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra xem người dùng đã chọn nhân viên chưa
                if (cboNhanVien.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên thực hiện nhập kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Chuyển đổi ngày tháng hiện tại (hoặc từ dtpNgayNhap) sang số nguyên (Unix time)
                int ngayNhapUnix = (int)((DateTimeOffset)dtpNgayNhap.Value).ToUnixTimeSeconds();

                // 3. Gom dữ liệu từ DataGridView thành Dictionary
                var danhSachNguyenLieu = new Dictionary<string, ChiTietNhapDTO>();

                foreach (DataGridViewRow row in dgvChiTietNhap.Rows)
                {
                    // Đảm bảo dòng không trống và cột Mã NL (colMaNL) đã được nhập
                    if (!row.IsNewRow && row.Cells["colMaNL"].Value != null)
                    {
                        string maNL = row.Cells["colMaNL"].Value.ToString();

                        var chiTiet = new ChiTietNhapDTO
                        {
                            SoLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value ?? 0),
                            GiaNhap = Convert.ToInt64(row.Cells["colGiaNhap"].Value ?? 0)
                            // ThanhTien sẽ được BUS tự động tính toán
                        };

                        danhSachNguyenLieu[maNL] = chiTiet;
                    }
                }

                // Kiểm tra xem có nguyên liệu nào được nhập không
                if (danhSachNguyenLieu.Count == 0)
                {
                    MessageBox.Show("Vui lòng nhập ít nhất một nguyên liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Đóng gói dữ liệu vào DTO tổng
                NhapKhoDTO phieuMoi = new NhapKhoDTO
                {
                    NhanVienId = cboNhanVien.SelectedValue.ToString(), // Đã check null ở trên
                    GhiChu = txtGhiChu.Text,
                    NgayNhap = ngayNhapUnix,
                    DanhSachNL = danhSachNguyenLieu
                    // TongTien sẽ được BUS tự động tính
                };

                // 5. Gửi DTO qua BUS xử lý và nhận kết quả
                string ketQua = await _bus.TaoPhieuNhap(phieuMoi);

                if (ketQua == "Thành công")
                {
                    MessageBox.Show("Nhập kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset lại giao diện sau khi lưu thành công
                    txtGhiChu.Clear();
                    dgvChiTietNhap.Rows.Clear();
                    cboNhanVien.SelectedIndex = -1;
                    cboNhanVien.Text = "Chọn nhân viên";
                }
                else
                {
                    MessageBox.Show(ketQua, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Dữ liệu nhập vào chưa hợp lệ (Kiểm tra lại cột 'Số lượng' và 'Giá nhập' phải là số).", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bttnTinhTien_Click(object sender, EventArgs e)
        {
            long tongTien = 0;

            // Đã thay "dataGridView1" thành "dgvChiTietNhap" chuẩn theo tên Form của bạn
            foreach (DataGridViewRow row in dgvChiTietNhap.Rows)
            {
                // Bỏ qua dòng trống cuối cùng
                if (row.IsNewRow) continue;

                // Lấy ô Số lượng (Cột 1) và Giá nhập (Cột 2)
                var cellSoLuong = row.Cells[1].Value;
                var cellGiaNhap = row.Cells[2].Value;

                if (cellSoLuong != null && cellGiaNhap != null)
                {
                    if (int.TryParse(cellSoLuong.ToString(), out int soLuong) &&
                        long.TryParse(cellGiaNhap.ToString(), out long giaNhap))
                    {
                        // Cộng dồn vào tổng tiền
                        tongTien += (soLuong * giaNhap);
                    }
                }
            }

            // Gắn vào Label Thành tiền (Nếu label của bạn tên khác thì nhớ sửa "lblThanhTien" nhé)
            lblTongTien.Text = $"Tổng tiền: {tongTien:N0} đ";
        }

        private void AddIngredient_Load_1(object sender, EventArgs e)
        {

        }
    }
}