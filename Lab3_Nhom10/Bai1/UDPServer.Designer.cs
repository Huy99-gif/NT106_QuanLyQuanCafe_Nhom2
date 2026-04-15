namespace Bai1
{
    partial class UDPServer
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
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.lblMessages = new System.Windows.Forms.Label();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();

            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(20, 25);
            this.lblPort.Text = "Port";

            this.txtPort.Location = new System.Drawing.Point(55, 22);
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.Text = "8080";

            this.btnListen.Location = new System.Drawing.Point(400, 20);
            this.btnListen.Size = new System.Drawing.Size(75, 23);
            this.btnListen.Text = "Listen";
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);

            this.lblMessages.AutoSize = true;
            this.lblMessages.Location = new System.Drawing.Point(20, 60);
            this.lblMessages.Text = "Received messages";

            this.rtbMessages.Location = new System.Drawing.Point(23, 76);
            this.rtbMessages.Size = new System.Drawing.Size(452, 170);
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.BackColor = System.Drawing.Color.White;

            this.ClientSize = new System.Drawing.Size(500, 270);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.lblMessages);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPort);
            this.Name = "UDPServer";
            this.Text = "UDP Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UDPServer_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Label lblMessages;
        private System.Windows.Forms.RichTextBox rtbMessages;
    }
}