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
            bool isValidated = validations.ValidateLayout(name, apps);
            if (isValidated)
            {
                LayoutModel layout = new LayoutModel
                {
                    Name = name,
                    Apps = apps
                };
                FilesWriter.SaveLayoutModel(layout);

            }
            return isValidated;
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
