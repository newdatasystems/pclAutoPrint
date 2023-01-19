using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PclAutoPrint {
    internal class AppVersion {

        public static Version GetVersion () {
            if (ApplicationDeployment.IsNetworkDeployed)
                return ApplicationDeployment.CurrentDeployment.CurrentVersion;
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        }

        public static string GetVersionString () {
            return GetVersion().ToString();
        }
    }
}
