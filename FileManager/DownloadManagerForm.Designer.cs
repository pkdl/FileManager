namespace FileManager
{
    partial class DownloadManagerForm
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
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // URLTextBox
            // 
            this.URLTextBox.Location = new System.Drawing.Point(12, 12);
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.Size = new System.Drawing.Size(311, 20);
            this.URLTextBox.TabIndex = 0;
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(341, 12);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(68, 20);
            this.DownloadButton.TabIndex = 1;
            this.DownloadButton.Text = "Download";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // DownloadManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 262);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.URLTextBox);
            this.Name = "DownloadManagerForm";
            this.Text = "DownloadManagerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox URLTextBox;
        private System.Windows.Forms.Button DownloadButton;
    }
}