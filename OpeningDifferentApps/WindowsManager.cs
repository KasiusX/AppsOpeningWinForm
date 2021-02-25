using OpeningDifferentApps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OpeningDifferentApps
{
    public static class WindowsManager
    {
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr window, StringBuilder output, int maxCount);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows",
        ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDelegate lpEnumCallbackFunction, IntPtr lParam);
        private delegate bool EnumDelegate(IntPtr hWnd, int lParam);

        private static List<IntPtr> VisibleWindows = new List<IntPtr>();        

        public static List<ListBoxAppModel> GetAllWindows()
        {
            List<ListBoxAppModel> listForCheckbox = new List<ListBoxAppModel>();
            Console.WriteLine("Getting handles");            
            Console.WriteLine($"Handles done({VisibleWindows.Count})");           
            List<AppModel> visibleApps = GetVisibleApps(out List<string> titles, out List<IntPtr> windows);
            foreach (AppModel app in visibleApps)
            {
                listForCheckbox.Add(new ListBoxAppModel
                {
                    App = app,
                    Title = titles[visibleApps.IndexOf(app)],
                    Window = windows[visibleApps.IndexOf(app)]
                });
            }
            Console.WriteLine("Everything done");
            return listForCheckbox;
        }

        private static bool FilterWindow(IntPtr window,List<Process> visibleProcesses,out string startingFile, out string name)
        {
            Console.WriteLine("________");
            Console.WriteLine($"making handle:{window}");
            ProcessManager.GetStartingFileAndName(window, visibleProcesses, out startingFile, out name);

            if (name != null || startingFile != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<AppModel> GetVisibleApps(out List<string> titles, out List<IntPtr> windows)
        {
            List<AppModel> visibleApps = new List<AppModel>();
            SetHandles();
            titles = new List<string>();
            windows = new List<IntPtr>();
            List<Process> visibleProcesses = ProcessManager.GetVisibleProcesses();
            foreach (IntPtr window in VisibleWindows)
            {
                if(FilterWindow(window, visibleProcesses, out string startingFile, out string name))
                {
                    visibleApps.Add(CreateAppModel(startingFile,name,window));
                    windows.Add(window);
                    titles.Add(GetWindowText(window));
                }
            }
            return visibleApps;
        }

        private static AppModel CreateAppModel(string startingFile, string name, IntPtr window)
        {
            Console.WriteLine("Making appModel");
            return new AppModel
            {
                FilePath = startingFile,
                Name = name,
                Position = AppsPosition.GetAppPosition(window)
            };
        }

        private static void SetHandles()
        {
            VisibleWindows = new List<IntPtr>();
            List<IntPtr> visibleWindows = new List<IntPtr>();
            if (!EnumDesktopWindows(IntPtr.Zero, FilterCallback, IntPtr.Zero))
            {
                VisibleWindows = null;
            }
        }

        private static bool FilterCallback(IntPtr hWnd, int lParam)
        {            
            string title = GetWindowText(hWnd);
                     
            if (IsWindowVisible(hWnd) && !string.IsNullOrEmpty(title))
            {
                VisibleWindows.Add(hWnd);
            }

            return true;
        }

        private static string GetWindowText(IntPtr window)
        {
            StringBuilder sb_title = new StringBuilder(1024);
            int length = GetWindowText(window, sb_title, sb_title.Capacity);
            return sb_title.ToString();
        }

        public static List<IntPtr> GetAllWindows(string appName)
        {
            List<IntPtr> visibleWindows = new List<IntPtr>();
            SetHandles();
            List<Process> visibleProcesses = ProcessManager.GetVisibleProcesses();
            foreach (IntPtr window in VisibleWindows)
            {
                ProcessManager.GetStartingFileAndName(window, visibleProcesses, out string path, out string name);
                if(appName == name)
                {
                    visibleWindows.Add(window);
                }
            }
            return visibleWindows;
        }
    }
}
