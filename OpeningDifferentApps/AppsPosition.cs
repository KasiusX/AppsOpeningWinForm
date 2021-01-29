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
    internal class AppsPosition
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

        public Rect GetAppPosition(string appName)
        {
            Rect position = new Rect();
            IntPtr window = ProcessManager.GetWindowByName(appName);
            GetWindowRect(window, ref position);
            return position;
        }

        public void SetAppPosition(AppModel app)
        {
            Console.WriteLine($"Setting position of {app.Name}");
            IntPtr window = ProcessManager.GetWindowByName(app.Name);                      
            ShowWindow(window, 9);
            SetWindowPos(window, IntPtr.Zero, app.Position.Left, app.Position.Top, app.Position.Width, app.Position.Height, SWP_SHOWWINDOW);
            Console.WriteLine($"position of {app.Name} set");
        }

        public bool IsAppOnCorrectPosition(AppModel app) => app.Position.Equals(GetAppPosition(app.Name));                
        
        public void BringWindowForward(AppModel app)
        {
            IntPtr window = ProcessManager.GetWindowByName(app.Name);
            SetForegroundWindow(window);
        }
    }
}
