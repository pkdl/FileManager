namespace FileManager
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LeftDiskMenuButton = new FileManager.MenuButton();
            this.LeftDirectoryPanel = new FileManager.ExtListView();
            this.LeftPathTextbox = new System.Windows.Forms.TextBox();
            this.RightDiskMenuButton = new FileManager.MenuButton();
            this.RightDirectoryPanel = new FileManager.ExtListView();
            this.RightPathTextbox = new System.Windows.Forms.TextBox();
            this.CopyButton = new System.Windows.Forms.Button();
            this.MoveButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.RenameButton = new System.Windows.Forms.Button();
            this.ArchiveButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.PFEArchiveButton = new System.Windows.Forms.Button();
            this.DownloadFormOpenButton = new System.Windows.Forms.Button();
            this.tasksArchiveButton = new System.Windows.Forms.Button();
            this.fileSearchTextBox = new System.Windows.Forms.TextBox();
            this.FileSearchLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LeftDiskMenuButton);
            this.splitContainer1.Panel1.Controls.Add(this.LeftDirectoryPanel);
            this.splitContainer1.Panel1.Controls.Add(this.LeftPathTextbox);
            this.splitContainer1.Panel1MinSize = 50;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.RightDiskMenuButton);
            this.splitContainer1.Panel2.Controls.Add(this.RightDirectoryPanel);
            this.splitContainer1.Panel2.Controls.Add(this.RightPathTextbox);
            this.splitContainer1.Size = new System.Drawing.Size(702, 387);
            this.splitContainer1.SplitterDistance = 343;
            this.splitContainer1.TabIndex = 0;
            // 
            // LeftDiskMenuButton
            // 
            this.LeftDiskMenuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LeftDiskMenuButton.Location = new System.Drawing.Point(277, 3);
            this.LeftDiskMenuButton.Name = "LeftDiskMenuButton";
            this.LeftDiskMenuButton.Size = new System.Drawing.Size(64, 20);
            this.LeftDiskMenuButton.TabIndex = 2;
            this.LeftDiskMenuButton.Text = "Disks";
            this.LeftDiskMenuButton.UseVisualStyleBackColor = true;
            // 
            // LeftDirectoryPanel
            // 
            this.LeftDirectoryPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LeftDirectoryPanel.Location = new System.Drawing.Point(3, 26);
            this.LeftDirectoryPanel.Name = "LeftDirectoryPanel";
            this.LeftDirectoryPanel.Size = new System.Drawing.Size(336, 358);
            this.LeftDirectoryPanel.TabIndex = 1;
            this.LeftDirectoryPanel.UseCompatibleStateImageBehavior = false;
            this.LeftDirectoryPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LeftDirectoryPanel_MouseDoubleClick);
            this.LeftDirectoryPanel.MouseEnter += new System.EventHandler(this.PanelMouseOverHandler);
            // 
            // LeftPathTextbox
            // 
            this.LeftPathTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LeftPathTextbox.Location = new System.Drawing.Point(3, 3);
            this.LeftPathTextbox.Name = "LeftPathTextbox";
            this.LeftPathTextbox.Size = new System.Drawing.Size(274, 20);
            this.LeftPathTextbox.TabIndex = 0;
            // 
            // RightDiskMenuButton
            // 
            this.RightDiskMenuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RightDiskMenuButton.Location = new System.Drawing.Point(274, 3);
            this.RightDiskMenuButton.Name = "RightDiskMenuButton";
            this.RightDiskMenuButton.Size = new System.Drawing.Size(64, 20);
            this.RightDiskMenuButton.TabIndex = 3;
            this.RightDiskMenuButton.Text = "Disks";
            this.RightDiskMenuButton.UseVisualStyleBackColor = true;
            // 
            // RightDirectoryPanel
            // 
            this.RightDirectoryPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RightDirectoryPanel.Location = new System.Drawing.Point(0, 26);
            this.RightDirectoryPanel.Name = "RightDirectoryPanel";
            this.RightDirectoryPanel.Size = new System.Drawing.Size(338, 358);
            this.RightDirectoryPanel.TabIndex = 1;
            this.RightDirectoryPanel.UseCompatibleStateImageBehavior = false;
            this.RightDirectoryPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RightDirectoryPanel_MouseDoubleClick);
            this.RightDirectoryPanel.MouseEnter += new System.EventHandler(this.PanelMouseOverHandler);
            // 
            // RightPathTextbox
            // 
            this.RightPathTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RightPathTextbox.Location = new System.Drawing.Point(0, 3);
            this.RightPathTextbox.Name = "RightPathTextbox";
            this.RightPathTextbox.Size = new System.Drawing.Size(268, 20);
            this.RightPathTextbox.TabIndex = 0;
            // 
            // CopyButton
            // 
            this.CopyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CopyButton.Location = new System.Drawing.Point(12, 502);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(66, 30);
            this.CopyButton.TabIndex = 1;
            this.CopyButton.Text = "[F5] Copy";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // MoveButton
            // 
            this.MoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MoveButton.Location = new System.Drawing.Point(84, 502);
            this.MoveButton.Name = "MoveButton";
            this.MoveButton.Size = new System.Drawing.Size(66, 30);
            this.MoveButton.TabIndex = 2;
            this.MoveButton.Text = "[F6] Move";
            this.MoveButton.UseVisualStyleBackColor = true;
            this.MoveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveButton.Location = new System.Drawing.Point(156, 502);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(76, 30);
            this.RemoveButton.TabIndex = 3;
            this.RemoveButton.Text = "[F7] Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // RenameButton
            // 
            this.RenameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RenameButton.Location = new System.Drawing.Point(238, 502);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(90, 30);
            this.RenameButton.TabIndex = 4;
            this.RenameButton.Text = "[F8] Rename";
            this.RenameButton.UseVisualStyleBackColor = true;
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // ArchiveButton
            // 
            this.ArchiveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ArchiveButton.Location = new System.Drawing.Point(334, 501);
            this.ArchiveButton.Name = "ArchiveButton";
            this.ArchiveButton.Size = new System.Drawing.Size(90, 30);
            this.ArchiveButton.TabIndex = 5;
            this.ArchiveButton.Text = "[F9] Archive";
            this.ArchiveButton.UseVisualStyleBackColor = true;
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsButton.Location = new System.Drawing.Point(597, 502);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(90, 30);
            this.SettingsButton.TabIndex = 6;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchButton.Location = new System.Drawing.Point(427, 501);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(90, 30);
            this.SearchButton.TabIndex = 7;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // PFEArchiveButton
            // 
            this.PFEArchiveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PFEArchiveButton.Location = new System.Drawing.Point(334, 465);
            this.PFEArchiveButton.Name = "PFEArchiveButton";
            this.PFEArchiveButton.Size = new System.Drawing.Size(90, 30);
            this.PFEArchiveButton.TabIndex = 8;
            this.PFEArchiveButton.Text = "PFE Archive";
            this.PFEArchiveButton.UseVisualStyleBackColor = true;
            this.PFEArchiveButton.Click += new System.EventHandler(this.PFEArchiveButton_Click);
            // 
            // DownloadFormOpenButton
            // 
            this.DownloadFormOpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DownloadFormOpenButton.Location = new System.Drawing.Point(12, 463);
            this.DownloadFormOpenButton.Name = "DownloadFormOpenButton";
            this.DownloadFormOpenButton.Size = new System.Drawing.Size(66, 30);
            this.DownloadFormOpenButton.TabIndex = 9;
            this.DownloadFormOpenButton.Text = "Download";
            this.DownloadFormOpenButton.UseVisualStyleBackColor = true;
            this.DownloadFormOpenButton.Click += new System.EventHandler(this.DownloadFormOpenButton_Click);
            // 
            // tasksArchiveButton
            // 
            this.tasksArchiveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tasksArchiveButton.Location = new System.Drawing.Point(334, 429);
            this.tasksArchiveButton.Name = "tasksArchiveButton";
            this.tasksArchiveButton.Size = new System.Drawing.Size(90, 30);
            this.tasksArchiveButton.TabIndex = 10;
            this.tasksArchiveButton.Text = "Tasks Archive";
            this.tasksArchiveButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tasksArchiveButton.UseVisualStyleBackColor = true;
            this.tasksArchiveButton.Click += new System.EventHandler(this.tasksArchiveButton_Click);
            // 
            // fileSearchTextBox
            // 
            this.fileSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileSearchTextBox.Location = new System.Drawing.Point(84, 403);
            this.fileSearchTextBox.Name = "fileSearchTextBox";
            this.fileSearchTextBox.Size = new System.Drawing.Size(421, 20);
            this.fileSearchTextBox.TabIndex = 3;
            // 
            // FileSearchLabel
            // 
            this.FileSearchLabel.AutoSize = true;
            this.FileSearchLabel.Location = new System.Drawing.Point(12, 403);
            this.FileSearchLabel.Name = "FileSearchLabel";
            this.FileSearchLabel.Size = new System.Drawing.Size(61, 13);
            this.FileSearchLabel.TabIndex = 11;
            this.FileSearchLabel.Text = "File search:";
            // 
            // sss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 537);
            this.Controls.Add(this.FileSearchLabel);
            this.Controls.Add(this.fileSearchTextBox);
            this.Controls.Add(this.tasksArchiveButton);
            this.Controls.Add(this.DownloadFormOpenButton);
            this.Controls.Add(this.PFEArchiveButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.ArchiveButton);
            this.Controls.Add(this.RenameButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.MoveButton);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.splitContainer1);
            this.Name = "sss";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ExtListView LeftDirectoryPanel;
        private System.Windows.Forms.TextBox LeftPathTextbox;
        private ExtListView RightDirectoryPanel;
        private System.Windows.Forms.TextBox RightPathTextbox;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.Button MoveButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button RenameButton;
        private System.Windows.Forms.Button ArchiveButton;
        private MenuButton LeftDiskMenuButton;
        private MenuButton RightDiskMenuButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button PFEArchiveButton;
        private System.Windows.Forms.Button DownloadFormOpenButton;
        private System.Windows.Forms.Button tasksArchiveButton;
        private System.Windows.Forms.TextBox fileSearchTextBox;
        private System.Windows.Forms.Label FileSearchLabel;
    }
}

