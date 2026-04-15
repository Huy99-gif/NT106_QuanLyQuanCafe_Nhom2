namespace Bai1
{
    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnServer = new System.Windows.Forms.Button();
            this.btnClient = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // btnServer
            this.btnServer.Location = new System.Drawing.Point(30, 30);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(120, 50);
            this.btnServer.Text = "UDP Server";
            this.btnServer.UseVisualStyleBackColor = true;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);

            // btnClient
            this.btnClient.Location = new System.Drawing.Point(180, 30);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(120, 50);
            this.btnClient.Text = "UDP Client";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);

            // Dashboard
            this.ClientSize = new System.Drawing.Size(334, 111);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.btnServer);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button btnServer;
        private System.Windows.Forms.Button btnClient;
    }
}
