using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PclAutoPrint {
    internal class FolderWatcher {

        public string Folder { get; set; }

        private FileSystemWatcher watcher;

        public void WatchFolder (string path) {
            if (String.IsNullOrWhiteSpace(path))
                throw new InvalidOperationException("Path to monitor cannot be empty.");

            watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "*.cats-pcl";
            watcher.Changed += Watcher_Changed;
            watcher.EnableRaisingEvents = true;
        }

        public void StopWatching () {
            if (watcher != null) {
                watcher.Changed -= Watcher_Changed;
                watcher.Dispose();
            }
            watcher = null;
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e) {
            ThreadPool.QueueUserWorkItem(sendToPrinter =>
            {
                for (int i = 0; i < 1200; i++) { // thread will wait up to 5 minutes for the file to unlock
                    // If the file can be opened for exclusive access it means that the file
                    // is no longer locked by another process.
                    try {
                        using (FileStream inputStream = File.Open(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.None))
                            if (inputStream.Length > 0)
                                break;
                    }
                    catch (Exception) {
                    }
                    Thread.Sleep(250);
                }
                var info = new System.Diagnostics.ProcessStartInfo(Application.ExecutablePath)
                {
                    Arguments = e.FullPath
                };
                System.Diagnostics.Process.Start(info);
            });
        }

        public void Dispose () {
            this.StopWatching();
        }
    }
}
