using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PclAutoPrint {
    public partial class DragAndDropForm : Form {

        FolderWatcher watcher = new FolderWatcher();

        bool allowVisible = true;

        public DragAndDropForm() {
            InitializeComponent();
            allowVisible = !Properties.Settings.Default.StartMinimized;
            SetupFolderWatcher();
            DisplayVersionInformation();
        }

        protected override void SetVisibleCore(bool value) {
            if (!allowVisible) {
                value = false;
                if (!IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        void ShowForm () {  
            allowVisible = true;
            Show();
            Activate();
        }

        void DisplayVersionInformation () {
            labelVersion.Text = AppVersion.GetVersionString();
        }

        private void SetupFolderWatcher () {
            watcher.StopWatching();
            if (Properties.Settings.Default.MonitorFolder && !String.IsNullOrWhiteSpace(Properties.Settings.Default.FolderName))
                watcher.WatchFolder(Properties.Settings.Default.FolderName);

            if (watcher.IsWatching) {
                notifyIcon.Text = $"PCL to Printer (Monitoring {watcher.Folder})";
                labelMonitor.Text = $"Monitoring {watcher.Folder} for changes.";
            }
            else {
                notifyIcon.Text = "PCL to Printer (Monitor Off)";
                labelMonitor.Text = "Monitor turned off.";
            }
        }

        private void labelDropTarget_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void labelDropTarget_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files) FilePrinter.PrintOneFile(file, 1, !checkBox1.Checked);
        }

        private void pictureSettings_Click(object sender, EventArgs e) {
            ShowSettings();
        }

        private void ShowSettings () {
            var settingsForm = new SettingsForm();
            if (settingsForm.ShowDialog() == DialogResult.OK)
                SetupFolderWatcher();
        }

        private void DragAndDropForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (Properties.Settings.Default.CloseToTaskbar && e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
                notifyIcon.Visible = true;
                return;
            }
            notifyIcon.Visible = false;
            Application.Exit();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e) {
            ShowForm();
        }

        private void notifyShowFormMenuItem_Click(object sender, EventArgs e) {
            ShowForm();
        }

        private void notifyExitMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void notifyShowSettingsMenuItem_Click(object sender, EventArgs e) {
            ShowSettings();
        }
    }
}
