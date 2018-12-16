using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class TextBoxForm : Form
    {
        public String output
        {
            get; private set;
        }
        public TextBoxForm()
        {
            InitializeComponent();
        }

        public TextBoxForm(String head)
        {
            InitializeComponent();
            this.Text = head;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            output = textBox1.Text;
            this.Close();
        }
    }
}
