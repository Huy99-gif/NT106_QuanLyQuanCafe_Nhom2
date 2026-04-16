namespace GUI
{
    partial class ucAttendance
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

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.lblTotalHoursValue = new System.Windows.Forms.Label();
            this.lblTotalHoursTitle = new System.Windows.Forms.Label();
            this.pnlClock = new System.Windows.Forms.Panel();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblClockTitle = new System.Windows.Forms.Label();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.dgvAttendanceLog = new System.Windows.Forms.DataGridView();
            this.lblLogTitle = new System.Windows.Forms.Label();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.pnlSummary.SuspendLayout();
            this.pnlClock.SuspendLayout();
            this.pnlLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceLog)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlSummary.Controls.Add(this.lblStatusValue);
            this.pnlSummary.Controls.Add(this.lblStatusTitle);
            this.pnlSummary.Controls.Add(this.lblTotalHoursValue);
            this.pnlSummary.Controls.Add(this.lblTotalHoursTitle);
            this.pnlSummary.Location = new System.Drawing.Point(20, 20);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(764, 80);
            this.pnlSummary.TabIndex = 0;
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblStatusValue.ForeColor = System.Drawing.Color.Orange;
            this.lblStatusValue.Location = new System.Drawing.Point(20, 35);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(155, 30);
            this.lblStatusValue.TabIndex = 0;
            this.lblStatusValue.Text = "CHƯA VÀO CA";
            // 
            // lblStatusTitle
            // 
            this.lblStatusTitle.AutoSize = true;
            this.lblStatusTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblStatusTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblStatusTitle.Location = new System.Drawing.Point(20, 15);
            this.lblStatusTitle.Name = "lblStatusTitle";
            this.lblStatusTitle.Size = new System.Drawing.Size(117, 17);
            this.lblStatusTitle.TabIndex = 1;
            this.lblStatusTitle.Text = "Trạng thái hiện tại";
            // 
            // lblTotalHoursValue
            // 
            this.lblTotalHoursValue.AutoSize = true;
            this.lblTotalHoursValue.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalHoursValue.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblTotalHoursValue.Location = new System.Drawing.Point(260, 35);
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
            this.lblTotalHoursTitle.Location = new System.Drawing.Point(260, 15);
            this.lblTotalHoursTitle.Name = "lblTotalHoursTitle";
            this.lblTotalHoursTitle.Size = new System.Drawing.Size(126, 17);
            this.lblTotalHoursTitle.TabIndex = 3;
            this.lblTotalHoursTitle.Text = "Tổng công tháng này";
            // 
            // pnlClock
            // 
            this.pnlClock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlClock.Controls.Add(this.btnCheckOut);
            this.pnlClock.Controls.Add(this.btnCheckIn);
            this.pnlClock.Controls.Add(this.lblDate);
            this.pnlClock.Controls.Add(this.lblTime);
            this.pnlClock.Controls.Add(this.lblClockTitle);
            this.pnlClock.Location = new System.Drawing.Point(20, 120);
            this.pnlClock.Name = "pnlClock";
            this.pnlClock.Size = new System.Drawing.Size(300, 390);
            this.pnlClock.TabIndex = 1;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.IndianRed;
            this.btnCheckOut.FlatAppearance.BorderSize = 0;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Location = new System.Drawing.Point(20, 310);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(260, 50);
            this.btnCheckOut.TabIndex = 4;
            this.btnCheckOut.Text = "CHECK OUT";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCheckIn.FlatAppearance.BorderSize = 0;
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnCheckIn.Location = new System.Drawing.Point(20, 240);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(260, 50);
            this.btnCheckIn.TabIndex = 3;
            this.btnCheckIn.Text = "CHECK IN";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDate.ForeColor = System.Drawing.Color.Gray;
            this.lblDate.Location = new System.Drawing.Point(0, 140);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(300, 30);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Thứ Năm, 16/04/2026";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(0, 70);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(300, 70);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "09:15:20";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClockTitle
            // 
            this.lblClockTitle.AutoSize = true;
            this.lblClockTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblClockTitle.ForeColor = System.Drawing.Color.White;
            this.lblClockTitle.Location = new System.Drawing.Point(15, 15);
            this.lblClockTitle.Name = "lblClockTitle";
            this.lblClockTitle.Size = new System.Drawing.Size(151, 21);
            this.lblClockTitle.TabIndex = 0;
            this.lblClockTitle.Text = "Thời gian hệ thống";
            // 
            // pnlLog
            // 
            this.pnlLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlLog.Controls.Add(this.dgvAttendanceLog);
            this.pnlLog.Controls.Add(this.lblLogTitle);
            this.pnlLog.Location = new System.Drawing.Point(340, 120);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(444, 390);
            this.pnlLog.TabIndex = 2;
            // 
            // dgvAttendanceLog
            // 
            this.dgvAttendanceLog.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dgvAttendanceLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAttendanceLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAttendanceLog.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAttendanceLog.Location = new System.Drawing.Point(15, 50);
            this.dgvAttendanceLog.Name = "dgvAttendanceLog";
            this.dgvAttendanceLog.Size = new System.Drawing.Size(414, 320);
            this.dgvAttendanceLog.TabIndex = 1;
            // 
            // lblLogTitle
            // 
            this.lblLogTitle.AutoSize = true;
            this.lblLogTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLogTitle.ForeColor = System.Drawing.Color.White;
            this.lblLogTitle.Location = new System.Drawing.Point(15, 15);
            this.lblLogTitle.Name = "lblLogTitle";
            this.lblLogTitle.Size = new System.Drawing.Size(143, 21);
            this.lblLogTitle.TabIndex = 0;
            this.lblLogTitle.Text = "Nhật ký vào/ra ca";
            // 
            // tmrClock
            // 
            this.tmrClock.Enabled = true;
            this.tmrClock.Interval = 1000;
            // 
            // ucAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.pnlLog);
            this.Controls.Add(this.pnlClock);
            this.Controls.Add(this.pnlSummary);
            this.Name = "ucAttendance";
            this.Size = new System.Drawing.Size(804, 530);
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.pnlClock.ResumeLayout(false);
            this.pnlClock.PerformLayout();
            this.pnlLog.ResumeLayout(false);
            this.pnlLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblTotalHoursTitle;
        private System.Windows.Forms.Label lblTotalHoursValue;
        private System.Windows.Forms.Panel pnlClock;
        private System.Windows.Forms.Label lblClockTitle;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.Label lblLogTitle;
        private System.Windows.Forms.DataGridView dgvAttendanceLog;
        private System.Windows.Forms.Timer tmrClock;
    }
}