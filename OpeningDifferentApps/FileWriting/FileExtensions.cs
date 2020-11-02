using Microsoft.SqlServer.Server;
using OpeningDifferentApps.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace OpeningDifferentApps
{
    internal static class FileExtensions
    {
        private static string rootFolder = Environment.SpecialFolder.CommonApplicationData + @"\LayoutData\";
        private static string appModelsFile = "AppModels.csv";
        private static string layoutsModelsFiles = "LayoutModels.csv";

        public static string GetRootFile()
        {
            if (!Directory.Exists(rootFolder))
                Directory.CreateDirectory(rootFolder);                
            return rootFolder;
        }

        public static string GetAppModelsFile(this string root)
        {
            return root + appModelsFile;
        }
        public static string GetLayoutsModelsFiles(this string root)
        {
            return root + layoutsModelsFiles;
        }

        public static List<AppModel> ConvertAppsOnModels(this string[] appsData)
        {
            List<AppModel> output = new List<AppModel>();
            foreach (string row in appsData)
            {
                string[] data = row.Split(',');
                AppModel model = new AppModel
                {
                    Id = Convert.ToInt32(data[0]),
                    Name = data[1],
                    FilePath = data[2]
                };
                output.Add(model);
            }
            return output;
        }
        public static List<string> ConvertAppsOnStrings(this List<AppModel> appModels)
        {
            List<string> output = new List<string>();
            foreach (AppModel app in appModels)
            {
                output.Add($"{app.Id},{app.Name},{app.FilePath}");
            }
            return output;
        }
        
        public static List<AppModel> CorrectAppsIds(this List<AppModel> appModels)
        {
            appModels = appModels.OrderBy(x => x.Id).ToList();
            int id = appModels.Count == 0 ? 1: appModels.Last().Id + 1;
            foreach (AppModel app in appModels)
            {
                if (app.Id == 0)
                {
                    app.Id = id;
                    id++;
                }
            }
            return appModels;
        }

        public static List<LayoutModel> ConvertLayoutsOnModels(this string[] layoutsData,List<AppModel> allApps)
        {
            List<LayoutModel> output = new List<LayoutModel>();
            foreach (string row in layoutsData)
            {
                string[] data = row.Split(',');
                string[] appIds = data[2].Split('|');
                LayoutModel model = new LayoutModel
                {
                    Id = Convert.ToInt32(data[0]),
                    Name = data[1],
                    Apps = allApps.Where(x => appIds.Contains(x.Id.ToString())).ToList()
                };
                output.Add(model);
            }
            return output;
        }
        public static List<string> ConvertLayoutsOnStrings(this List<LayoutModel> layoutModels)
        {
            List<string> output = new List<string>();
            foreach (LayoutModel layout in layoutModels)
            {
                string appIds = "";
                foreach (AppModel app in layout.Apps)
                {
                    appIds += $"{app.Id}|";
                }
                appIds = appIds.Remove(appIds.Length - 1);
                output.Add($"{layout.Id},{layout.Name},{appIds}");
            }
            return output;
        }        

        public static List<LayoutModel> CorrectLayoutIds(this List<LayoutModel> layoutModels)
        {
            layoutModels = layoutModels.OrderBy(x => x.Id).ToList();
            int id = layoutModels.Count == 0 ? 1 : layoutModels.Last().Id + 1;
            foreach (LayoutModel app in layoutModels)
            {
                if (app.Id == 0)
                {
                    app.Id = id;
                    id++;
                }
            }
            return layoutModels;
        }
        
    }
}
