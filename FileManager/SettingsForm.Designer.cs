namespace FileManager
{
    partial class SettingsForm
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
            this.StartDirTextBox = new System.Windows.Forms.TextBox();
            this.StartDirLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.Color1Label = new System.Windows.Forms.Label();
            this.Color1PickerLabel = new System.Windows.Forms.Label();
            this.Color2PickerLabel = new System.Windows.Forms.Label();
            this.Color2Label = new System.Windows.Forms.Label();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartDirTextBox
            // 
            this.StartDirTextBox.Location = new System.Drawing.Point(104, 6);
            this.StartDirTextBox.Name = "StartDirTextBox";
            this.StartDirTextBox.Size = new System.Drawing.Size(168, 20);
            this.StartDirTextBox.TabIndex = 0;
            // 
            // StartDirLabel
            // 
            this.StartDirLabel.AutoSize = true;
            this.StartDirLabel.Location = new System.Drawing.Point(12, 9);
            this.StartDirLabel.Name = "StartDirLabel";
            this.StartDirLabel.Size = new System.Drawing.Size(86, 13);
            this.StartDirLabel.TabIndex = 1;
            this.StartDirLabel.Text = "Starting directory";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(197, 226);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Color1Label
            // 
            this.Color1Label.AutoSize = true;
            this.Color1Label.Location = new System.Drawing.Point(12, 40);
            this.Color1Label.Name = "Color1Label";
            this.Color1Label.Size = new System.Drawing.Size(40, 13);
            this.Color1Label.TabIndex = 3;
            this.Color1Label.Text = "Color 1";
            // 
            // Color1PickerLabel
            // 
            this.Color1PickerLabel.AutoSize = true;
            this.Color1PickerLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Color1PickerLabel.Location = new System.Drawing.Point(170, 33);
            this.Color1PickerLabel.MinimumSize = new System.Drawing.Size(35, 20);
            this.Color1PickerLabel.Name = "Color1PickerLabel";
            this.Color1PickerLabel.Size = new System.Drawing.Size(35, 20);
            this.Color1PickerLabel.TabIndex = 4;
            this.Color1PickerLabel.Click += new System.EventHandler(this.Color1PickerLabel_Click);
            // 
            // Color2PickerLabel
            // 
            this.Color2PickerLabel.AutoSize = true;
            this.Color2PickerLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Color2PickerLabel.Location = new System.Drawing.Point(170, 68);
            this.Color2PickerLabel.MinimumSize = new System.Drawing.Size(35, 20);
            this.Color2PickerLabel.Name = "Color2PickerLabel";
            this.Color2PickerLabel.Size = new System.Drawing.Size(35, 20);
            this.Color2PickerLabel.TabIndex = 5;
            this.Color2PickerLabel.Click += new System.EventHandler(this.Color2PickerLabel_Click);
            // 
            // Color2Label
            // 
            this.Color2Label.AutoSize = true;
            this.Color2Label.Location = new System.Drawing.Point(12, 68);
            this.Color2Label.Name = "Color2Label";
            this.Color2Label.Size = new System.Drawing.Size(40, 13);
            this.Color2Label.TabIndex = 6;
            this.Color2Label.Text = "Color 2";
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(116, 226);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 7;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.Color2Label);
            this.Controls.Add(this.Color2PickerLabel);
            this.Controls.Add(this.Color1PickerLabel);
            this.Controls.Add(this.Color1Label);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.StartDirLabel);
            this.Controls.Add(this.StartDirTextBox);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox StartDirTextBox;
        private System.Windows.Forms.Label StartDirLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label Color1Label;
        private System.Windows.Forms.Label Color1PickerLabel;
        private System.Windows.Forms.Label Color2PickerLabel;
        private System.Windows.Forms.Label Color2Label;
        private System.Windows.Forms.Button LoadButton;
    }
}