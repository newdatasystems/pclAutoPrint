using System;
using System.Collections.Generic;
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
            FilePrinter printer = new FilePrinter() { FileName = fileName, FileStatus = alwaysKeepFile ? AfterPrintFileOperation.Keep : AfterPrintFileOperation.Prompt };
            printer.Print();
        }

        internal enum AfterPrintFileOperation {
            Keep,
            Delete,
            Prompt
        }
    }

}
