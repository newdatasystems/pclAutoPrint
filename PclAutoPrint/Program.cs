using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PclAutoPrint {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            if (args.Length == 0 || String.IsNullOrEmpty(args[0]))
                return;

            //if (!System.IO.File.Exists(args[0]))
            //    return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (PrintDialog pdialog = new PrintDialog()
            {
                AllowCurrentPage = false,
                AllowPrintToFile = false,
                AllowSomePages = false
            }) {
                var printResult = pdialog.ShowDialog();
                if (printResult == DialogResult.OK) {
                    try {
                        RawFilePrint.SendFileToPrinter(pdialog.PrinterSettings.PrinterName, args[0]);
                    } catch (Exception ex) {
                        MessageBox.Show(String.Format("Printing failed:\n{0}",ex.ToString()),"Printing Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }

            var deleteResult = MessageBox.Show(String.Format("Delete source file {0}?", args[0]), "Printing Finished", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deleteResult == DialogResult.Yes) {
                try {
                    System.IO.File.Delete(args[0]);
                } catch (Exception ex) {
                    MessageBox.Show(String.Format("Could not delete file:\n{0}",ex.Message), "Delete File Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


    }
}
