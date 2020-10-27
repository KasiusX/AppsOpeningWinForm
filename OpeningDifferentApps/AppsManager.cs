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
        public List<AppModel> GetVisibleProcesses()
        {
            return ProcessManager.GetVisibleProcesses().ConvertProceessOnAppModel();
        }    
        
        public List<LayoutModel> GetLayoutModels()
        {
            return FilesWriter.LoadLayoutModels();
        }

        public void CreateNewLayoutModels(List<LayoutModel> layouts)
        {
            layouts.SaveLayoutModels();
        }

        public void LoadLayoutModel(LayoutModel layout, bool onlyClosed)
        {
            ProcessManager.LoadLayout(layout, onlyClosed);
        }
    }
}
