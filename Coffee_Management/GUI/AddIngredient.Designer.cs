namespace GUI
{
    partial class AddIngredient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtGhiChu = new TextBox();
            dtpNgayNhap = new DateTimePicker();
            cboNhanVien = new ComboBox();
            dgvChiTietNhap = new DataGridView();
            colMaNL = new DataGridViewComboBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colGiaNhap = new DataGridViewTextBoxColumn();
            lblTongTien = new Label();
            btnLuu = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).BeginInit();
            SuspendLayout();
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(224, 72);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.PlaceholderText = "Ghi chú";
            txtGhiChu.Size = new Size(256, 27);
            txtGhiChu.TabIndex = 0;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Location = new Point(224, 120);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(250, 27);
            dtpNgayNhap.TabIndex = 1;
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(224, 168);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(151, 28);
            cboNhanVien.TabIndex = 2;
            cboNhanVien.Text = "Chọn nhân viên";
            // 
            // dgvChiTietNhap
            // 
            dgvChiTietNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietNhap.Columns.AddRange(new DataGridViewColumn[] { colMaNL, colSoLuong, colGiaNhap });
            dgvChiTietNhap.Location = new Point(192, 224);
            dgvChiTietNhap.Name = "dgvChiTietNhap";
            dgvChiTietNhap.RowHeadersWidth = 51;
            dgvChiTietNhap.Size = new Size(448, 188);
            dgvChiTietNhap.TabIndex = 3;
            // 
            // colMaNL
            // 
            colMaNL.HeaderText = "Mã nguyên liệu";
            colMaNL.MinimumWidth = 6;
            colMaNL.Name = "colMaNL";
            colMaNL.Width = 125;
            // 
            // colSoLuong
            // 
            colSoLuong.HeaderText = "Số lượng";
            colSoLuong.MinimumWidth = 6;
            colSoLuong.Name = "colSoLuong";
            colSoLuong.Width = 125;
            // 
            // colGiaNhap
            // 
            colGiaNhap.HeaderText = "Giá nhập";
            colGiaNhap.MinimumWidth = 6;
            colGiaNhap.Name = "colGiaNhap";
            colGiaNhap.Width = 125;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblTongTien.Location = new Point(224, 432);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(103, 28);
            lblTongTien.TabIndex = 4;
            lblTongTien.Text = "Thành tiền";
            // 
            // btnLuu
            // 
            btnLuu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnLuu.Location = new Point(232, 472);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(112, 40);
            btnLuu.TabIndex = 5;
            btnLuu.Text = "Tạo nhập kho";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // AddIngredient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 616);
            Controls.Add(btnLuu);
            Controls.Add(lblTongTien);
            Controls.Add(dgvChiTietNhap);
            Controls.Add(cboNhanVien);
            Controls.Add(dtpNgayNhap);
            Controls.Add(txtGhiChu);
            Name = "AddIngredient";
            Text = "AddIngredient";
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtGhiChu;
        private DateTimePicker dtpNgayNhap;
        private ComboBox cboNhanVien;
        private DataGridView dgvChiTietNhap;
        private Label lblTongTien;
        private Button btnLuu;
        private DataGridViewComboBoxColumn colMaNL;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colGiaNhap;
    }
}