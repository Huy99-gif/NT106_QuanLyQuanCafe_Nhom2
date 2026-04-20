namespace GUI
{
    partial class AddMonUong
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
            btnAdd = new Button();
            txtMoTa = new TextBox();
            txtTenMon = new TextBox();
            txtGia = new TextBox();
            bttnClear = new Button();
            cmLoai = new ComboBox();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(200, 376);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 32);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(288, 280);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.PlaceholderText = "Mô tả món ăn";
            txtMoTa.Size = new Size(168, 27);
            txtMoTa.TabIndex = 2;
            // 
            // txtTenMon
            // 
            txtTenMon.Location = new Point(288, 144);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.PlaceholderText = "Tên món";
            txtTenMon.Size = new Size(168, 27);
            txtTenMon.TabIndex = 4;
            // 
            // txtGia
            // 
            txtGia.Location = new Point(288, 184);
            txtGia.Name = "txtGia";
            txtGia.PlaceholderText = "Giá";
            txtGia.Size = new Size(168, 27);
            txtGia.TabIndex = 5;
            txtGia.TextChanged += txtGia_TextChanged;
            // 
            // bttnClear
            // 
            bttnClear.Location = new Point(432, 376);
            bttnClear.Name = "bttnClear";
            bttnClear.Size = new Size(120, 32);
            bttnClear.TabIndex = 6;
            bttnClear.Text = "Xóa";
            bttnClear.UseVisualStyleBackColor = true;
            bttnClear.Click += bttnClear_Click;
            // 
            // cmLoai
            // 
            cmLoai.FormattingEnabled = true;
            cmLoai.Items.AddRange(new object[] { "Đồ uống", "Đồ ăn" });
            cmLoai.Location = new Point(288, 232);
            cmLoai.Name = "cmLoai";
            cmLoai.Size = new Size(151, 28);
            cmLoai.TabIndex = 7;
            // 
            // AddMonUong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 605);
            Controls.Add(cmLoai);
            Controls.Add(bttnClear);
            Controls.Add(txtGia);
            Controls.Add(txtTenMon);
            Controls.Add(txtMoTa);
            Controls.Add(btnAdd);
            Name = "AddMonUong";
            Text = "AddMonUong";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private TextBox txtMoTa;
        private TextBox txtTenMon;
        private TextBox txtGia;
        private Button bttnClear;
        private ComboBox cmLoai;
    }
}