using OpeningDifferentApps.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OpeningDifferentApps
{
    static internal class AppsPosition
    {
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        const uint SWP_SHOWWINDOW = 0x0040;

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr window);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private static List<IntPtr> PlacedWindows { get; set; }

        public static Rect GetAppPosition(string appName)
        {
            IntPtr window = ProcessManager.GetWindowByName(appName);
            return GetAppPosition(window);
        }

        public static Rect GetAppPosition(IntPtr window)
        {
            Rect position = new Rect();
            GetWindowRect(window, ref position);
            return position;
        }

        public static void ResetWindows()
        {
            PlacedWindows = new List<IntPtr>();
        }

        public static void SetAppPosition(AppModel app)
        {
            Console.WriteLine($"Setting position of {app.Name}");
            IntPtr window = GetValidWindowToMove(app);
            ShowWindow(window, 9);
            SetWindowPos(window, IntPtr.Zero, app.Position.Left, app.Position.Top, app.Position.Width, app.Position.Height, SWP_SHOWWINDOW);
            Console.WriteLine($"position of {app.Name} set");
        }

        private static IntPtr GetValidWindowToMove(AppModel app)
        {
            List<IntPtr> allAppWindows = WindowsManager.GetAllWindows(app.Name);
            if(IsWindowAlreadyPlaced(allAppWindows,app,out IntPtr placedWindow))
            {
                return placedWindow;
            }

            foreach (IntPtr window in allAppWindows)
            {
                if (!PlacedWindows.Contains(window))
                {
                    PlacedWindows.Add(window);
                    return window;
                }
            }
            return IntPtr.Zero;
        }

        private static bool IsWindowAlreadyPlaced(List<IntPtr> allAppWindows,AppModel app, out IntPtr window)
        {
            List<Rect> allAppPositions = GetAppsPositions(allAppWindows);
            foreach (IntPtr intPtr in allAppWindows)
            {
                if (allAppPositions[allAppWindows.IndexOf(intPtr)].Equals(app.Position))
                {
                    window = intPtr;
                    return true;
                }
            }
            window = IntPtr.Zero;
            return false;
        }

        private static List<Rect> GetAppsPositions(List<IntPtr> windows)
        {
            List<Rect> appsPositions = new List<Rect>();
            foreach (IntPtr window in windows)
            {
                appsPositions.Add(GetAppPosition(window));
            }
            return appsPositions;
        }


        public static bool IsAppOnCorrectPosition(AppModel app) => app.Position.Equals(GetAppPosition(app.Name));                
        
        public static void BringWindowForward(AppModel app)
        {
            IntPtr window = ProcessManager.GetWindowByName(app.Name);
            SetForegroundWindow(window);
        }
    }
}
