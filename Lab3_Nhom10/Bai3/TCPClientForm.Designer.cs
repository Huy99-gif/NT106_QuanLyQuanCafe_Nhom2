namespace Bai3
{
    partial class TCPClientForm
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
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // btnSend
            this.btnSend.Location = new System.Drawing.Point(30, 20);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(220, 30);
            this.btnSend.Text = "Send message";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // TCPClientForm
            this.ClientSize = new System.Drawing.Size(284, 81);
            this.Controls.Add(this.btnSend);
            this.Name = "TCPClientForm";
            this.Text = "TCPClientForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TCPClientForm_FormClosing);
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button btnSend;
    }
}