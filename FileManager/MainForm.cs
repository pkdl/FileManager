using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

using Ionic.Zip;


namespace FileManager
{
    public partial class MainForm : Form
    {
        private Panel left;
        private Panel right;
        public Settings settings;

        private Panel activePanel;

        private DownloadManagerForm downloadForm;

        FileSearcher fileSearcher = new FileSearcher();

        public MainForm()
        {
            InitializeComponent();

            settings = new Settings(this);
            settings.Load();

            left = new Panel(LeftPathTextbox, LeftDirectoryPanel, LeftDiskMenuButton, this);
            right = new Panel(RightPathTextbox, RightDirectoryPanel, RightDiskMenuButton, this);

            LeftDirectoryPanel.View = View.Details;
            RightDirectoryPanel.View = View.Details;

            SetActivePanel(left);

            left.ShowDirectory();

            right.ShowDirectory();

            downloadForm = new DownloadManagerForm(this);

            fileSearchTextBox.TextChanged += fileSearchTextBox_TextChanged;
            FormClosing += (o, a) => { downloadForm.Close(); };
        }

        private void SetActivePanel(Panel panel)
        {
            Panel other;
            if (panel == left) other = right;
            else other = left;

            activePanel = panel;
            panel.isActive = true;
            other.isActive = false;

            if (Form.ActiveForm == this)
            {
                panel.view.Focus();
            }
            panel.DrawBorder();
            other.DrawBorder();
        }

        private void SwitchCurrentPanel()
        {
            if (activePanel == left)
            {
                SetActivePanel(right);
            }
            else
            {
                SetActivePanel(left);
            }
        }

        #region FileOperations
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(destDirName, file.Name);

                // Copy the file.
                file.CopyTo(temppath, false);
            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = Path.Combine(destDirName, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private void Copy()
        {
            if (activePanel == left)
            {
                Copy(left, right);
            }
            if (activePanel == right)
            {
                Copy(right, left);
            }
        }

        private void CopyItem(ListViewItem listItem, String to)
        {
            object item = listItem.Tag;
            if (item is FileInfo)
            {
                FileInfo file = item as FileInfo;
                try
                {
                    File.Copy(file.FullName, Path.Combine(to, file.Name));
                }
                catch (IOException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            if (item is DirectoryInfo)
            {
                DirectoryInfo dir = item as DirectoryInfo;
                try
                {
                    DirectoryCopy(dir.FullName, Path.Combine(to, dir.Name), true);
                }
                catch (IOException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
        private void Copy(Panel from, Panel to)
        {
            foreach (ListViewItem listItem in from.view.SelectedItems)
            {
                CopyItem(listItem, to.data.CurrentPath);
            }
        }

        private void MoveItems()
        {
            if (activePanel == left)
            {
                MoveItems(left, right);
            }
            if (activePanel == right)
            {
                MoveItems(right, left);
            }
        }

        private void MoveItems(Panel from, Panel to)
        {
            foreach (ListViewItem listItem in from.view.SelectedItems)
            {
                object item = listItem.Tag;
                if (item is FileInfo)
                {
                    FileInfo file = item as FileInfo;
                    try
                    {
                        File.Move(file.FullName, Path.Combine(to.data.CurrentPath, file.Name));
                    }
                    catch (IOException exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                if (item is DirectoryInfo)
                {
                    DirectoryInfo dir = item as DirectoryInfo;
                    try
                    {
                        Directory.Move(dir.FullName, Path.Combine(to.data.CurrentPath, dir.Name));
                    }
                    catch (IOException exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                
            }
        }
        private void Remove()
        {
            foreach (ListViewItem item in activePanel.view.SelectedItems)
            {
                if (item.SubItems[1].Text == "File")
                {
                    try
                    {
                        System.IO.File.Delete(System.IO.Path.Combine(activePanel.data.CurrentPath, item.Text));
                    }
                    catch (System.IO.IOException exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void Rename()
        {
            if (activePanel.view.SelectedItems.Count != 1) return;

            String newname;
            using (var form = new TextBoxForm("Enter new name"))
            {
                form.ShowDialog();
                newname = form.output;
            }

            var listItem = activePanel.view.SelectedItems[0];

            object item = listItem.Tag;
            if (item is FileInfo)
            {
                FileInfo file = item as FileInfo;
                try
                {
                    File.Move(file.FullName, Path.Combine(activePanel.data.CurrentPath, newname));
                }
                catch (IOException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            if (item is DirectoryInfo)
            {
                DirectoryInfo dir = item as DirectoryInfo;
                try
                {
                    Directory.Move(dir.FullName, Path.Combine(activePanel.data.CurrentPath, newname));
                }
                catch (IOException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

        }

        private void Archive()
        {
            using (ZipFile zip = new ZipFile())
            {
                foreach (ListViewItem listItem in activePanel.view.SelectedItems)
                {
                    object item = listItem.Tag;
                    if (item is FileInfo)
                    {
                        FileInfo file = item as FileInfo;
                        zip.AddFile(file.FullName);
                    }
                    if (item is DirectoryInfo)
                    {
                        DirectoryInfo dir = item as DirectoryInfo;
                        zip.AddDirectory(dir.FullName);
                    }
                }
                var time = DateTime.Now;
                String name = activePanel.data.currentDir.Name + " " + time.ToString().Replace(':', '-') + ".zip";
                zip.Save(Path.Combine(activePanel.data.CurrentPath, name));
            }
        }

        private void ArchiveSingleItem(ListViewItem listItem)
        {
            object item = listItem.Tag;
            if (item is FileInfo)
            {
                using (ZipFile zip = new ZipFile())
                {
                    FileInfo file = item as FileInfo;
                    var time = DateTime.Now;
                    String path = Path.Combine(file.DirectoryName,
                        file.Name + " " + time.ToString().Replace(':', '-') + ".zip");
                    zip.Save(path);
                }
            }
        }

        private void ParallelForEachArchive(IEnumerable<ListViewItem> items)
        {
            Parallel.ForEach(items, listItem =>
            {
                ArchiveSingleItem(listItem);
            });
        }

        private void ParallelTasksArchive(IEnumerable<ListViewItem> items)
        {
            foreach(ListViewItem listItem in items)
            {
                Task.Run( () => ArchiveSingleItem(listItem));
            }
        }

        private void Open()
        {
            if (activePanel.view.SelectedItems.Count == 1)
            {
                Open(activePanel.view.SelectedItems[0], activePanel);
            }
        }

        private void Open(ListViewItem listItem, Panel panel)
        {
            object item = listItem.Tag;
            if (item is FileInfo)
            {
                FileInfo file = item as FileInfo;
                System.Diagnostics.Process.Start(file.FullName);

            }
            if (item is DirectoryInfo)
            {
                DirectoryInfo dir = item as DirectoryInfo;
                panel.ShowDirectory(dir.FullName);
            }
        }

        #endregion

        #region EventHandlers
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                SwitchCurrentPanel();
                return true;
            }
            if (keyData == Keys.F5)
            {
                Copy();
                return true;
            }

            if (keyData == Keys.F6)
            {
                MoveItems();
                return true;
            }

            if (keyData == Keys.F7)
            {
                Remove();
                return true;
            }

            if (keyData == Keys.F8)
            {
                Rename();
                return true;
            }

            if (keyData == Keys.F9)
            {
                Archive();
                return true;
            }

            if (keyData == Keys.Enter)
            {
                Open();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void PanelMouseOverHandler(object sender, EventArgs e)
        {
            if (sender == right.view)
            {
                SetActivePanel(right);
            }   
            if (sender == left.view)
            {
                SetActivePanel(left);
            }
        }

        private void HandleItemDoubleClick(ListView list, object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = list.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            Panel panel;

            if (sender == left.view)
            {
                panel = left;
            }
            else
            {
                panel = right;
            }

            if (item != null)
            {
                Open(item, panel);
            }
            else
            {
                list.SelectedItems.Clear();
                MessageBox.Show("No Item is selected");
            }
        }

        private void LeftDirectoryPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            HandleItemDoubleClick(LeftDirectoryPanel, sender, e);
        }

        private void RightDirectoryPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            HandleItemDoubleClick(RightDirectoryPanel, sender, e);
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            MoveItems();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            Rename();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            using (var form = new SettingsForm(settings))
            {
                form.ShowDialog();
            }
        }
        #endregion

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var PA = new ParallelActions(activePanel.data.CurrentPath);
            PA.Start();
            var form = new SearchResultForm(PA);
            form.ShowDialog();
            PA.StopAllThreads();
        }

        private void PFEArchiveButton_Click(object sender, EventArgs e)
        {
            ParallelForEachArchive(activePanel.view.SelectedItems.Cast<ListViewItem>());
        }

        private void DownloadFormOpenButton_Click(object sender, EventArgs e)
        {            
            downloadForm.Show();
        }

        private void tasksArchiveButton_Click(object sender, EventArgs e)
        {
            ParallelTasksArchive(activePanel.view.SelectedItems.Cast<ListViewItem>());
        }

        private void fileSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            fileSearcher.CancelSearchByName();
            fileSearcher.StartSearchByName(fileSearchTextBox.Text, activePanel);
        }
    }

    public class Panel
    {
        public TextBox pathTextBox;
        public ExtListView view;
        public DirectoryBrowser data;
        public MenuButton diskButton;

        public bool isActive = false;
        

        FileSystemWatcher watcher;

        public Panel(TextBox tb, ExtListView view, MenuButton diskButton, MainForm form)
        {
            this.pathTextBox = tb;
            this.view = view;
            this.diskButton = diskButton;
            diskButton.parentPanel = this;
            this.data = new DirectoryBrowser();
            data.CurrentPath = (String)form.settings.SettingsList["StartDir"];

            watcher = new FileSystemWatcher();
            watcher.Path = data.CurrentPath;
            watcher.Filter = "*.*";

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;
        }

        public void DrawBorder()
        {
            Color color;
            if (isActive) color = Color.Blue;
            else color = Color.Gray;

            if (view.InvokeRequired)
            {
                view.Invoke(new Action(() => { view.DrawBorder(color); }));
            }
            else view.DrawBorder(color);
        }
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            ShowDirectory();
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            ShowDirectory();
        }

        private void HandleChange()
        {
            var path = data.CurrentPath;
            data.GetDirectoryInfo(path);
            watcher.Path = path;

            view.Invoke(new Action(() => { view.Fill(data); }));
            pathTextBox.Text = data.CurrentPath;
            DrawBorder();
        }

        public void ShowDirectory()
        {
            ShowDirectory(data.CurrentPath);
        }
        public void ShowDirectory(String path)
        {
            data.GetDirectoryInfo(path);
            watcher.Path = path;

            if (view.InvokeRequired)
                view.Invoke(new Action(() => { view.Fill(data); }));
            else
                view.Fill(data);
            pathTextBox.Text = data.CurrentPath;
            DrawBorder();
        }

    }

    public class ExtListView : ListView
    {
        [DllImport("user32")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);

        Color lastColor = Color.White;
        public void Fill(DirectoryBrowser browser)
        {
            Clear();
            Columns.Add("Name");
            Columns[0].Width = 200;

            Columns.Add("Type");

            ListViewItem item = new ListViewItem(@"..");
            item.SubItems.Add("Directory");
            var parentDir = browser.currentDir.Parent;
            item.Tag = parentDir;

            Items.Add(item);

            foreach (var dir in browser.dirList)
            {
                Add(dir);
            }

            foreach (var file in browser.fileList)
            {
                Add(file);
            }
        }

        public void Add(FileInfo file)
        {
            var item = new ListViewItem(file.Name);
            item.SubItems.Add("File");
            item.Tag = file;
            if (lastColor == Color.White)
            {
                item.BackColor = Color.FromArgb(0xEE, 0xEE, 0xEE);
                lastColor = Color.LightGray;
            }
            else
            {
                item.BackColor = Color.White;
                lastColor = Color.White;
            }
            Items.Add(item);
        }

        public void Add(DirectoryInfo dir)
        {
            var item = new ListViewItem(dir.Name);
            item.SubItems.Add("Directory");
            item.Tag = dir;
            if (lastColor == Color.White)
            {
                item.BackColor = Color.FromArgb(0xEE, 0xEE, 0xEE);
                lastColor = Color.LightGray;
            }
            else
            {
                item.BackColor = Color.White;
                lastColor = Color.White;
            }
            Items.Add(item);
        }

        public void DrawBorder(Color color)
        {
            var dc = GetWindowDC(Handle);
            using (Graphics g = Graphics.FromHdc(dc))
            { 
                var pen = new Pen(color, 3);
                g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }   
            
        
    }


    public class MenuButton : Button
    {
        [DefaultValue(null)]
        public ContextMenuStrip Menu { get; set; }

        [DefaultValue(false)]
        public bool ShowMenuUnderCursor { get; set; }

        public Panel parentPanel;

        private ContextMenuStrip GenerateDiskMenu()
        {
            var Menu = new ContextMenuStrip();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                var item = new ToolStripMenuItem()
                {
                    Text = drive.Name
                };
                item.Click += Item_Click;
                Menu.Items.Add(item);
            }
            return Menu;
        }

        private void Item_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            parentPanel.ShowDirectory(item.Text);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);

            Menu = GenerateDiskMenu();
 
            if (Menu != null && mevent.Button == MouseButtons.Left)
            {
                Point menuLocation;

                if (ShowMenuUnderCursor)
                {
                    menuLocation = mevent.Location;
                }
                else
                {
                    menuLocation = new Point(0, Height);
                }

                Menu.Show(this, menuLocation);
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            if (Menu != null)
            {
                int arrowX = ClientRectangle.Width - 14;
                int arrowY = ClientRectangle.Height / 2 - 1;

                Brush brush = Enabled ? SystemBrushes.ControlText : SystemBrushes.ButtonShadow;
                Point[] arrows = new Point[] { new Point(arrowX, arrowY), new Point(arrowX + 7, arrowY), new Point(arrowX + 3, arrowY + 4) };
                pevent.Graphics.FillPolygon(brush, arrows);
            }
        }
    }


}
