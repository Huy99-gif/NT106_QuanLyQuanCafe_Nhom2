namespace GUI
{
    partial class ucProducts_Manager
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlSummary = new Panel();
            btnShowChart = new Button();
            lblExpenseValue = new Label();
            lblExpenseTitle = new Label();
            lblIncomeValue = new Label();
            lblIncomeTitle = new Label();
            pnlMenu = new Panel();
            btnDeleteMenu = new Button();
            btnAddMenu = new Button();
            dgvMenu = new DataGridView();
            lblMenuTitle = new Label();
            pnlInventory = new Panel();
            btnImportMaterial = new Button();
            dgvInventory = new DataGridView();
            lblInventoryTitle = new Label();
            pnlSummary.SuspendLayout();
            pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit();
            pnlInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            SuspendLayout();
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = Color.FromArgb(30, 30, 30);
            pnlSummary.Controls.Add(btnShowChart);
            pnlSummary.Controls.Add(lblExpenseValue);
            pnlSummary.Controls.Add(lblExpenseTitle);
            pnlSummary.Controls.Add(lblIncomeValue);
            pnlSummary.Controls.Add(lblIncomeTitle);
            pnlSummary.Location = new Point(23, 27);
            pnlSummary.Margin = new Padding(3, 4, 3, 4);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(873, 107);
            pnlSummary.TabIndex = 0;
            // 
            // btnShowChart
            // 
            btnShowChart.BackColor = Color.White;
            btnShowChart.Cursor = Cursors.Hand;
            btnShowChart.FlatAppearance.BorderSize = 0;
            btnShowChart.FlatStyle = FlatStyle.Flat;
            btnShowChart.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnShowChart.ForeColor = Color.Black;
            btnShowChart.Location = new Point(686, 29);
            btnShowChart.Margin = new Padding(3, 4, 3, 4);
            btnShowChart.Name = "btnShowChart";
            btnShowChart.Size = new Size(160, 47);
            btnShowChart.TabIndex = 4;
            btnShowChart.Text = "Xem Biểu Đồ 📊";
            btnShowChart.UseVisualStyleBackColor = false;
            // 
            // lblExpenseValue
            // 
            lblExpenseValue.AutoSize = true;
            lblExpenseValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblExpenseValue.ForeColor = Color.IndianRed;
            lblExpenseValue.Location = new Point(251, 47);
            lblExpenseValue.Name = "lblExpenseValue";
            lblExpenseValue.Size = new Size(162, 37);
            lblExpenseValue.TabIndex = 3;
            lblExpenseValue.Text = "- 850,000 đ";
            // 
            // lblExpenseTitle
            // 
            lblExpenseTitle.AutoSize = true;
            lblExpenseTitle.Font = new Font("Segoe UI", 9.75F);
            lblExpenseTitle.ForeColor = Color.Gray;
            lblExpenseTitle.Location = new Point(251, 20);
            lblExpenseTitle.Name = "lblExpenseTitle";
            lblExpenseTitle.Size = new Size(206, 23);
            lblExpenseTitle.TabIndex = 2;
            lblExpenseTitle.Text = "Tiền nhập NL (Đầu ra) 🔻";
            // 
            // lblIncomeValue
            // 
            lblIncomeValue.AutoSize = true;
            lblIncomeValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblIncomeValue.ForeColor = Color.MediumSeaGreen;
            lblIncomeValue.Location = new Point(23, 47);
            lblIncomeValue.Name = "lblIncomeValue";
            lblIncomeValue.Size = new Size(193, 37);
            lblIncomeValue.TabIndex = 1;
            lblIncomeValue.Text = "+ 5,200,000 đ";
            // 
            // lblIncomeTitle
            // 
            lblIncomeTitle.AutoSize = true;
            lblIncomeTitle.Font = new Font("Segoe UI", 9.75F);
            lblIncomeTitle.ForeColor = Color.Gray;
            lblIncomeTitle.Location = new Point(23, 20);
            lblIncomeTitle.Name = "lblIncomeTitle";
            lblIncomeTitle.Size = new Size(226, 23);
            lblIncomeTitle.TabIndex = 0;
            lblIncomeTitle.Text = "Tiền bán hàng (Đầu vào) 🔺";
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(30, 30, 30);
            pnlMenu.Controls.Add(btnDeleteMenu);
            pnlMenu.Controls.Add(btnAddMenu);
            pnlMenu.Controls.Add(dgvMenu);
            pnlMenu.Controls.Add(lblMenuTitle);
            pnlMenu.Location = new Point(23, 160);
            pnlMenu.Margin = new Padding(3, 4, 3, 4);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(423, 520);
            pnlMenu.TabIndex = 1;
            // 
            // btnDeleteMenu
            // 
            btnDeleteMenu.BackColor = Color.FromArgb(45, 45, 48);
            btnDeleteMenu.FlatAppearance.BorderSize = 0;
            btnDeleteMenu.FlatStyle = FlatStyle.Flat;
            btnDeleteMenu.ForeColor = Color.IndianRed;
            btnDeleteMenu.Location = new Point(320, 20);
            btnDeleteMenu.Margin = new Padding(3, 4, 3, 4);
            btnDeleteMenu.Name = "btnDeleteMenu";
            btnDeleteMenu.Size = new Size(80, 33);
            btnDeleteMenu.TabIndex = 3;
            btnDeleteMenu.Text = "Xóa món";
            btnDeleteMenu.UseVisualStyleBackColor = false;
            // 
            // btnAddMenu
            // 
            btnAddMenu.BackColor = Color.FromArgb(45, 45, 48);
            btnAddMenu.FlatAppearance.BorderSize = 0;
            btnAddMenu.FlatStyle = FlatStyle.Flat;
            btnAddMenu.ForeColor = Color.MediumSeaGreen;
            btnAddMenu.Location = new Point(229, 20);
            btnAddMenu.Margin = new Padding(3, 4, 3, 4);
            btnAddMenu.Name = "btnAddMenu";
            btnAddMenu.Size = new Size(80, 33);
            btnAddMenu.TabIndex = 2;
            btnAddMenu.Text = "+ Thêm";
            btnAddMenu.UseVisualStyleBackColor = false;
            btnAddMenu.Click += btnAddMenu_Click;
            // 
            // dgvMenu
            // 
            dgvMenu.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvMenu.BorderStyle = BorderStyle.None;
            dgvMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvMenu.DefaultCellStyle = dataGridViewCellStyle1;
            dgvMenu.Location = new Point(23, 67);
            dgvMenu.Margin = new Padding(3, 4, 3, 4);
            dgvMenu.Name = "dgvMenu";
            dgvMenu.RowHeadersWidth = 51;
            dgvMenu.Size = new Size(377, 427);
            dgvMenu.TabIndex = 1;
            // 
            // lblMenuTitle
            // 
            lblMenuTitle.AutoSize = true;
            lblMenuTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMenuTitle.ForeColor = Color.White;
            lblMenuTitle.Location = new Point(17, 20);
            lblMenuTitle.Name = "lblMenuTitle";
            lblMenuTitle.Size = new Size(145, 28);
            lblMenuTitle.TabIndex = 0;
            lblMenuTitle.Text = "Quản lý Menu";
            // 
            // pnlInventory
            // 
            pnlInventory.BackColor = Color.FromArgb(30, 30, 30);
            pnlInventory.Controls.Add(btnImportMaterial);
            pnlInventory.Controls.Add(dgvInventory);
            pnlInventory.Controls.Add(lblInventoryTitle);
            pnlInventory.Location = new Point(473, 160);
            pnlInventory.Margin = new Padding(3, 4, 3, 4);
            pnlInventory.Name = "pnlInventory";
            pnlInventory.Size = new Size(423, 520);
            pnlInventory.TabIndex = 2;
            // 
            // btnImportMaterial
            // 
            btnImportMaterial.BackColor = Color.MediumSeaGreen;
            btnImportMaterial.FlatAppearance.BorderSize = 0;
            btnImportMaterial.FlatStyle = FlatStyle.Flat;
            btnImportMaterial.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnImportMaterial.ForeColor = Color.White;
            btnImportMaterial.Location = new Point(269, 20);
            btnImportMaterial.Margin = new Padding(3, 4, 3, 4);
            btnImportMaterial.Name = "btnImportMaterial";
            btnImportMaterial.Size = new Size(131, 33);
            btnImportMaterial.TabIndex = 4;
            btnImportMaterial.Text = "+ Nhập Hàng";
            btnImportMaterial.UseVisualStyleBackColor = false;
            // 
            // dgvInventory
            // 
            dgvInventory.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvInventory.BorderStyle = BorderStyle.None;
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvInventory.DefaultCellStyle = dataGridViewCellStyle2;
            dgvInventory.Location = new Point(23, 67);
            dgvInventory.Margin = new Padding(3, 4, 3, 4);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.RowHeadersWidth = 51;
            dgvInventory.Size = new Size(377, 427);
            dgvInventory.TabIndex = 2;
            // 
            // lblInventoryTitle
            // 
            lblInventoryTitle.AutoSize = true;
            lblInventoryTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblInventoryTitle.ForeColor = Color.White;
            lblInventoryTitle.Location = new Point(17, 20);
            lblInventoryTitle.Name = "lblInventoryTitle";
            lblInventoryTitle.Size = new Size(189, 28);
            lblInventoryTitle.TabIndex = 1;
            lblInventoryTitle.Text = "Nguyên Liệu / Kho";
            // 
            // ucProducts_Manager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlInventory);
            Controls.Add(pnlMenu);
            Controls.Add(pnlSummary);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucProducts_Manager";
            Size = new Size(919, 707);
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).EndInit();
            pnlInventory.ResumeLayout(false);
            pnlInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblIncomeTitle;
        private System.Windows.Forms.Label lblIncomeValue;
        private System.Windows.Forms.Label lblExpenseTitle;
        private System.Windows.Forms.Label lblExpenseValue;
        private System.Windows.Forms.Button btnShowChart;

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblMenuTitle;
        private System.Windows.Forms.DataGridView dgvMenu;
        private System.Windows.Forms.Button btnAddMenu;
        private System.Windows.Forms.Button btnDeleteMenu;

        private System.Windows.Forms.Panel pnlInventory;
        private System.Windows.Forms.Label lblInventoryTitle;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Button btnImportMaterial;
    }
}
