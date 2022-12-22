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

            if (args.Length > 0) {
                foreach (string arg in args) FilePrinter.PrintOneFile(arg);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var ddForm = new DragAndDropForm();
            ddForm.ShowDialog();
            return;

        }

    }
}
