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
            bttnTinhTien = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(135, 71);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.PlaceholderText = "Ghi chú";
            txtGhiChu.Size = new Size(256, 27);
            txtGhiChu.TabIndex = 0;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Location = new Point(135, 119);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(250, 27);
            dtpNgayNhap.TabIndex = 1;
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(135, 167);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(151, 28);
            cboNhanVien.TabIndex = 2;
            cboNhanVien.Text = "Chọn nhân viên";
            // 
            // dgvChiTietNhap
            // 
            dgvChiTietNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietNhap.Columns.AddRange(new DataGridViewColumn[] { colMaNL, colSoLuong, colGiaNhap });
            dgvChiTietNhap.Location = new Point(135, 216);
            dgvChiTietNhap.Name = "dgvChiTietNhap";
            dgvChiTietNhap.RowHeadersWidth = 51;
            dgvChiTietNhap.Size = new Size(444, 188);
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
            lblTongTien.BackColor = Color.FromArgb(231, 76, 60);
            lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblTongTien.Location = new Point(95, 397);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(103, 28);
            lblTongTien.TabIndex = 4;
            lblTongTien.Text = "Thành tiền";
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(46, 204, 113);
            btnLuu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnLuu.Location = new Point(266, 503);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(147, 41);
            btnLuu.TabIndex = 5;
            btnLuu.Text = "Tạo nhập kho";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // bttnTinhTien
            // 
            bttnTinhTien.BackColor = Color.FromArgb(52, 152, 219);
            bttnTinhTien.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            bttnTinhTien.Location = new Point(424, 432);
            bttnTinhTien.Name = "bttnTinhTien";
            bttnTinhTien.Size = new Size(102, 36);
            bttnTinhTien.TabIndex = 6;
            bttnTinhTien.Text = "Tính tiền";
            bttnTinhTien.UseVisualStyleBackColor = false;
            bttnTinhTien.Click += bttnTinhTien_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblTongTien);
            panel1.Location = new Point(88, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(541, 553);
            panel1.TabIndex = 7;
            // 
            // AddIngredient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(717, 631);
            Controls.Add(bttnTinhTien);
            Controls.Add(btnLuu);
            Controls.Add(dgvChiTietNhap);
            Controls.Add(cboNhanVien);
            Controls.Add(dtpNgayNhap);
            Controls.Add(txtGhiChu);
            Controls.Add(panel1);
            Name = "AddIngredient";
            Text = "AddIngredient";
            Load += AddIngredient_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Button bttnTinhTien;
        private Panel panel1;
    }
}