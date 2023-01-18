using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PclAutoPrint {
    public partial class PrintNotification : Form {
        string caption = "PCL Print Notification";
        public string PrinterName { get; set; }
        public string FileName { get; set; }

        internal FilePrinter.AfterPrintFileOperation Operation { get; set; }

        DateTime expiration = DateTime.MinValue;
        double remainingMilliseconds = 0;
        bool countdownHalted = false;

        public PrintNotification() {
            InitializeComponent();
        }

        private void StartCountdown() {
            timerCountdown.Interval = 100;
            timer1.Interval = (int)remainingMilliseconds;
            expiration = DateTime.Now.AddMilliseconds(timer1.Interval);
            timer1.Enabled = true;
            timerCountdown.Enabled = true;
            UpdateDisplay();
        }

        private void HaltCountdown() {
            StopCountdown(true);
        }

        private void StopCountdown(bool halt = false) {
            timer1.Enabled = false;
            timerCountdown.Enabled = false;
            countdownHalted = halt;
            UpdateDisplay();
        }

        private void SendFileToPrinter() {
            HaltCountdown();
            Text = caption + " Printing";
            Enabled = false;
            var fp = new FilePrinter()
            {
                PrinterName = PrinterName,
                FileName = FileName,
                FileStatus = Operation
            };
            fp.Print();
            Close();
        }

        private void timerCountdown_Tick(object sender, EventArgs e) {
            UpdateDisplay();
        }

        private void UpdateDisplay() {
            remainingMilliseconds = expiration.Subtract(DateTime.Now).TotalMilliseconds;
            double secondsLeft = Math.Round(remainingMilliseconds / 1000, 0);
            if (timer1.Enabled && secondsLeft > 0) {
                if (String.IsNullOrEmpty(PrinterName)) {
                    buttonFormCancel.Text = String.Format("Cancel ({0})", secondsLeft);
                }
                else {
                    buttonFormSave.Text = String.Format("Print ({0})", secondsLeft);
                }
                Text = caption + " Auto-Printing";
            } else {
                buttonFormSave.Text = "Print";
                buttonFormCancel.Text = "Cancel";
                Text = caption;
            }
            picturePausePlay.Visible = !countdownHalted && (remainingMilliseconds > 0);
            labelFileName.Text = FileName;
            labelPrinterName.Text = String.IsNullOrEmpty(PrinterName) ? "[No Printer Selected]" : PrinterName;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            SendFileToPrinter();
        }

        private void buttonChangePrinter_Click(object sender, EventArgs e) {
            HaltCountdown();
            using (PrintDialog pdialog = new PrintDialog()
            {
                AllowCurrentPage = false,
                AllowPrintToFile = false,
                AllowSomePages = false
            }) {
                var printResult = pdialog.ShowDialog();
                if (printResult == DialogResult.OK) {
                    PrinterName = pdialog.PrinterSettings.PrinterName;
                }
            }
            UpdateDisplay();
        }

        private void PrintNotification_Shown(object sender, EventArgs e) {
            remainingMilliseconds = Properties.Settings.Default.DelaySeconds * 1000;
            StartCountdown();
        }

        private void ResumeCountdown () {
            StartCountdown();
            picturePausePlay.Image = Properties.Resources.pause_png;
        }

        private void PauseCountdown() {
            remainingMilliseconds = expiration.Subtract(DateTime.Now).TotalMilliseconds;
            StopCountdown();
            picturePausePlay.Image = Properties.Resources.play_png;
        }

        private void picturePausePlay_Click(object sender, EventArgs e) {
            if (timer1.Enabled) {
                PauseCountdown();
            }
            else {
                ResumeCountdown();
            }
        }

        private void buttonFormSave_Click(object sender, EventArgs e) {
            SendFileToPrinter();
        }

        private void buttonFormCancel_Click(object sender, EventArgs e) {
            HaltCountdown();
            Close();
        }

        private void PrintNotification_FormClosing(object sender, FormClosingEventArgs e) {
            HaltCountdown();
        }
    }
}