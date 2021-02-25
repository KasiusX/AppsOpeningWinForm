using OpeningDifferentApps.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeningDifferentApps
{
    public class AppsManager
    {
        private Validations validation = new Validations();        
        private LayoutOpening layoutOpening = new LayoutOpening();

        public List<ListBoxAppModel> GetVisibleApps()
        {
            return WindowsManager.GetAllWindows();
        }

        public List<LayoutModel> GetLayoutModels()
        {
            return FilesWriter.LoadLayoutModels();
        }

        public bool CreateNewLayoutModels(string name, List<AppModel> apps)
        {
            bool isValid = validation.ValidateLayout(name, apps);
            if (isValid)
            {
                FilesWriter.SaveLayoutModel(new LayoutModel
                {
                    Name = name,
                    Apps = apps
                });
            }
            return isValid;
        }

        public bool EditLayoutModel(string name, List<ListBoxAppModel> listboxApps, int id, LayoutModel layoutToEdit)
        {
            List<AppModel> apps = GetAppModels(listboxApps);
            bool isValid = validation.ValidateLayout(name, apps);
            if (isValid)
            {
                FilesWriter.EditLayoutModel(new LayoutModel
                {
                    Name = name,
                    Apps = apps,
                    Id = id
                });
            }
            return isValid;
        }

        private List<AppModel> GetAppModels(List<ListBoxAppModel> listboxApps)
        {
            List<AppModel> output = new List<AppModel>();
            foreach (var listBoxApp in listboxApps)
            {
                AppModel app = listBoxApp.App;
                app.Position = AppsPosition.GetAppPosition(listBoxApp.Window);
                output.Add(app);
            }
            return output;
        }
        public string LoadLayoutModel(LoadLayoutRequest request)
        {
            return layoutOpening.LoadLayout(request).Result;
        }

        public void DeleteLayoutModel(LayoutModel layout)
        {
            FilesWriter.DeleteLayoutModel(layout);
        }

        public void CloseAllVisibleProcesses()
        {
            ProcessManager.CloseAllVisibleProcesses();
        }


    }
}
