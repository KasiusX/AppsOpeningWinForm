using OpeningDifferentApps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeningDifferentApps
{
    internal class LayoutOpening
    {
        private AppsPosition appsPosition;

        public LayoutOpening()
        {
            appsPosition = new AppsPosition();
        }

        public void LoadLayout(LoadLayoutRequest request)
        {
            if (request.OnlyThisLayout)
                ProcessManager.CloseAllVisibleProcesses(GetAppsNames(request.Layout.Apps));

            foreach (AppModel app in request.Layout.Apps)
            {
                if (!request.OnlyClosedApps || !ProcessManager.IsAppOpen(app))
                {                    
                        StartApp(app);                    
                }

                if (request.MoveApps)
                {
                    while (!ProcessManager.IsAppOpen(app)) { }
                    while (!appsPosition.IsAppOnCorrectPosition(app))
                    {
                        appsPosition.SetAppPosition(app);
                    }
                }
            }
        }

        private List<string> GetAppsNames(List<AppModel> apps)
        {
            List<string> output = new List<string>();
            foreach (AppModel app in apps)
            {
                output.Add(app.Name);
            }
            return output;
        }


        private void StartApp(AppModel app)
        {
            try
            {
                Process.Start(app.FilePath);
            }
            catch(Win32Exception e)
            {
                throw new Win32Exception($"{app.Name}({e.Message})");
            }
        }
    }
}
