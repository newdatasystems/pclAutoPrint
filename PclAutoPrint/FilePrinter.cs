using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PclAutoPrint {
    internal class FilePrinter {

        public string FileName { get; set; }
        public string PrinterName { get; set; }
        public int Copies { get; set; } = 1;
        public AfterPrintFileOperation FileStatus { get; set; }

        public void Print() {
            if (String.IsNullOrEmpty(FileName))
                return;

            if (!System.IO.File.Exists(FileName))
                return;

            if (String.IsNullOrEmpty(PrinterName))
                if (!PromptForPrinter())
                    return;

            for (int i = 0; i < Copies; i++) {
                RawFilePrint.SendFileToPrinter(PrinterName, FileName);
            }

            bool deleteFile = (FileStatus == AfterPrintFileOperation.Delete);

            if (FileStatus == AfterPrintFileOperation.Prompt) {
                var deleteResult = MessageBox.Show(String.Format("Delete source file {0}?", FileName), "Printing Finished", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                deleteFile = deleteResult == DialogResult.Yes;
            }

            if (deleteFile) {
                try {
                    System.IO.File.Delete(FileName);
                }
                catch (Exception ex) {
                    MessageBox.Show(String.Format("Could not delete file:\n{0}", ex.Message), "Delete File Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public bool PromptForPrinter () {
            using (PrintDialog pdialog = new PrintDialog()
            {
                AllowCurrentPage = false,
                AllowPrintToFile = false,
                AllowSomePages = false
            }) {
                var printResult = pdialog.ShowDialog();
                if (printResult == DialogResult.OK) {
                    PrinterName = pdialog.PrinterSettings.PrinterName;
                    return true;
                }
            }
            return false;
        }

        public static void PrintOneFile(string fileName, int copies = 1, bool alwaysKeepFile = false) {
            PrintOneFile(fileName, copies, alwaysKeepFile ? AfterPrintFileOperation.Keep : AfterPrintFileOperation.Prompt);
        }

        public static void PrintOneFile(string fileName, int copies, AfterPrintFileOperation operation) {
            if (Properties.Settings.Default.DelaySeconds > 0) {
                string printerName = String.Empty;
                if (String.Equals(Properties.Settings.Default.PrinterSelection, "Default")) {
                    printerName = GetDefaultPrinterName();
                } else if (String.Equals(Properties.Settings.Default.PrinterSelection, "Select")) {
                    printerName = Properties.Settings.Default.PrinterName;
                }
                PrintWithNotification(fileName, copies, operation, printerName, Properties.Settings.Default.DelaySeconds);
            }
            else {
                FilePrinter printer = new FilePrinter() { FileName = fileName, FileStatus = operation, Copies = copies };
                printer.Print();
            }
        }

        private static void PrintWithNotification(string fileName, int copies, AfterPrintFileOperation operation, string printerName, int delayForSeconds) {
            var notifier = new PrintNotification() { FileName = fileName, PrinterName = printerName, Operation = operation, Copies = copies, DelaySeconds = delayForSeconds };
            notifier.ShowDialog();
        }

        internal static string GetDefaultPrinterName () {
            var printSettings = new PrinterSettings();
            return printSettings.PrinterName;
        }

        internal enum AfterPrintFileOperation {
            Keep,
            Delete,
            Prompt
        }

        internal static string OperationToString (AfterPrintFileOperation op) {
            switch (op) {
                case AfterPrintFileOperation.Keep:
                    return "Keep";
                case AfterPrintFileOperation.Delete:
                    return "Delete";
                default:
                    return "Prompt";
            }
        }
        internal static AfterPrintFileOperation StringToOperation (string setting) {
            if (String.Equals(setting, "Delete"))
                return AfterPrintFileOperation.Delete;
            if (String.Equals(setting, "Keep"))
                return AfterPrintFileOperation.Keep;
            return AfterPrintFileOperation.Prompt;
        }

        internal static void PrintWithArgs(string[] args) {
            var options = StartupOptions.ParseArgs(args);

            FilePrinter fp = new FilePrinter();
            if (options.KeepFile) {
                fp.FileStatus = AfterPrintFileOperation.Keep;
            } else if (options.PromptFile) {
                fp.FileStatus = AfterPrintFileOperation.Prompt;
            } else {
                fp.FileStatus = AfterPrintFileOperation.Delete;
            }
            if (!String.IsNullOrEmpty(options.PrinterName)) {
                fp.PrinterName = options.PrinterName;
            } else {
                if (options.DefaultPrinter) {
                    fp.PrinterName = GetDefaultPrinterName();
                } else if (options.NoPrinter) {
                    fp.PrinterName = String.Empty;
                } else {
                    fp.PrinterName = Properties.Settings.Default.PrinterName;
                }
            }
            fp.Copies = options.CopyCount;
            int delaySeconds = options.DelaySeconds >= 0 ? options.DelaySeconds : Properties.Settings.Default.DelaySeconds;
            foreach (var item in options.FileList) {
                if (delaySeconds > 0) {
                    PrintWithNotification(item, fp.Copies, fp.FileStatus, fp.PrinterName, delaySeconds);
                } else {
                    fp.FileName = item;
                    fp.Print();
                }
            }
        }
    }

}
