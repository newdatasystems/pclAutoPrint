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

            // if arguments are passed on the command line then we process the files and exit
            if (args.Length > 0) {
                foreach (string arg in args) FilePrinter.PrintOneFile(arg);
                return;
            }

            // click-once doesn't pass arguments on the command line
            if (AppDomain.CurrentDomain.SetupInformation.ActivationArguments != null && 
                    AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData != null && 
                    AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData.Length > 0) {
                foreach (string commandLineFile in AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData) {
                    MessageBox.Show(string.Format("Command Line File: {0}", commandLineFile));
                }
                return;
            }

            // otherwise display the drag-and-drop form so users can manually send files to the printer
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var ddForm = new DragAndDropForm();
            ddForm.ShowDialog();
            return;

        }

    }
}
