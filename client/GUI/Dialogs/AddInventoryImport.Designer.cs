using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class AddInventoryImport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            txtGhiChu = new TextBox();
            dtpNgayNhap = new DateTimePicker();
            cboNhanVien = new ComboBox();
            dgvChiTietNhap = new DataGridView();
            colMaNL = new DataGridViewComboBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colGiaNhap = new DataGridViewTextBoxColumn();
            lblTongTien = new Label();
            btnLuu = new Button();
            btnHuy = new Button();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            pnlInfo = new Panel();
            lblInfoTitle = new Label();
            lblNgayNhap = new Label();
            lblNhanVien = new Label();
            lblGhiChu = new Label();
            pnlDetail = new Panel();
            lblDetailTitle = new Label();
            lblHint = new Label();
            pnlFooter = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).BeginInit();
            pnlHeader.SuspendLayout();
            pnlInfo.SuspendLayout();
            pnlDetail.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // txtGhiChu
            // 
            txtGhiChu.BackColor = Color.FromArgb(60, 60, 65);
            txtGhiChu.BorderStyle = BorderStyle.FixedSingle;
            txtGhiChu.Font = new Font("Segoe UI", 10F);
            txtGhiChu.ForeColor = Color.White;
            txtGhiChu.Location = new Point(495, 46);
            txtGhiChu.Margin = new Padding(3, 2, 3, 2);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.PlaceholderText = "Lý do nhập / nhà cung cấp...";
            txtGhiChu.Size = new Size(226, 25);
            txtGhiChu.TabIndex = 6;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy   HH:mm";
            dtpNgayNhap.Font = new Font("Segoe UI", 10F);
            dtpNgayNhap.Format = DateTimePickerFormat.Custom;
            dtpNgayNhap.Location = new Point(12, 46);
            dtpNgayNhap.Margin = new Padding(3, 2, 3, 2);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(193, 25);
            dtpNgayNhap.TabIndex = 2;
            // 
            // cboNhanVien
            // 
            cboNhanVien.BackColor = Color.FromArgb(60, 60, 65);
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.FlatStyle = FlatStyle.Flat;
            cboNhanVien.Font = new Font("Segoe UI", 10F);
            cboNhanVien.ForeColor = Color.White;
            cboNhanVien.Location = new Point(228, 46);
            cboNhanVien.Margin = new Padding(3, 2, 3, 2);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(246, 25);
            cboNhanVien.TabIndex = 4;
            // 
            // dgvChiTietNhap
            // 
            dgvChiTietNhap.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvChiTietNhap.BorderStyle = BorderStyle.None;
            dgvChiTietNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvChiTietNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietNhap.Columns.AddRange(new DataGridViewColumn[] { colMaNL, colSoLuong, colGiaNhap });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvChiTietNhap.DefaultCellStyle = dataGridViewCellStyle4;
            dgvChiTietNhap.EnableHeadersVisualStyles = false;
            dgvChiTietNhap.GridColor = Color.FromArgb(70, 70, 75);
            dgvChiTietNhap.Location = new Point(12, 42);
            dgvChiTietNhap.Margin = new Padding(3, 2, 3, 2);
            dgvChiTietNhap.Name = "dgvChiTietNhap";
            dgvChiTietNhap.RowHeadersWidth = 30;
            dgvChiTietNhap.RowTemplate.Height = 30;
            dgvChiTietNhap.Size = new Size(710, 170);
            dgvChiTietNhap.TabIndex = 2;
            // 
            // colMaNL
            // 
            colMaNL.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMaNL.FillWeight = 50F;
            colMaNL.HeaderText = "Mã nguyên liệu";
            colMaNL.MinimumWidth = 6;
            colMaNL.Name = "colMaNL";
            // 
            // colSoLuong
            // 
            colSoLuong.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSoLuong.DefaultCellStyle = dataGridViewCellStyle2;
            colSoLuong.FillWeight = 20F;
            colSoLuong.HeaderText = "Số lượng";
            colSoLuong.MinimumWidth = 6;
            colSoLuong.Name = "colSoLuong";
            // 
            // colGiaNhap
            // 
            colGiaNhap.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            colGiaNhap.DefaultCellStyle = dataGridViewCellStyle3;
            colGiaNhap.FillWeight = 30F;
            colGiaNhap.HeaderText = "Giá nhập (VNĐ)";
            colGiaNhap.MinimumWidth = 6;
            colGiaNhap.Name = "colGiaNhap";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.MediumSeaGreen;
            lblTongTien.Location = new Point(12, 10);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(174, 25);
            lblTongTien.TabIndex = 0;
            lblTongTien.Text = "Thành tiền: 0 VNĐ";
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.SteelBlue;
            btnLuu.Cursor = Cursors.Hand;
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(623, 8);
            btnLuu.Margin = new Padding(3, 2, 3, 2);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(105, 27);
            btnLuu.TabIndex = 2;
            btnLuu.Text = "Tạo phiếu nhập";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.FromArgb(60, 60, 65);
            btnHuy.Cursor = Cursors.Hand;
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI", 10F);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(530, 8);
            btnHuy.Margin = new Padding(3, 2, 3, 2);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(88, 27);
            btnHuy.TabIndex = 1;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(30, 30, 30);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 2, 3, 2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(770, 52);
            pnlHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(202, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "PHIẾU NHẬP KHO";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblSubtitle.ForeColor = Color.Silver;
            lblSubtitle.Location = new Point(18, 39);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(255, 15);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Ghi nhận nguyên liệu nhập vào kho theo phiếu";
            // 
            // pnlInfo
            // 
            pnlInfo.BackColor = Color.FromArgb(45, 45, 48);
            pnlInfo.Controls.Add(lblInfoTitle);
            pnlInfo.Controls.Add(lblNgayNhap);
            pnlInfo.Controls.Add(dtpNgayNhap);
            pnlInfo.Controls.Add(lblNhanVien);
            pnlInfo.Controls.Add(cboNhanVien);
            pnlInfo.Controls.Add(lblGhiChu);
            pnlInfo.Controls.Add(txtGhiChu);
            pnlInfo.Location = new Point(18, 64);
            pnlInfo.Margin = new Padding(3, 2, 3, 2);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.Size = new Size(735, 98);
            pnlInfo.TabIndex = 2;
            // 
            // lblInfoTitle
            // 
            lblInfoTitle.AutoSize = true;
            lblInfoTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInfoTitle.ForeColor = Color.SteelBlue;
            lblInfoTitle.Location = new Point(12, 6);
            lblInfoTitle.Name = "lblInfoTitle";
            lblInfoTitle.Size = new Size(113, 19);
            lblInfoTitle.TabIndex = 0;
            lblInfoTitle.Text = "Thông tin phiếu";
            // 
            // lblNgayNhap
            // 
            lblNgayNhap.AutoSize = true;
            lblNgayNhap.Font = new Font("Segoe UI", 9.5F);
            lblNgayNhap.ForeColor = Color.White;
            lblNgayNhap.Location = new Point(12, 30);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Size = new Size(75, 17);
            lblNgayNhap.TabIndex = 1;
            lblNgayNhap.Text = "Ngày nhập:";
            // 
            // lblNhanVien
            // 
            lblNhanVien.AutoSize = true;
            lblNhanVien.Font = new Font("Segoe UI", 9.5F);
            lblNhanVien.ForeColor = Color.White;
            lblNhanVien.Location = new Point(228, 30);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(126, 17);
            lblNhanVien.TabIndex = 3;
            lblNhanVien.Text = "Nhân viên thực hiện:";
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Font = new Font("Segoe UI", 9.5F);
            lblGhiChu.ForeColor = Color.White;
            lblGhiChu.Location = new Point(495, 30);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(54, 17);
            lblGhiChu.TabIndex = 5;
            lblGhiChu.Text = "Ghi chú:";
            // 
            // pnlDetail
            // 
            pnlDetail.BackColor = Color.FromArgb(45, 45, 48);
            pnlDetail.Controls.Add(lblDetailTitle);
            pnlDetail.Controls.Add(lblHint);
            pnlDetail.Controls.Add(dgvChiTietNhap);
            pnlDetail.Location = new Point(18, 170);
            pnlDetail.Margin = new Padding(3, 2, 3, 2);
            pnlDetail.Name = "pnlDetail";
            pnlDetail.Size = new Size(735, 222);
            pnlDetail.TabIndex = 1;
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.AutoSize = true;
            lblDetailTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.SteelBlue;
            lblDetailTitle.Location = new Point(12, 6);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(174, 19);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.Text = "Chi tiết nguyên liệu nhập";
            // 
            // lblHint
            // 
            lblHint.AutoSize = true;
            lblHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblHint.ForeColor = Color.LightGray;
            lblHint.Location = new Point(12, 22);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(482, 15);
            lblHint.TabIndex = 1;
            lblHint.Text = "Thêm dòng → chọn mã nguyên liệu → giá nhập tự động điền (có thể sửa) → nhập số lượng";
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(30, 30, 30);
            pnlFooter.Controls.Add(lblTongTien);
            pnlFooter.Controls.Add(btnHuy);
            pnlFooter.Controls.Add(btnLuu);
            pnlFooter.Location = new Point(18, 399);
            pnlFooter.Margin = new Padding(3, 2, 3, 2);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(735, 42);
            pnlFooter.TabIndex = 0;
            // 
            // AddInventoryImport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 37, 38);
            CancelButton = btnHuy;
            ClientSize = new Size(770, 456);
            Controls.Add(pnlFooter);
            Controls.Add(pnlDetail);
            Controls.Add(pnlInfo);
            Controls.Add(pnlHeader);
            Cursor = Cursors.AppStarting;
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddInventoryImport";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tạo phiếu nhập kho";
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlInfo.ResumeLayout(false);
            pnlInfo.PerformLayout();
            pnlDetail.ResumeLayout(false);
            pnlDetail.PerformLayout();
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox        txtGhiChu;
        private DateTimePicker dtpNgayNhap;
        private ComboBox       cboNhanVien;
        private DataGridView   dgvChiTietNhap;
        private Label          lblTongTien;
        private Button         btnLuu;
        private Button         btnHuy;
        private DataGridViewComboBoxColumn colMaNL;
        private DataGridViewTextBoxColumn  colSoLuong;
        private DataGridViewTextBoxColumn  colGiaNhap;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlInfo;
        private Label lblInfoTitle;
        private Label lblNgayNhap;
        private Label lblNhanVien;
        private Label lblGhiChu;
        private Panel pnlDetail;
        private Label lblDetailTitle;
        private Label lblHint;
        private Panel pnlFooter;
    }
}
