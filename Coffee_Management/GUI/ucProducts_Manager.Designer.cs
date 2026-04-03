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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.btnShowChart = new System.Windows.Forms.Button();
            this.lblExpenseValue = new System.Windows.Forms.Label();
            this.lblExpenseTitle = new System.Windows.Forms.Label();
            this.lblIncomeValue = new System.Windows.Forms.Label();
            this.lblIncomeTitle = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnDeleteMenu = new System.Windows.Forms.Button();
            this.btnAddMenu = new System.Windows.Forms.Button();
            this.dgvMenu = new System.Windows.Forms.DataGridView();
            this.lblMenuTitle = new System.Windows.Forms.Label();
            this.pnlInventory = new System.Windows.Forms.Panel();
            this.btnImportMaterial = new System.Windows.Forms.Button();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.lblInventoryTitle = new System.Windows.Forms.Label();
            this.pnlSummary.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            this.pnlInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSummary (Khu vực thống kê tiền)
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlSummary.Controls.Add(this.btnShowChart);
            this.pnlSummary.Controls.Add(this.lblExpenseValue);
            this.pnlSummary.Controls.Add(this.lblExpenseTitle);
            this.pnlSummary.Controls.Add(this.lblIncomeValue);
            this.pnlSummary.Controls.Add(this.lblIncomeTitle);
            this.pnlSummary.Location = new System.Drawing.Point(20, 20);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(764, 80);
            this.pnlSummary.TabIndex = 0;
            // 
            // btnShowChart (Nút xem biểu đồ)
            // 
            this.btnShowChart.BackColor = System.Drawing.Color.White;
            this.btnShowChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowChart.FlatAppearance.BorderSize = 0;
            this.btnShowChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowChart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnShowChart.ForeColor = System.Drawing.Color.Black;
            this.btnShowChart.Location = new System.Drawing.Point(600, 22);
            this.btnShowChart.Name = "btnShowChart";
            this.btnShowChart.Size = new System.Drawing.Size(140, 35);
            this.btnShowChart.TabIndex = 4;
            this.btnShowChart.Text = "Xem Biểu Đồ 📊";
            this.btnShowChart.UseVisualStyleBackColor = false;
            // 
            // lblExpenseValue
            // 
            this.lblExpenseValue.AutoSize = true;
            this.lblExpenseValue.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblExpenseValue.ForeColor = System.Drawing.Color.IndianRed;
            this.lblExpenseValue.Location = new System.Drawing.Point(220, 35);
            this.lblExpenseValue.Name = "lblExpenseValue";
            this.lblExpenseValue.Size = new System.Drawing.Size(132, 30);
            this.lblExpenseValue.TabIndex = 3;
            this.lblExpenseValue.Text = "- 850,000 đ";
            // 
            // lblExpenseTitle
            // 
            this.lblExpenseTitle.AutoSize = true;
            this.lblExpenseTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblExpenseTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblExpenseTitle.Location = new System.Drawing.Point(220, 15);
            this.lblExpenseTitle.Name = "lblExpenseTitle";
            this.lblExpenseTitle.Size = new System.Drawing.Size(155, 17);
            this.lblExpenseTitle.TabIndex = 2;
            this.lblExpenseTitle.Text = "Tiền nhập NL (Đầu ra) 🔻";
            // 
            // lblIncomeValue
            // 
            this.lblIncomeValue.AutoSize = true;
            this.lblIncomeValue.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIncomeValue.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblIncomeValue.Location = new System.Drawing.Point(20, 35);
            this.lblIncomeValue.Name = "lblIncomeValue";
            this.lblIncomeValue.Size = new System.Drawing.Size(144, 30);
            this.lblIncomeValue.TabIndex = 1;
            this.lblIncomeValue.Text = "+ 5,200,000 đ";
            // 
            // lblIncomeTitle
            // 
            this.lblIncomeTitle.AutoSize = true;
            this.lblIncomeTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIncomeTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblIncomeTitle.Location = new System.Drawing.Point(20, 15);
            this.lblIncomeTitle.Name = "lblIncomeTitle";
            this.lblIncomeTitle.Size = new System.Drawing.Size(152, 17);
            this.lblIncomeTitle.TabIndex = 0;
            this.lblIncomeTitle.Text = "Tiền bán hàng (Đầu vào) 🔺";
            // 
            // pnlMenu (Khu vực Quản lý Menu)
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlMenu.Controls.Add(this.btnDeleteMenu);
            this.pnlMenu.Controls.Add(this.btnAddMenu);
            this.pnlMenu.Controls.Add(this.dgvMenu);
            this.pnlMenu.Controls.Add(this.lblMenuTitle);
            this.pnlMenu.Location = new System.Drawing.Point(20, 120);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(370, 390);
            this.pnlMenu.TabIndex = 1;
            // 
            // btnDeleteMenu
            // 
            this.btnDeleteMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnDeleteMenu.FlatAppearance.BorderSize = 0;
            this.btnDeleteMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteMenu.ForeColor = System.Drawing.Color.IndianRed;
            this.btnDeleteMenu.Location = new System.Drawing.Point(280, 15);
            this.btnDeleteMenu.Name = "btnDeleteMenu";
            this.btnDeleteMenu.Size = new System.Drawing.Size(70, 25);
            this.btnDeleteMenu.TabIndex = 3;
            this.btnDeleteMenu.Text = "Xóa món";
            this.btnDeleteMenu.UseVisualStyleBackColor = false;
            // 
            // btnAddMenu
            // 
            this.btnAddMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnAddMenu.FlatAppearance.BorderSize = 0;
            this.btnAddMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMenu.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAddMenu.Location = new System.Drawing.Point(200, 15);
            this.btnAddMenu.Name = "btnAddMenu";
            this.btnAddMenu.Size = new System.Drawing.Size(70, 25);
            this.btnAddMenu.TabIndex = 2;
            this.btnAddMenu.Text = "+ Thêm";
            this.btnAddMenu.UseVisualStyleBackColor = false;
            // 
            // dgvMenu
            // 
            this.dgvMenu.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMenu.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMenu.Location = new System.Drawing.Point(20, 50);
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.Size = new System.Drawing.Size(330, 320);
            this.dgvMenu.TabIndex = 1;
            // 
            // lblMenuTitle
            // 
            this.lblMenuTitle.AutoSize = true;
            this.lblMenuTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMenuTitle.ForeColor = System.Drawing.Color.White;
            this.lblMenuTitle.Location = new System.Drawing.Point(15, 15);
            this.lblMenuTitle.Name = "lblMenuTitle";
            this.lblMenuTitle.Size = new System.Drawing.Size(123, 21);
            this.lblMenuTitle.TabIndex = 0;
            this.lblMenuTitle.Text = "Quản lý Menu";
            // 
            // pnlInventory (Khu vực quản lý Nguyên Liệu)
            // 
            this.pnlInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlInventory.Controls.Add(this.btnImportMaterial);
            this.pnlInventory.Controls.Add(this.dgvInventory);
            this.pnlInventory.Controls.Add(this.lblInventoryTitle);
            this.pnlInventory.Location = new System.Drawing.Point(414, 120);
            this.pnlInventory.Name = "pnlInventory";
            this.pnlInventory.Size = new System.Drawing.Size(370, 390);
            this.pnlInventory.TabIndex = 2;
            // 
            // btnImportMaterial
            // 
            this.btnImportMaterial.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnImportMaterial.FlatAppearance.BorderSize = 0;
            this.btnImportMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportMaterial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnImportMaterial.ForeColor = System.Drawing.Color.White;
            this.btnImportMaterial.Location = new System.Drawing.Point(235, 15);
            this.btnImportMaterial.Name = "btnImportMaterial";
            this.btnImportMaterial.Size = new System.Drawing.Size(115, 25);
            this.btnImportMaterial.TabIndex = 4;
            this.btnImportMaterial.Text = "+ Nhập Hàng";
            this.btnImportMaterial.UseVisualStyleBackColor = false;
            // 
            // dgvInventory
            // 
            this.dgvInventory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInventory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInventory.Location = new System.Drawing.Point(20, 50);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.Size = new System.Drawing.Size(330, 320);
            this.dgvInventory.TabIndex = 2;
            // 
            // lblInventoryTitle
            // 
            this.lblInventoryTitle.AutoSize = true;
            this.lblInventoryTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblInventoryTitle.ForeColor = System.Drawing.Color.White;
            this.lblInventoryTitle.Location = new System.Drawing.Point(15, 15);
            this.lblInventoryTitle.Name = "lblInventoryTitle";
            this.lblInventoryTitle.Size = new System.Drawing.Size(161, 21);
            this.lblInventoryTitle.TabIndex = 1;
            this.lblInventoryTitle.Text = "Nguyên Liệu / Kho";
            // 
            // ucProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.pnlInventory);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlSummary);
            this.Name = "ucProducts_Manager";
            this.Size = new System.Drawing.Size(804, 530);
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            this.pnlInventory.ResumeLayout(false);
            this.pnlInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);

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
