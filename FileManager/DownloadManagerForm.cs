using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace FileManager
{
    public partial class DownloadManagerForm : Form
    {
        public List<DownloadEntry> downloadEntryList = new List<DownloadEntry>();

        MainForm parent;
        public DownloadManagerForm(MainForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            FormClosing += HideForm;
        }

        private void HideForm(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            else
            {
                (sender as DownloadManagerForm).StopAllDownloads();
            }
        }

        private void AddEntry(String URL)
        {
            int posY = downloadEntryList.Any() ? downloadEntryList.Last().Bottom + 10 : 50;
            var entry = new DownloadEntry(10, posY, URL, this);
            downloadEntryList.Add(entry);
        }

        private void StopAllDownloads()
        {
            foreach(var entry in downloadEntryList)
            {
                entry.Cancel();
            }
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            AddEntry(URLTextBox.Text);
            URLTextBox.Text = "";
        }

    }

    public class DownloadEntry
    {
        public ProgressBar progressBar;
        public Button cancelButton;
        private Label statusLabel;
        private String filename;

        public int Bottom
        {
            get { return statusLabel.Bottom; }
        }

        private WebClient webClient = new WebClient();
        public DownloadEntry(int posX, int posY, String URL, DownloadManagerForm parentForm)
        {
            webClient.DownloadProgressChanged += wc_DownloadProgressChanged;
            var uri = new Uri(URL);
            filename = System.IO.Path.GetFileName(uri.LocalPath);
            String filePath = AdaptFileNameIfExist(System.IO.Path.Combine(@"D:\test", filename));
            webClient.DownloadFileAsync(uri, filePath);

            progressBar = new ProgressBar
            {
                Left = posX,
                Top = posY,
                Width = 200,
                Height = 15
            };
            parentForm.Controls.Add(progressBar);

            cancelButton = new Button()
            {
                Left = progressBar.Right + 10,
                Top = progressBar.Top,
                Width = 80,
                Height = 20,
                Text = "Cancel"
            };
            cancelButton.Font = new Font(cancelButton.Font.FontFamily, 8);
            cancelButton.Click += (o, a) => { Cancel(); };
            parentForm.Controls.Add(cancelButton);

            statusLabel = new Label()
            {
                Left = progressBar.Left,
                Top = progressBar.Bottom + 10,
                Text = String.Concat("Downloading ", filename),
                AutoSize = true,
                MaximumSize = new Size(progressBar.Width + cancelButton.Width + 10, 15)
            };
            parentForm.Controls.Add(statusLabel);
        }

        private String AdaptFileNameIfExist(String fullPath)
        {
            int count = 1;

            string fileNameOnly = System.IO.Path.GetFileNameWithoutExtension(fullPath);
            string extension = System.IO.Path.GetExtension(fullPath);
            string path = System.IO.Path.GetDirectoryName(fullPath);

            while (System.IO.File.Exists(fullPath))
            {
                string tempFileName = string.Format("{0}({1})", fileNameOnly, count++);
                fullPath = System.IO.Path.Combine(path, tempFileName + extension);
            }

            return fullPath;
        }

        public void Cancel()
        {
            webClient.CancelAsync();
            statusLabel.Text = String.Concat("Canceled ", filename);
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
    }
}
