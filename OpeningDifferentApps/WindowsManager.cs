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
            List<ListBoxAppModel> visibleApps = new List<ListBoxAppModel>();
            Console.WriteLine("Getting handles");
            GetHandles();
            Console.WriteLine($"Handles done({VisibleWindows.Count})");
            List<Process> visibleProcesses = ProcessManager.GetVisibleProcesses();
            foreach (IntPtr window in VisibleWindows)
            {
                Console.WriteLine("________");
                Console.WriteLine($"making handle:{window}");
                ProcessManager.GetStartingFileAndName(window, visibleProcesses, out string startingFile, out string name);

                if (name != null || startingFile != null)
                {
                    Console.WriteLine("Making appModel");
                    AppModel app = new AppModel
                    {
                        FilePath = startingFile,
                        Name = name,
                        Position = AppsPosition.GetAppPosition(window)
                    };

                    visibleApps.Add(new ListBoxAppModel
                    {
                        App = app,
                        Title = GetWindowText(window)
                    });
                }
                Console.WriteLine();
            }
            Console.WriteLine("Everything done");
            return visibleApps;
        }

        private static void GetHandles()
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
    }
}
