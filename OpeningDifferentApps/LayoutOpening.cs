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
        public async Task<string> LoadLayout(LoadLayoutRequest request)
        {
            Console.WriteLine("__________________");
            Console.WriteLine($"New layout loading({request.Layout.Name})");            

            if (request.OnlyThisLayout)
                ProcessManager.CloseAllVisibleProcesses(GetAppsNames(request.Layout.Apps));

            List<Task> layoutTasks = new List<Task>();
            foreach (AppModel app in request.Layout.Apps)
            {
                layoutTasks.Add(Task.Run(() => LoadApp(request, app)));
            }

            await Task.WhenAll(layoutTasks);            
            return "All done";
        }

        private bool LoadApp(LoadLayoutRequest request, AppModel app)
        {
            if (!request.OnlyClosedApps || !ProcessManager.IsAppOpen(app))
            {                
                StartApp(app);                
            }            
            if(IsPositionZero(app))
            {
                app.Position = AppsPosition.GetAppPosition(app.Name);
                FilesWriter.EditAppModel(app);
            }
            if (request.MoveApps && !AppsPosition.IsAppOnCorrectPosition(app))
            {
                AppsPosition.SetAppPosition(app);
            }
            AppsPosition.BringWindowForward(app);           
            return true;
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
                Console.WriteLine($"starting{app.Name}");
                Process.Start(app.FilePath);
                while (!ProcessManager.IsAppOpen(app)){}
                Console.WriteLine($"{app.Name} started");

            }
            catch (Win32Exception e)
            {
                throw new Win32Exception($"{app.Name}({e.Message})");
            }
        }

        private bool IsPositionZero(AppModel app)
        {

            return app.Position.Left == 0 && app.Position.Right == 0 && app.Position.Top == 0 && app.Position.Bottom == 0;
        }
    }
}
