namespace GUI
{
    partial class ucChatOrderStaff
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
            this.pnlChat = new System.Windows.Forms.Panel();
            this.btnOpenChatWindow = new System.Windows.Forms.Button();
            this.cmbChatTarget = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lstChatHistory = new System.Windows.Forms.ListBox();
            this.lblChatTitle = new System.Windows.Forms.Label();
            this.pnlChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlChat
            // 
            this.pnlChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlChat.Controls.Add(this.btnOpenChatWindow);
            this.pnlChat.Controls.Add(this.cmbChatTarget);
            this.pnlChat.Controls.Add(this.btnSend);
            this.pnlChat.Controls.Add(this.txtMessage);
            this.pnlChat.Controls.Add(this.lstChatHistory);
            this.pnlChat.Controls.Add(this.lblChatTitle);
            this.pnlChat.Dock = System.Windows.Forms.DockStyle.Fill; // Chiếm toàn bộ diện tích
            this.pnlChat.Location = new System.Drawing.Point(0, 0);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Padding = new System.Windows.Forms.Padding(20);
            this.pnlChat.Size = new System.Drawing.Size(800, 530);
            this.pnlChat.TabIndex = 0;
            // 
            // btnOpenChatWindow
            // 
            this.btnOpenChatWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenChatWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnOpenChatWindow.FlatAppearance.BorderSize = 0;
            this.btnOpenChatWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenChatWindow.ForeColor = System.Drawing.Color.White;
            this.btnOpenChatWindow.Location = new System.Drawing.Point(685, 15);
            this.btnOpenChatWindow.Name = "btnOpenChatWindow";
            this.btnOpenChatWindow.Size = new System.Drawing.Size(100, 30);
            this.btnOpenChatWindow.Text = "Pop-out ↗";
            this.btnOpenChatWindow.UseVisualStyleBackColor = false;
            // 
            // cmbChatTarget
            // 
            this.cmbChatTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbChatTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cmbChatTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChatTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbChatTarget.ForeColor = System.Drawing.Color.White;
            this.cmbChatTarget.FormattingEnabled = true;
            this.cmbChatTarget.Location = new System.Drawing.Point(20, 55);
            this.cmbChatTarget.Name = "cmbChatTarget";
            this.cmbChatTarget.Size = new System.Drawing.Size(760, 23);
            this.cmbChatTarget.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(710, 480);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(70, 30);
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = false;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMessage.ForeColor = System.Drawing.Color.White;
            this.txtMessage.Location = new System.Drawing.Point(20, 480);
            this.txtMessage.Multiline = false;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(680, 30);
            this.txtMessage.TabIndex = 2;
            // 
            // lstChatHistory
            // 
            this.lstChatHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lstChatHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lstChatHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstChatHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstChatHistory.ForeColor = System.Drawing.Color.LightGray;
            this.lstChatHistory.FormattingEnabled = true;
            this.lstChatHistory.ItemHeight = 17;
            this.lstChatHistory.Location = new System.Drawing.Point(20, 90);
            this.lstChatHistory.Name = "lstChatHistory";
            this.lstChatHistory.Size = new System.Drawing.Size(760, 374);
            this.lstChatHistory.TabIndex = 3;
            // 
            // lblChatTitle
            // 
            this.lblChatTitle.AutoSize = true;
            this.lblChatTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblChatTitle.ForeColor = System.Drawing.Color.White;
            this.lblChatTitle.Location = new System.Drawing.Point(18, 15);
            this.lblChatTitle.Name = "lblChatTitle";
            this.lblChatTitle.Size = new System.Drawing.Size(130, 21);
            this.lblChatTitle.Text = "INTERNAL CHAT";
            // 
            // ucChatOrderStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlChat);
            this.Name = "ucChatOrderStaff";
            this.Size = new System.Drawing.Size(800, 530);
            this.pnlChat.ResumeLayout(false);
            this.pnlChat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.Label lblChatTitle;
        private System.Windows.Forms.ListBox lstChatHistory;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ComboBox cmbChatTarget;
        private System.Windows.Forms.Button btnOpenChatWindow;
    }
}
