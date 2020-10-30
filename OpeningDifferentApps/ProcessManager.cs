﻿using OpeningDifferentApps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace OpeningDifferentApps
{
    internal static class ProcessManager
    {
        public static List<Process> GetVisibleProcesses()
        {
            List<Process> output = new List<Process>();
            foreach (Process p in Process.GetProcesses())
            {
                if (IsVisible(p))                
                    output.Add(p);                
            }
            return output;
        }
        private static bool IsVisible(Process p)
        {
            if (p.MainWindowTitle.Length >0)
                return true;
            else
                return false;
        }

        public static List<AppModel> ConvertProceessOnAppModel(this List<Process> processes)
        {
            List<AppModel> output = new List<AppModel>();
            foreach (Process p in processes)
            {
                AppModel app = new AppModel();
                try
                {
                    app.FilePath = p.MainModule.FileName;
                    app.Name = p.ProcessName;
                    output.Add(app);

                }
                catch(Win32Exception)
                {
                }
                
            }
            return output;
        }

        public static void LoadLayout(LayoutModel layout, bool onlyClosed)
        {
            List<Process> visibleProcesses = GetVisibleProcesses();
            foreach (AppModel app in layout.Apps)
            {
                if (onlyClosed)
                {
                    if (visibleProcesses.Where(x => x.ProcessName == app.Name).ToList().Count == 0)
                        StartApp(app);
                }
                else
                {
                    StartApp(app);
                }
            }
        }

        private static void StartApp(AppModel app)
        {
            try
            {
                Process.Start(app.FilePath);
            }
            catch(Win32Exception e)
            {
                throw new Win32Exception($"{app.Name}({e.Message})");
            }
        }
    }
}