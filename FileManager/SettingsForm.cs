using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class SettingsForm : Form
    {
        Settings settings;
        public SettingsForm()
        {
            InitializeComponent();
        }

        public SettingsForm(Settings settings)
        {
            InitializeComponent();
            this.settings = settings;

            StartDirTextBox.Text = (String)settings.DefaultSettingsList["StartDir"];
            Color1PickerLabel.BackColor = (System.Drawing.Color)settings.DefaultSettingsList["Color1"];
            Color2PickerLabel.BackColor = (System.Drawing.Color)settings.DefaultSettingsList["Color2"];

        }



        private void SaveButton_Click(object sender, EventArgs e)
        {
            settings.SetEntry("StartDir", StartDirTextBox.Text);
            settings.SetEntry("Color1", Color1PickerLabel.BackColor);
            settings.SetEntry("Color2", Color2PickerLabel.BackColor);
            settings.DoSerializattion();
            this.Close();
        }

        private void Color1PickerLabel_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = (System.Drawing.Color)settings.DefaultSettingsList["Color1"];

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            Color1PickerLabel.BackColor = MyDialog.Color;
        }

        private void Color2PickerLabel_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = (System.Drawing.Color)settings.DefaultSettingsList["Color2"];

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                Color2PickerLabel.BackColor = MyDialog.Color;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            settings.DoDeserealization();
            StartDirTextBox.Text = (String)settings.SettingsList["StartDir"];
            Color1PickerLabel.BackColor = (System.Drawing.Color)settings.SettingsList["Color1"];
            Color2PickerLabel.BackColor = (System.Drawing.Color)settings.SettingsList["Color2"];
        }
    }
}
