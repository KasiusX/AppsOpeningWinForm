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
                LayoutModel layout = CreateLayout(name, apps);
                FilesWriter.SaveLayoutModel(layout);
            }
            return isValid;
        }

        public bool EditLayoutModel(string name, List<AppModel> apps, int id, LayoutModel layoutToEdit)
        {
            bool isValid = validation.ValidateLayout(name, apps);
            if (isValid)
            {
                LayoutModel layout = CreateLayout(name, apps, layoutToEdit, id);
                FilesWriter.EditLayoutModel(layout);
            }
            return isValid;
        }

        public LayoutModel CreateLayout(string name, List<AppModel> apps, LayoutModel layoutToEdit = null, int id = 0)
        {
            foreach (AppModel app in apps)
            {
                try
                {
                    app.Position = appsPosition.GetAppPosition(app.Name);
                }
                catch(Exception e)
                {
                    if (e.Message == "Sequence contain no elements")
                        app.Position = layoutToEdit.Apps.Where(x => x.Name == app.Name).First().Position;
                }
            }
            return new LayoutModel
            {
                Name = name,
                Apps = apps,
                Id = id
            };
            
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
