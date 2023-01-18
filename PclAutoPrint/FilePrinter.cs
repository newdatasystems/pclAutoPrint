﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PclAutoPrint {
    internal class FilePrinter {

        public string FileName { get; set; }
        public string PrinterName { get; set; }

        public AfterPrintFileOperation FileStatus { get; set; }

        public void Print() {
            if (String.IsNullOrEmpty(FileName))
                return;

            if (!System.IO.File.Exists(FileName))
                return;

            if (String.IsNullOrEmpty(PrinterName))
                if (!PromptForPrinter())
                    return;

            RawFilePrint.SendFileToPrinter(PrinterName, FileName);

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

        public static void PrintOneFile(string fileName, bool alwaysKeepFile = false) {
            PrintOneFile(fileName, alwaysKeepFile ? AfterPrintFileOperation.Keep : AfterPrintFileOperation.Prompt);
        }

        public static void PrintOneFile(string fileName, AfterPrintFileOperation operation) {
            if (Properties.Settings.Default.DelaySeconds > 0) {
                string printerName = String.Empty;
                if (String.Equals(Properties.Settings.Default.PrinterSelection,"Default")) {
                    var printSettings = new PrinterSettings();
                    printerName = printSettings.PrinterName;
                } else if (String.Equals(Properties.Settings.Default.PrinterSelection,"Select")) {
                    printerName = Properties.Settings.Default.PrinterName;
                }
                var notifier = new PrintNotification() { FileName = fileName, PrinterName = printerName, Operation = operation };
                notifier.ShowDialog();
            } else {
                FilePrinter printer = new FilePrinter() { FileName = fileName, FileStatus = operation };
                printer.Print();
            }
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
    }

}
