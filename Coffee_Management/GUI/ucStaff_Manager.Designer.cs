namespace GUI
{
    partial class ucStaff_Manager
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlSummary = new Panel();
            lblPayrollValue = new Label();
            lblPayrollTitle = new Label();
            lblLeaveValue = new Label();
            lblLeaveTitle = new Label();
            lblPresentValue = new Label();
            lblPresentTitle = new Label();
            lblTotalStaffValue = new Label();
            lblTotalStaffTitle = new Label();
            pnlStaffList = new Panel();
            btnEditStaff = new Button();
            btnAddStaff = new Button();
            dgvStaff = new DataGridView();
            lblStaffTitle = new Label();
            pnlTimekeeping = new Panel();
            btnCheckIn = new Button();
            lstAttendance = new ListBox();
            lblTimekeepingTitle = new Label();
            pnlLeaveRequests = new Panel();
            btnApproveLeave = new Button();
            lstLeaveq = new ListBox();
            lblLeaveReqTitle = new Label();
            pnlSummary.SuspendLayout();
            pnlStaffList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStaff).BeginInit();
            pnlTimekeeping.SuspendLayout();
            pnlLeaveRequests.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = Color.FromArgb(30, 30, 30);
            pnlSummary.Controls.Add(lblPayrollValue);
            pnlSummary.Controls.Add(lblPayrollTitle);
            pnlSummary.Controls.Add(lblLeaveValue);
            pnlSummary.Controls.Add(lblLeaveTitle);
            pnlSummary.Controls.Add(lblPresentValue);
            pnlSummary.Controls.Add(lblPresentTitle);
            pnlSummary.Controls.Add(lblTotalStaffValue);
            pnlSummary.Controls.Add(lblTotalStaffTitle);
            pnlSummary.Location = new Point(20, 20);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(764, 80);
            pnlSummary.TabIndex = 0;
            // 
            // lblPayrollValue
            // 
            lblPayrollValue.AutoSize = true;
            lblPayrollValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblPayrollValue.ForeColor = Color.IndianRed;
            lblPayrollValue.Location = new Point(520, 35);
            lblPayrollValue.Name = "lblPayrollValue";
            lblPayrollValue.Size = new Size(140, 30);
            lblPayrollValue.TabIndex = 0;
            lblPayrollValue.Text = "42,500,000 đ";
            // 
            // lblPayrollTitle
            // 
            lblPayrollTitle.AutoSize = true;
            lblPayrollTitle.Font = new Font("Segoe UI", 9.75F);
            lblPayrollTitle.ForeColor = Color.Gray;
            lblPayrollTitle.Location = new Point(520, 15);
            lblPayrollTitle.Name = "lblPayrollTitle";
            lblPayrollTitle.Size = new Size(131, 17);
            lblPayrollTitle.TabIndex = 1;
            lblPayrollTitle.Text = "Quỹ lương (Tạm tính)";
            // 
            // lblLeaveValue
            // 
            lblLeaveValue.AutoSize = true;
            lblLeaveValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblLeaveValue.ForeColor = Color.Orange;
            lblLeaveValue.Location = new Point(350, 35);
            lblLeaveValue.Name = "lblLeaveValue";
            lblLeaveValue.Size = new Size(90, 30);
            lblLeaveValue.TabIndex = 2;
            lblLeaveValue.Text = "1 người";
            // 
            // lblLeaveTitle
            // 
            lblLeaveTitle.AutoSize = true;
            lblLeaveTitle.Font = new Font("Segoe UI", 9.75F);
            lblLeaveTitle.ForeColor = Color.Gray;
            lblLeaveTitle.Location = new Point(350, 15);
            lblLeaveTitle.Name = "lblLeaveTitle";
            lblLeaveTitle.Size = new Size(117, 17);
            lblLeaveTitle.TabIndex = 3;
            lblLeaveTitle.Text = "Nghỉ phép (H.Nay)";
            // 
            // lblPresentValue
            // 
            lblPresentValue.AutoSize = true;
            lblPresentValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblPresentValue.ForeColor = Color.MediumSeaGreen;
            lblPresentValue.Location = new Point(180, 35);
            lblPresentValue.Name = "lblPresentValue";
            lblPresentValue.Size = new Size(90, 30);
            lblPresentValue.TabIndex = 4;
            lblPresentValue.Text = "5 người";
            lblPresentValue.Click += lblPresentValue_Click;
            // 
            // lblPresentTitle
            // 
            lblPresentTitle.AutoSize = true;
            lblPresentTitle.Font = new Font("Segoe UI", 9.75F);
            lblPresentTitle.ForeColor = Color.Gray;
            lblPresentTitle.Location = new Point(180, 15);
            lblPresentTitle.Name = "lblPresentTitle";
            lblPresentTitle.Size = new Size(132, 17);
            lblPresentTitle.TabIndex = 5;
            lblPresentTitle.Text = "Đi làm ca Hiện tại \U0001f7e2";
            // 
            // lblTotalStaffValue
            // 
            lblTotalStaffValue.AutoSize = true;
            lblTotalStaffValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            lblTotalStaffValue.ForeColor = Color.White;
            lblTotalStaffValue.Location = new Point(20, 35);
            lblTotalStaffValue.Name = "lblTotalStaffValue";
            lblTotalStaffValue.Size = new Size(102, 30);
            lblTotalStaffValue.TabIndex = 6;
            lblTotalStaffValue.Text = "15 người";
            // 
            // lblTotalStaffTitle
            // 
            lblTotalStaffTitle.AutoSize = true;
            lblTotalStaffTitle.Font = new Font("Segoe UI", 9.75F);
            lblTotalStaffTitle.ForeColor = Color.Gray;
            lblTotalStaffTitle.Location = new Point(20, 15);
            lblTotalStaffTitle.Name = "lblTotalStaffTitle";
            lblTotalStaffTitle.Size = new Size(121, 17);
            lblTotalStaffTitle.TabIndex = 7;
            lblTotalStaffTitle.Text = "Tổng Số Nhân Viên";
            // 
            // pnlStaffList
            // 
            pnlStaffList.BackColor = Color.FromArgb(30, 30, 30);
            pnlStaffList.Controls.Add(btnEditStaff);
            pnlStaffList.Controls.Add(btnAddStaff);
            pnlStaffList.Controls.Add(dgvStaff);
            pnlStaffList.Controls.Add(lblStaffTitle);
            pnlStaffList.Location = new Point(20, 120);
            pnlStaffList.Name = "pnlStaffList";
            pnlStaffList.Size = new Size(450, 390);
            pnlStaffList.TabIndex = 1;
            // 
            // btnEditStaff
            // 
            btnEditStaff.BackColor = Color.FromArgb(45, 45, 48);
            btnEditStaff.FlatAppearance.BorderSize = 0;
            btnEditStaff.FlatStyle = FlatStyle.Flat;
            btnEditStaff.ForeColor = Color.IndianRed;
            btnEditStaff.Location = new Point(360, 15);
            btnEditStaff.Name = "btnEditStaff";
            btnEditStaff.Size = new Size(70, 25);
            btnEditStaff.TabIndex = 0;
            btnEditStaff.Text = "Sửa";
            btnEditStaff.UseVisualStyleBackColor = false;
            btnEditStaff.Click += btnEditStaff_Click;
            // 
            // btnAddStaff
            // 
            btnAddStaff.BackColor = Color.MediumSeaGreen;
            btnAddStaff.FlatAppearance.BorderSize = 0;
            btnAddStaff.FlatStyle = FlatStyle.Flat;
            btnAddStaff.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddStaff.ForeColor = Color.White;
            btnAddStaff.Location = new Point(235, 15);
            btnAddStaff.Name = "btnAddStaff";
            btnAddStaff.Size = new Size(115, 25);
            btnAddStaff.TabIndex = 1;
            btnAddStaff.Text = "+ Thêm NV Mới";
            btnAddStaff.UseVisualStyleBackColor = false;
            btnAddStaff.Click += btnAddStaff_Click;
            // 
            // dgvStaff
            // 
            dgvStaff.BackgroundColor = Color.FromArgb(45, 45, 48);
            dgvStaff.BorderStyle = BorderStyle.None;
            dgvStaff.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(45, 45, 48);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvStaff.DefaultCellStyle = dataGridViewCellStyle1;
            dgvStaff.Location = new Point(20, 50);
            dgvStaff.Name = "dgvStaff";
            dgvStaff.RowHeadersWidth = 51;
            dgvStaff.Size = new Size(410, 320);
            dgvStaff.TabIndex = 1;
            dgvStaff.CellContentDoubleClick += dgvStaff_CellContentDoubleClick;
            // 
            // lblStaffTitle
            // 
            lblStaffTitle.AutoSize = true;
            lblStaffTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStaffTitle.ForeColor = Color.White;
            lblStaffTitle.Location = new Point(15, 15);
            lblStaffTitle.Name = "lblStaffTitle";
            lblStaffTitle.Size = new Size(163, 21);
            lblStaffTitle.TabIndex = 2;
            lblStaffTitle.Text = "Hồ sơ Nhân viên 📇";
            // 
            // pnlTimekeeping
            // 
            pnlTimekeeping.BackColor = Color.FromArgb(30, 30, 30);
            pnlTimekeeping.Controls.Add(btnCheckIn);
            pnlTimekeeping.Controls.Add(lstAttendance);
            pnlTimekeeping.Controls.Add(lblTimekeepingTitle);
            pnlTimekeeping.Location = new Point(490, 120);
            pnlTimekeeping.Name = "pnlTimekeeping";
            pnlTimekeeping.Size = new Size(294, 180);
            pnlTimekeeping.TabIndex = 2;
            // 
            // btnCheckIn
            // 
            btnCheckIn.BackColor = Color.FromArgb(45, 45, 48);
            btnCheckIn.FlatAppearance.BorderSize = 0;
            btnCheckIn.FlatStyle = FlatStyle.Flat;
            btnCheckIn.ForeColor = Color.White;
            btnCheckIn.Location = new Point(194, 12);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(85, 25);
            btnCheckIn.TabIndex = 0;
            btnCheckIn.Text = "Quét RFID";
            btnCheckIn.UseVisualStyleBackColor = false;
            // 
            // lstAttendance
            // 
            lstAttendance.BackColor = Color.FromArgb(45, 45, 48);
            lstAttendance.BorderStyle = BorderStyle.None;
            lstAttendance.Font = new Font("Segoe UI", 9.75F);
            lstAttendance.ForeColor = Color.White;
            lstAttendance.FormattingEnabled = true;
            lstAttendance.ItemHeight = 17;
            lstAttendance.Location = new Point(20, 50);
            lstAttendance.Name = "lstAttendance";
            lstAttendance.Size = new Size(254, 85);
            lstAttendance.TabIndex = 1;
            // 
            // lblTimekeepingTitle
            // 
            lblTimekeepingTitle.AutoSize = true;
            lblTimekeepingTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTimekeepingTitle.ForeColor = Color.White;
            lblTimekeepingTitle.Location = new Point(15, 15);
            lblTimekeepingTitle.Name = "lblTimekeepingTitle";
            lblTimekeepingTitle.Size = new Size(154, 20);
            lblTimekeepingTitle.TabIndex = 2;
            lblTimekeepingTitle.Text = "Chấm công Hôm nay";
            // 
            // pnlLeaveRequests
            // 
            pnlLeaveRequests.BackColor = Color.FromArgb(30, 30, 30);
            pnlLeaveRequests.Controls.Add(btnApproveLeave);
            pnlLeaveRequests.Controls.Add(lstLeaveq);
            pnlLeaveRequests.Controls.Add(lblLeaveReqTitle);
            pnlLeaveRequests.Location = new Point(490, 320);
            pnlLeaveRequests.Name = "pnlLeaveRequests";
            pnlLeaveRequests.Size = new Size(294, 190);
            pnlLeaveRequests.TabIndex = 3;
            // 
            // btnApproveLeave
            // 
            btnApproveLeave.BackColor = Color.MediumSeaGreen;
            btnApproveLeave.FlatAppearance.BorderSize = 0;
            btnApproveLeave.FlatStyle = FlatStyle.Flat;
            btnApproveLeave.ForeColor = Color.White;
            btnApproveLeave.Location = new Point(194, 12);
            btnApproveLeave.Name = "btnApproveLeave";
            btnApproveLeave.Size = new Size(85, 25);
            btnApproveLeave.TabIndex = 0;
            btnApproveLeave.Text = "Duyệt (1)";
            btnApproveLeave.UseVisualStyleBackColor = false;
            // 
            // lstLeaveq
            // 
            lstLeaveq.BackColor = Color.FromArgb(45, 45, 48);
            lstLeaveq.BorderStyle = BorderStyle.None;
            lstLeaveq.Font = new Font("Segoe UI", 9.75F);
            lstLeaveq.ForeColor = Color.White;
            lstLeaveq.FormattingEnabled = true;
            lstLeaveq.ItemHeight = 17;
            lstLeaveq.Location = new Point(20, 50);
            lstLeaveq.Name = "lstLeaveq";
            lstLeaveq.Size = new Size(254, 102);
            lstLeaveq.TabIndex = 1;
            // 
            // lblLeaveReqTitle
            // 
            lblLeaveReqTitle.AutoSize = true;
            lblLeaveReqTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLeaveReqTitle.ForeColor = Color.Orange;
            lblLeaveReqTitle.Location = new Point(15, 15);
            lblLeaveReqTitle.Name = "lblLeaveReqTitle";
            lblLeaveReqTitle.Size = new Size(156, 20);
            lblLeaveReqTitle.TabIndex = 2;
            lblLeaveReqTitle.Text = "Duyệt đơn nghỉ phép";
            // 
            // ucStaff_Manager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            Controls.Add(pnlLeaveRequests);
            Controls.Add(pnlTimekeeping);
            Controls.Add(pnlStaffList);
            Controls.Add(pnlSummary);
            Name = "ucStaff_Manager";
            Size = new Size(804, 530);
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlStaffList.ResumeLayout(false);
            pnlStaffList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStaff).EndInit();
            pnlTimekeeping.ResumeLayout(false);
            pnlTimekeeping.PerformLayout();
            pnlLeaveRequests.ResumeLayout(false);
            pnlLeaveRequests.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblTotalStaffTitle;
        private System.Windows.Forms.Label lblTotalStaffValue;
        private System.Windows.Forms.Label lblPresentTitle;
        private System.Windows.Forms.Label lblPresentValue;
        private System.Windows.Forms.Label lblLeaveTitle;
        private System.Windows.Forms.Label lblLeaveValue;
        private System.Windows.Forms.Label lblPayrollTitle;
        private System.Windows.Forms.Label lblPayrollValue;

        private System.Windows.Forms.Panel pnlStaffList;
        private System.Windows.Forms.Label lblStaffTitle;
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.Button btnAddStaff;
        private System.Windows.Forms.Button btnEditStaff;

        private System.Windows.Forms.Panel pnlTimekeeping;
        private System.Windows.Forms.Label lblTimekeepingTitle;
        private System.Windows.Forms.ListBox lstAttendance;
        private System.Windows.Forms.Button btnCheckIn;

        private System.Windows.Forms.Panel pnlLeaveRequests;
        private System.Windows.Forms.Label lblLeaveReqTitle;
        private System.Windows.Forms.ListBox lstLeaveq;
        private System.Windows.Forms.Button btnApproveLeave;
    }
}