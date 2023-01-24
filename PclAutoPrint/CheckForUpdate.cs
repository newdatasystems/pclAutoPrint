using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PclAutoPrint {
    public class CheckForUpdate {

        public static bool IsUpdateAvailable(out Version version, bool quiet = false) {
            version = null;

            var info = GetUpdateInfo(quiet);
            if (info == null)
                return false;

            version = info.AvailableVersion;
            return info.UpdateAvailable;
        }

        public static void UpdateApp () {
            if (!ApplicationDeployment.IsNetworkDeployed)
                return;

            ApplicationDeployment.CurrentDeployment.Update();
            Application.Restart();
        }

        private static UpdateCheckInfo GetUpdateInfo (bool quiet = false) {
            if (!ApplicationDeployment.IsNetworkDeployed)
                return null;

            UpdateCheckInfo info = null;
            ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

            try {
                info = ad.CheckForDetailedUpdate();
            } catch (DeploymentDownloadException dde) {
                if (!quiet)
                    MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                return null;
            } catch (InvalidDeploymentException ide) {
                if (!quiet)
                    MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
                return null;
            } catch (InvalidOperationException ioe) {
                if (!quiet)
                    MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
                return null;
            }
            return info;
        }

        public static void InstallUpdateSyncWithInfo() {
            UpdateCheckInfo info = GetUpdateInfo();

            if (info!= null && info.UpdateAvailable) {
                Boolean doUpdate = true;

                if (!info.IsUpdateRequired) {
                    DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
                    if (!(DialogResult.OK == dr)) {
                        doUpdate = false;
                    }
                } else {
                    // Display a message that the app MUST reboot. Display the minimum required version.
                    MessageBox.Show("This application has detected a mandatory update from your current " +
                        "version to version " + info.MinimumRequiredVersion.ToString() +
                        ". The application will now install the update and restart.",
                        "Update Available", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                if (doUpdate) {
                    DoUpdate();
                }
            }
        }

        public static bool DoUpdate () {
            try {
                ApplicationDeployment.CurrentDeployment.Update();
                MessageBox.Show($"The application has been updated to v{ApplicationDeployment.CurrentDeployment.UpdatedVersion}, and will now restart.");
                Application.Restart();
            } catch (DeploymentDownloadException dde) {
                MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
                return false;
            }
            return true;

        }
    }
}
