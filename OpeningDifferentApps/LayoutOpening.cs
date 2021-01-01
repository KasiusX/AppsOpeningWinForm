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

        public void LoadLayout(LayoutModel layout, bool onlyClosed)
        {            
            if (!onlyClosed)
            {
                foreach (AppModel app in layout.Apps)
                {
                    StartApp(app);
                }
            }
            else
            {
                foreach (AppModel app in layout.Apps)
                {
                    if (!IsAppOpen(app))
                    {
                        StartApp(app);
                    }
                }
            }
        }

        private void StartApp(AppModel app)
        {
            try
            {
                Process.Start(app.FilePath);
                while(ProcessManager.GetVisibleProcesses().Where(x=> x.ProcessName ==app.Name).ToList().Count == 0) { }
                appsPosition.SetAppPosition(app);
            }
            catch(Win32Exception e)
            {
                throw new Win32Exception($"{app.Name}({e.Message})");
            }
        }

        private bool IsAppOpen(AppModel app)
        {
            List<Process> visibleProccesses = ProcessManager.GetVisibleProcesses();
            return visibleProccesses.Where(x => x.ProcessName == app.Name).ToList().Count == 0 ?  false: true;            
        }
    }
}
