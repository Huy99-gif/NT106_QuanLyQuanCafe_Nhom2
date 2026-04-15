namespace Bai1
{
    partial class UDPClient
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
            this.lblIP = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(20, 20);
            this.lblIP.Text = "IP Remote host";

            this.txtIP.Location = new System.Drawing.Point(23, 36);
            this.txtIP.Size = new System.Drawing.Size(320, 20);
            this.txtIP.Text = "127.0.0.1";

            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(360, 20);
            this.lblPort.Text = "Port";

            this.txtPort.Location = new System.Drawing.Point(363, 36);
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.Text = "8080";

            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(20, 70);
            this.lblMessage.Text = "Message";

            this.txtMessage.Location = new System.Drawing.Point(23, 86);
            this.txtMessage.Multiline = true;
            this.txtMessage.Size = new System.Drawing.Size(440, 80);
            this.txtMessage.Text = "Đây là Bài 01 - Lab 3 - Lập trình mạng căn bản";

            this.btnSend.Location = new System.Drawing.Point(23, 180);
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            this.ClientSize = new System.Drawing.Size(490, 220);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.lblIP);
            this.Name = "UDPClient";
            this.Text = "UDP Client";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
    }
}