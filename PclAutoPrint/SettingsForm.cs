using System;
using System.Windows.Forms;

namespace PclAutoPrint {
    public partial class SettingsForm : Form {
        public SettingsForm() {
            InitializeComponent();
        }

        private void Revert () {
            switch (Properties.Settings.Default.PrinterSelection) {
                case "Default":
                    radioPrinterDefault.Checked = true; break;
                case "Selected":
                    radioPrinterSelected.Checked = true; break;
                default:
                    radioPrinterPrompt.Checked = true; break;
            }

            textUserDelay.Text = Properties.Settings.Default.DelaySeconds.ToString();
            textMonitorFolder.Text = Properties.Settings.Default.FolderName;
            checkFolderMonitor.Checked = Properties.Settings.Default.MonitorFolder;
            checkAutoDelete.Checked = String.Equals(Properties.Settings.Default.DeleteFiles, "Delete");
            labelSelectedPrinter.Text = Properties.Settings.Default.PrinterName;
        }

        DialogResult SaveAndClose() {
            var printMode = "Prompt";
            if (radioPrinterDefault.Checked) {
                printMode = "Default";
            }
            if (radioPrinterSelected.Checked) {
                printMode = "Selected";
            }

            Properties.Settings.Default.PrinterSelection = printMode;

            Properties.Settings.Default.DelaySeconds = (Int32.TryParse(textUserDelay.Text,out var delaySeconds) ? delaySeconds : 0);
            Properties.Settings.Default.FolderName = textMonitorFolder.Text;
            Properties.Settings.Default.MonitorFolder = checkFolderMonitor.Checked;
            Properties.Settings.Default.DeleteFiles = checkAutoDelete.Checked ? "Delete" : "Keep";
            Properties.Settings.Default.PrinterName = labelSelectedPrinter.Text;
            Properties.Settings.Default.Save();
            return DialogResult.OK;
        }

        private void SettingsForm_Load(object sender, EventArgs e) {
            Revert();
        }

        private void buttonFormSave_Click(object sender, EventArgs e) {
            DialogResult = SaveAndClose();
            Close();
        }

        private void buttonFormCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonChangePrinter_Click(object sender, EventArgs e) {
            using (PrintDialog pdialog = new PrintDialog()
            {
                AllowCurrentPage = false,
                AllowPrintToFile = false,
                AllowSomePages = false,                
            }) {
                var printResult = pdialog.ShowDialog();
                if (printResult == DialogResult.OK) {
                    labelSelectedPrinter.Text = pdialog.PrinterSettings.PrinterName;
                }
            }
        }

        private void linkReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Properties.Settings.Default.Reset();
            Revert();
        }

        private void linkClearPrinter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            labelSelectedPrinter.Text = String.Empty;
        }
    }
}
