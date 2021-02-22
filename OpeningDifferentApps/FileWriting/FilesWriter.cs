using OpeningDifferentApps.Models;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeningDifferentApps
{
    internal static class FilesWriter
    {       

        public static List<AppModel> LoadAppModels()
        {
            string path = FileExtensions.GetRootFile().GetAppModelsFile();
            if (File.Exists(path))
            {
                try
                {
                    return File.ReadAllLines(path).ConvertStringOnAppModels();
                }
                catch (IOException)
                {
                    throw new IOException("Close data files.");
                }
            }
            else
                return new List<AppModel>();
        }

        private static void SaveAppModels(List<AppModel> apps)
        {
            string path = FileExtensions.GetRootFile().GetAppModelsFile();
            apps.CorrectAppsIds();
            List<string> appData = apps.ConvertAppsOnStrings();

            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (string data in appData)
                    {
                        writer.WriteLine(data);
                    }                    
                }
            }
            catch (IOException)
            {
                throw new IOException("Close data files.");
            }
        }

        public static void EditAppModel(AppModel app)
        {
            string path = FileExtensions.GetRootFile().GetAppModelsFile();
            List<AppModel> apps = LoadAppModels();
            apps = apps.Where(x => x.Id != app.Id).ToList();
            apps.Add(app);
            SaveAppModels(apps);
        }

        public static List<LayoutModel> LoadLayoutModels()
        {
            string path = FileExtensions.GetRootFile().GetLayoutsModelsFiles();
            if (File.Exists(path))
            {
                try
                {
                    return File.ReadAllLines(path).ConvertStringOnLayoutModels(LoadAppModels());
                }
                catch(IOException)
                {
                    throw new IOException("Close data files.");
                }
            }
            else
                return new List<LayoutModel>();
        }

        private static void SaveLayoutModels(this List<LayoutModel> layouts)
        {
            string path = FileExtensions.GetRootFile().GetLayoutsModelsFiles();
            layouts.CorrectLayoutIds();

            List<AppModel> allApps = GetAllApps(layouts);            
            SaveAppModels(allApps);

            List<string> layoutData = layouts.ConvertLayoutsOnStrings();
            try
            {
                using (StreamWriter writter = new StreamWriter(path))
                {
                    foreach (string data in layoutData)
                    {
                        writter.WriteLine(data);
                    }
                }
            }
            catch(IOException)
            {
                throw new IOException("Close data files");
            }
        }        

        private static List<AppModel> GetAllApps(List<LayoutModel> layouts)
        {
            List<AppModel> allApps = new List<AppModel>();
            foreach (LayoutModel layout in layouts)
            {
                allApps = allApps.Concat(layout.Apps).ToList();
            }
            return allApps;
        }

        public static void SaveLayoutModel(LayoutModel layout) => LoadLayoutModels().Concat(new List<LayoutModel> { layout }).ToList().SaveLayoutModels();           
        public static void DeleteLayoutModel(LayoutModel layout) => LoadLayoutModels().Where(x => x.Id != layout.Id).ToList().SaveLayoutModels();

        public static void EditLayoutModel(LayoutModel editedLayout)
        {
            List<LayoutModel> layouts = new List<LayoutModel>();
            layouts = LoadLayoutModels().Where(x => x.Id != editedLayout.Id).ToList();
            layouts.Add(editedLayout);
            layouts.SaveLayoutModels();
        }        
    }
}
