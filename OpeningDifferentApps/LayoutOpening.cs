using OpeningDifferentApps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

        public async Task<string> LoadLayout(LoadLayoutRequest request)
        {
            if (request.OnlyThisLayout)
                ProcessManager.CloseAllVisibleProcesses(GetAppsNames(request.Layout.Apps));
            Console.WriteLine("__________________");
            Console.WriteLine($"New layout loading({request.Layout.Name})");
            List<Task> layoutTasks = new List<Task>();

            foreach (AppModel app in request.Layout.Apps)
            {
                Console.WriteLine($"adding {app.Name}");
                Task<AppModel> task = LoadAppAsync(request, app);
                layoutTasks.Add(task);
                Console.WriteLine($"{app.Name} added");
            }

            while(layoutTasks.Count != 0)
            {
                Task finishedTask = await Task.WhenAny(layoutTasks);
                layoutTasks.Remove(finishedTask);
            }
            return "All done";
        }

        private async Task<AppModel> LoadAppAsync(LoadLayoutRequest request, AppModel app)
        {
            if (!request.OnlyClosedApps || !ProcessManager.IsAppOpen(app))
            {
                Console.WriteLine($"starting{app.Name}");
                await StartApp(app);
                Console.WriteLine($"{app.Name} started");
            }
            Rect rec = appsPosition.GetAppPosition(app.Name);

            if (request.MoveApps && !app.Position.Equals(appsPosition.GetAppPosition(app.Name)))
            {
                Console.WriteLine($"Setting position of {app.Name}");
                await appsPosition.SetAppPosition(app);
                Console.WriteLine($"position of {app.Name} set");
            }
            else
            {
                appsPosition.ShowWindow(app);
            }
            return app;
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


        private async Task<AppModel> StartApp(AppModel app)
        {
            try
            {
                Process.Start(app.FilePath);
                await Task.Delay(0);                
                while (!ProcessManager.IsAppOpen(app)) { }
                return app;
            }
            catch (Win32Exception e)
            {
                throw new Win32Exception($"{app.Name}({e.Message})");
            }
        }
    }
}
