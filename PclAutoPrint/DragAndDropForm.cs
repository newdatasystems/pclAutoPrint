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

        public DragAndDropForm() {
            InitializeComponent();
            SetupFolderWatcher();
        }

        private void SetupFolderWatcher () {
            watcher.StopWatching();
            if (!String.IsNullOrWhiteSpace(Properties.Settings.Default.FolderName))
                watcher.WatchFolder(Properties.Settings.Default.FolderName);

            if (watcher.IsWatching) {
                labelMonitor.Text = String.Format("Monitoring {0} for changes.", watcher.Folder);
            }
            else {
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
            var settingsForm = new SettingsForm();
            if (settingsForm.ShowDialog() == DialogResult.OK)
                SetupFolderWatcher();
        }
    }
}
