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
        public static void SaveAppModels(List<AppModel> apps)
        {
            string path = FileExtensions.GetRootFile().GetAppModelsFile();
            apps.CorrectAppsIds();
            List<string> appData = apps.ConvertAppsOnStrings();

            using (StreamWriter writter = new StreamWriter(path))
            {
                foreach (string data in appData)
                {
                    writter.WriteLine(data);
                }
            }
        }

        public static List<AppModel> LoadAppModels()
        {
            string path = FileExtensions.GetRootFile().GetAppModelsFile();
            string[] appsData;
            if (File.Exists(path))
                appsData = File.ReadAllLines(path);
            else
                return new List<AppModel>();

            return appsData.ConvertAppsOnModels();
        }

        public static void SaveLayoutModels(this List<LayoutModel> layouts)
        {
            string path = FileExtensions.GetRootFile().GetLayoutsModelsFiles();
            layouts = layouts.Concat(LoadLayoutModels()).ToList();
            layouts.CorrectLayoutIds();

            List<AppModel> allApps = new List<AppModel>();
            foreach (LayoutModel layout in layouts)
            {
                allApps = allApps.Concat(layout.apps).ToList();
            }
            SaveAppModels(allApps);

            List<string> layoutData = layouts.ConvertLayoutsOnStrings();            
            using (StreamWriter writter = new StreamWriter(path))
            {
                foreach (string data in layoutData)
                {
                    writter.WriteLine(data);
                }
            }
        }

        public static List<LayoutModel> LoadLayoutModels()
        {
            string path = FileExtensions.GetRootFile().GetLayoutsModelsFiles();
            string[] layoutData;
            if (File.Exists(path))
                layoutData = File.ReadAllLines(path);
            else
                return new List<LayoutModel>();

            return layoutData.ConvertLayoutsOnModels(LoadAppModels());
        }
    }
}
