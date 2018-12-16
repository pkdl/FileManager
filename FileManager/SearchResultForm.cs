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
    public partial class SearchResultForm : Form
    {
        ParallelActions data;
        public SearchResultForm()
        {
            InitializeComponent();
        }

        public SearchResultForm(ParallelActions data)
        {
            this.data = data;
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();
            listBox1.DataSource = data.results.ToArray();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = String.Format("Files in queue: {0}, Alive workers: {1}", data.queuedFilesCount, data.aliveWorkers);
            listBox1.DataSource = data.results.ToArray();
        }
    }
}
