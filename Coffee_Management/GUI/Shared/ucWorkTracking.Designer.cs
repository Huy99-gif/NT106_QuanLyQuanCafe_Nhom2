namespace GUI
{
    partial class ucWorkTracking
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblTotalShiftsValue = new System.Windows.Forms.Label();
            this.lblTotalShiftsTitle = new System.Windows.Forms.Label();
            this.lblTotalHoursValue = new System.Windows.Forms.Label();
            this.lblTotalHoursTitle = new System.Windows.Forms.Label();
            this.lblFilterTitle = new System.Windows.Forms.Label();
            this.dtpFilterMonth = new System.Windows.Forms.DateTimePicker();
            this.pnlCheckInOut = new System.Windows.Forms.Panel();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.lblCheckStatus = new System.Windows.Forms.Label();
            this.lblCheckTime = new System.Windows.Forms.Label();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.dgvWorkTracking = new System.Windows.Forms.DataGridView();
            this.lblLogTitle = new System.Windows.Forms.Label();
            this.pnlSummary.SuspendLayout();
            this.pnlCheckInOut.SuspendLayout();
            this.pnlLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkTracking)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlSummary.Controls.Add(this.lblTotalShiftsValue);
            this.pnlSummary.Controls.Add(this.lblTotalShiftsTitle);
            this.pnlSummary.Controls.Add(this.lblTotalHoursValue);
            this.pnlSummary.Controls.Add(this.lblTotalHoursTitle);
            this.pnlSummary.Controls.Add(this.lblFilterTitle);
            this.pnlSummary.Controls.Add(this.dtpFilterMonth);
            this.pnlSummary.Location = new System.Drawing.Point(20, 20);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(764, 80);
            this.pnlSummary.TabIndex = 0;
            // 
            // lblTotalShiftsValue
            // 
            this.lblTotalShiftsValue.AutoSize = true;
            this.lblTotalShiftsValue.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalShiftsValue.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblTotalShiftsValue.Location = new System.Drawing.Point(20, 35);
            this.lblTotalShiftsValue.Name = "lblTotalShiftsValue";
            this.lblTotalShiftsValue.Size = new System.Drawing.Size(61, 30);
            this.lblTotalShiftsValue.TabIndex = 0;
            this.lblTotalShiftsValue.Text = "24 Ca";
            // 
            // lblTotalShiftsTitle
            // 
            this.lblTotalShiftsTitle.AutoSize = true;
            this.lblTotalShiftsTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTotalShiftsTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalShiftsTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTotalShiftsTitle.Name = "lblTotalShiftsTitle";
            this.lblTotalShiftsTitle.Size = new System.Drawing.Size(126, 17);
            this.lblTotalShiftsTitle.TabIndex = 1;
            this.lblTotalShiftsTitle.Text = "Tổng ca trong tháng";
            // 
            // lblTotalHoursValue
            // 
            this.lblTotalHoursValue.AutoSize = true;
            this.lblTotalHoursValue.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalHoursValue.ForeColor = System.Drawing.Color.Orange;
            this.lblTotalHoursValue.Location = new System.Drawing.Point(220, 35);
            this.lblTotalHoursValue.Name = "lblTotalHoursValue";
            this.lblTotalHoursValue.Size = new System.Drawing.Size(109, 30);
            this.lblTotalHoursValue.TabIndex = 2;
            this.lblTotalHoursValue.Text = "156.5 Giờ";
            // 
            // lblTotalHoursTitle
            // 
            this.lblTotalHoursTitle.AutoSize = true;
            this.lblTotalHoursTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTotalHoursTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalHoursTitle.Location = new System.Drawing.Point(220, 15);
            this.lblTotalHoursTitle.Name = "lblTotalHoursTitle";
            this.lblTotalHoursTitle.Size = new System.Drawing.Size(107, 17);
            this.lblTotalHoursTitle.TabIndex = 3;
            this.lblTotalHoursTitle.Text = "Tổng số giờ làm";
            // 
            // lblFilterTitle
            // 
            this.lblFilterTitle.AutoSize = true;
            this.lblFilterTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblFilterTitle.ForeColor = System.Drawing.Color.White;
            this.lblFilterTitle.Location = new System.Drawing.Point(470, 30);
            this.lblFilterTitle.Name = "lblFilterTitle";
            this.lblFilterTitle.Size = new System.Drawing.Size(90, 20);
            this.lblFilterTitle.TabIndex = 4;
            this.lblFilterTitle.Text = "Chọn tháng:";
            // 
            // dtpFilterMonth
            // 
            this.dtpFilterMonth.CustomFormat = "MM/yyyy";
            this.dtpFilterMonth.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpFilterMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFilterMonth.Location = new System.Drawing.Point(570, 27);
            this.dtpFilterMonth.Name = "dtpFilterMonth";
            this.dtpFilterMonth.ShowUpDown = true;
            this.dtpFilterMonth.Size = new System.Drawing.Size(150, 27);
            this.dtpFilterMonth.TabIndex = 5;
            //
            // pnlCheckInOut
            //
            this.pnlCheckInOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlCheckInOut.Controls.Add(this.btnCheckIn);
            this.pnlCheckInOut.Controls.Add(this.btnCheckOut);
            this.pnlCheckInOut.Controls.Add(this.lblCheckStatus);
            this.pnlCheckInOut.Controls.Add(this.lblCheckTime);
            this.pnlCheckInOut.Location = new System.Drawing.Point(20, 120);
            this.pnlCheckInOut.Name = "pnlCheckInOut";
            this.pnlCheckInOut.Size = new System.Drawing.Size(764, 70);
            this.pnlCheckInOut.TabIndex = 3;
            //
            // btnCheckIn
            //
            this.btnCheckIn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCheckIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckIn.FlatAppearance.BorderSize = 0;
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnCheckIn.Location = new System.Drawing.Point(20, 15);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(150, 40);
            this.btnCheckIn.TabIndex = 0;
            this.btnCheckIn.Text = "CHECK-IN";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            //
            // btnCheckOut
            //
            this.btnCheckOut.BackColor = System.Drawing.Color.IndianRed;
            this.btnCheckOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckOut.FlatAppearance.BorderSize = 0;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Location = new System.Drawing.Point(190, 15);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(150, 40);
            this.btnCheckOut.TabIndex = 1;
            this.btnCheckOut.Text = "CHECK-OUT";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            //
            // lblCheckStatus
            //
            this.lblCheckStatus.AutoSize = true;
            this.lblCheckStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCheckStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblCheckStatus.Location = new System.Drawing.Point(380, 15);
            this.lblCheckStatus.Name = "lblCheckStatus";
            this.lblCheckStatus.Size = new System.Drawing.Size(176, 20);
            this.lblCheckStatus.TabIndex = 2;
            this.lblCheckStatus.Text = "Chưa check-in hôm nay";
            //
            // lblCheckTime
            //
            this.lblCheckTime.AutoSize = true;
            this.lblCheckTime.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblCheckTime.ForeColor = System.Drawing.Color.Orange;
            this.lblCheckTime.Location = new System.Drawing.Point(380, 40);
            this.lblCheckTime.Name = "lblCheckTime";
            this.lblCheckTime.Size = new System.Drawing.Size(42, 17);
            this.lblCheckTime.TabIndex = 3;
            this.lblCheckTime.Text = "--:--";
            //
            // pnlLog
            //
            this.pnlLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlLog.Controls.Add(this.dgvWorkTracking);
            this.pnlLog.Controls.Add(this.lblLogTitle);
            this.pnlLog.Location = new System.Drawing.Point(20, 210);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(764, 300);
            this.pnlLog.TabIndex = 2;
            // 
            // dgvWorkTracking
            // 
            this.dgvWorkTracking.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvWorkTracking.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWorkTracking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorkTracking.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWorkTracking.Location = new System.Drawing.Point(15, 50);
            this.dgvWorkTracking.Name = "dgvWorkTracking";
            this.dgvWorkTracking.Size = new System.Drawing.Size(734, 320);
            this.dgvWorkTracking.TabIndex = 1;
            // 
            // lblLogTitle
            // 
            this.lblLogTitle.AutoSize = true;
            this.lblLogTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogTitle.ForeColor = System.Drawing.Color.White;
            this.lblLogTitle.Location = new System.Drawing.Point(15, 15);
            this.lblLogTitle.Name = "lblLogTitle";
            this.lblLogTitle.Size = new System.Drawing.Size(201, 21);
            this.lblLogTitle.TabIndex = 0;
            this.lblLogTitle.Text = "Chi tiết lịch sử làm việc";
            // 
            // ucWorkTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.pnlLog);
            this.Controls.Add(this.pnlCheckInOut);
            this.Controls.Add(this.pnlSummary);
            this.Name = "ucWorkTracking";
            this.Size = new System.Drawing.Size(804, 530);
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.pnlCheckInOut.ResumeLayout(false);
            this.pnlCheckInOut.PerformLayout();
            this.pnlLog.ResumeLayout(false);
            this.pnlLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkTracking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblTotalShiftsTitle;
        private System.Windows.Forms.Label lblTotalShiftsValue;
        private System.Windows.Forms.Label lblTotalHoursTitle;
        private System.Windows.Forms.Label lblTotalHoursValue;
        private System.Windows.Forms.Label lblFilterTitle;
        private System.Windows.Forms.DateTimePicker dtpFilterMonth;
        private System.Windows.Forms.Panel pnlCheckInOut;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Label lblCheckStatus;
        private System.Windows.Forms.Label lblCheckTime;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.Label lblLogTitle;
        private System.Windows.Forms.DataGridView dgvWorkTracking;
    }
}
