using System;
using System.Collections.Generic;
using System.Threading;

namespace PclAutoPrint {
    internal class StartupOptions {

        public int CopyCount { get; set; } = 1;

        public int DelaySeconds { get; set; } = -1;

        public string PrinterName { get; set; } = string.Empty;

        public bool DefaultPrinter { get; set; } = false;

        public bool NoPrinter { get; set; } = false;

        public bool StandardPrinter { get; set; } = true;

        public List<string> FileList { get; set; } = new List<string>();
        public bool KeepFile { get; internal set; } = false;
        public bool PromptFile { get; internal set; } = false;
        public bool DeleteFile { get; internal set; } = true;

        public static StartupOptions ParseArgs(string[] args) {
            var opts = new StartupOptions();
            for (int i = 0; i < args.Length; i++) {
                if (args[i].StartsWith("-")) {
                    if (args.Length > i + 1) {
                        // specify the number of copies of each file to print
                        if (args[i].Equals("-c")) {
                            int count = 1;
                            if (Int32.TryParse(args[i + 1], out count))
                                opts.CopyCount = count;
                            continue;
                        }
                        // specify the printer to user
                        if (args[i].Equals("-p")) {
                            opts.PrinterName = args[i + 1];
                            continue;
                        }
                        // specify the delay before printing (in seconds)
                        if (args[i].Equals("-d")) {
                            int delay = -1;
                            if (Int32.TryParse(args[i + 1], out delay))
                                opts.DelaySeconds = delay;
                            continue;
                        } 
                    }
                    if (args[i].Equals("-standard")) {
                        opts.StandardPrinter = true;
                        continue;
                    }
                    if (args[i].Equals("-default")) {
                        opts.DefaultPrinter = true;
                        continue;
                    }
                    if (args[i].Equals("-noprinter")) {
                        opts.NoPrinter = true;
                        continue;
                    }
                    if (args[i].Equals("-keep")) {
                        opts.KeepFile = true;
                        continue;
                    }
                    if (args[i].Equals("-prompt")) {
                        opts.PromptFile = true;
                        continue;
                    }
                    if (args[i].Equals("-delete")) {
                        opts.DeleteFile = true;
                        continue;
                    }

                    continue;
                }
                opts.FileList.Add(args[i]);
            }
            return opts;
        }
    }
}
