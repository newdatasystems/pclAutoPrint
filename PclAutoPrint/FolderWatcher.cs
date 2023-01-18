using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PclAutoPrint {
    internal class FolderWatcher {

        public bool IsWatching {  get { return _watcher != null; } }
        public string Folder { get { return _watcher == null ? String.Empty : _watcher.Path; } }

        private FileSystemWatcher _watcher;
        private ConcurrentDictionary<string, string> _watchedFiles = new ConcurrentDictionary<string, string>();

        public void WatchFolder (string path) {
            if (String.IsNullOrWhiteSpace(path))
                throw new InvalidOperationException("Path to monitor cannot be empty.");

            _watcher = new FileSystemWatcher();
            _watcher.Path = path;
            _watcher.NotifyFilter = NotifyFilters.LastWrite;
            _watcher.Filter = "*.cats-pcl";
            _watcher.Changed += Watcher_Changed;
            _watcher.EnableRaisingEvents = true;
        }

        public void StopWatching () {
            if (_watcher != null) {
                _watcher.Changed -= Watcher_Changed;
                _watcher.Dispose();
            }
            _watcher = null;
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e) {
            if (!_watchedFiles.TryAdd(e.FullPath, e.Name))
                return;
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
                    Arguments = String.Format("\"{0}\"",e.FullPath),
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(info);
            });
        }

        public void Dispose () {
            this.StopWatching();
        }
    }
}
