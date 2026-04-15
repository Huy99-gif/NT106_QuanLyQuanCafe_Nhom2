namespace Bai3
{
    partial class TCPServerForm
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
            this.btnListen = new System.Windows.Forms.Button();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();

            // btnListen
            this.btnListen.Location = new System.Drawing.Point(340, 15);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(80, 25);
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);

            // rtbMessages
            this.rtbMessages.Location = new System.Drawing.Point(15, 50);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(405, 200);
            this.rtbMessages.Text = "";

            // TCPServerForm
            this.ClientSize = new System.Drawing.Size(434, 261);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.btnListen);
            this.Name = "TCPServerForm";
            this.Text = "Lab03_Bai03";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TCPServerForm_FormClosing);
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.RichTextBox rtbMessages;
    }
}