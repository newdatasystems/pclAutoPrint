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
                FilePrinter.PrintWithArgs(args);
                //foreach (string arg in args) FilePrinter.PrintOneFile(arg, 1, FilePrinter.StringToOperation(Properties.Settings.Default.DeleteFiles));
                return;
            }

            // click-once doesn't pass arguments on the command line
            if (AppDomain.CurrentDomain.SetupInformation.ActivationArguments != null && 
                    AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData != null && 
                    AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData.Length > 0) {
                FilePrinter.PrintWithArgs(AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData);
                //foreach (string commandLineFile in AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData) FilePrinter.PrintOneFile(commandLineFile);
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
