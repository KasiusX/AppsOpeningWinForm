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
            string[] appsData;
            if (File.Exists(path))
            {
                try
                {
                    appsData = File.ReadAllLines(path);
                }
                catch (IOException)
                {
                    throw new Exception("Close data files.");
                }
            }
            else
                return new List<AppModel>();

            return appsData.ConvertAppsOnModels();
        }

        private static void SaveAppModels(List<AppModel> apps)
        {
            string path = FileExtensions.GetRootFile().GetAppModelsFile();
            apps.CorrectAppsIds();
            List<string> appData = apps.ConvertAppsOnStrings();

            try
            {
                using (StreamWriter writter = new StreamWriter(path))
                {
                    foreach (string data in appData)
                    {
                        writter.WriteLine(data);
                    }
                }
            }
            catch (IOException)
            {
                throw new Exception("Close data files.");
            }
        }
        public static List<LayoutModel> LoadLayoutModels()
        {
            string path = FileExtensions.GetRootFile().GetLayoutsModelsFiles();
            string[] layoutData;
            if (File.Exists(path))
            {
                try
                {
                    layoutData = File.ReadAllLines(path);
                }
                catch(IOException)
                {
                    throw new Exception("Close data files.");
                }
            }
            else
                return new List<LayoutModel>();

            return layoutData.ConvertLayoutsOnModels(LoadAppModels());
        }

        private static void SaveLayoutModels(this List<LayoutModel> layouts)
        {
            string path = FileExtensions.GetRootFile().GetLayoutsModelsFiles();
            layouts.CorrectLayoutIds();

            List<AppModel> allApps = new List<AppModel>();
            foreach (LayoutModel layout in layouts)
            {
                allApps = allApps.Concat(layout.Apps).ToList();
            }
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
                throw new Exception("Close data files");
            }
        }        

        public static void SaveLayoutModel(LayoutModel layout)
        {
            List<LayoutModel> allLayouts = LoadLayoutModels();
            allLayouts.Add(layout);
            allLayouts.SaveLayoutModels();
        }

        public static void DeleteLayoutModel(LayoutModel layout)
        {            
            List<LayoutModel> layouts = LoadLayoutModels();
            LayoutModel layoutToDelete = layouts.Where(x => x.Id == layout.Id).First();
            layouts.Remove(layoutToDelete);
            layouts.SaveLayoutModels();
        }

        public static void EditLayoutModel(LayoutModel editedLayout)
        {
            List<LayoutModel> layouts = LoadLayoutModels();
            LayoutModel layoutToDelete = layouts.Where(x => x.Id == editedLayout.Id).First();
            layouts.Remove(layoutToDelete);
            layouts.Add(editedLayout);
            layouts.SaveLayoutModels();
        }
    }
}
