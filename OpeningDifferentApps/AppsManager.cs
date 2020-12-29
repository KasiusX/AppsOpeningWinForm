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
        private AppsPosition appsPosition = new AppsPosition();
        private LayoutOpening layoutOpening = new LayoutOpening();

        public List<AppModel> GetVisibleProcesses()
        {
            return ProcessManager.GetVisibleProcesses().ConvertProceessOnAppModel();
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
                LayoutModel layout = PrepareLayoutModel(name, apps);
                FilesWriter.SaveLayoutModel(layout);
            }
            return isValid;
        }

        public bool EditLayoutModel(string name, List<AppModel> apps, int id)
        {
            bool isValid = validation.ValidateLayout(name, apps);
            if (isValid)
            {
                LayoutModel layout = PrepareLayoutModel(name, apps, id);
                FilesWriter.EditLayoutModel(layout);
            }
            return isValid;
        }

        public LayoutModel PrepareLayoutModel(string name, List<AppModel> apps, int id = 0)
        {
            foreach (AppModel app in apps)
            {
                app.Position = appsPosition.GetAppPosition(app.Name);
            }
            return new LayoutModel
            {
                Name = name,
                Apps = apps,
                Id = id
            };
            
        }

        public void LoadLayoutModel(LayoutModel layout, bool onlyClosed)
        {
            layoutOpening.LoadLayout(layout, onlyClosed);
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
