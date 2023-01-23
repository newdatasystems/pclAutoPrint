using System;

namespace PclAutoPrintDevStub {
    internal static class DevStub {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            PclAutoPrint.Program.Main(args);
        }
    }
}
