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
        Validations validations;
        public AppsManager()
        {
            validations = new Validations();
        }
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
            bool isValid = validations.ValidateLayout(name, apps);
            if (isValid)
            {
                LayoutModel layout = new LayoutModel
                {
                    Name = name,
                    Apps = apps
                };
                FilesWriter.SaveLayoutModel(layout);

            }
            return isValid;
        }

        public bool EditLayoutModel(string name, List<AppModel> apps, int id)
        {
            bool isValid = validations.ValidateLayout(name, apps);
            if (isValid)
            {
                LayoutModel layout = new LayoutModel
                {
                    Name = name,
                    Apps = apps,
                    Id = id
                };
                FilesWriter.EditLayoutModel(layout);
            }
            return isValid;
        }

        public void LoadLayoutModel(LayoutModel layout, bool onlyClosed)
        {
            ProcessManager.LoadLayout(layout, onlyClosed);
        }

        public void DeleteLayoutModel(LayoutModel layout)
        {
            FilesWriter.DeleteLayoutModel(layout);
        }
    }
}
