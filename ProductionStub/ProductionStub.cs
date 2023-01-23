using System;

namespace PclAutoPrintProductionStub {
    internal static class ProductionStub {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            PclAutoPrint.Program.Main(args);
        }
    }
}
