using OpeningDifferentApps.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace OpeningDifferentApps
{
    internal class AppsPosition
    {        
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        const uint SWP_SHOWWINDOW = 0x0040;

        public Rect GetAppPosition(string appName)
        {
            Rect position = new Rect();
            IntPtr window = ProcessManager.GetWindowByName(appName);
            GetWindowRect(window, ref position);
            return position;
        }

        public void SetAppPosition(AppModel app)
        {
            IntPtr window = ProcessManager.GetWindowByName(app.Name);
            SetWindowPos(window, IntPtr.Zero, app.Position.Left, app.Position.Top,GetAppWidth(app.Position), GetAppHeight(app.Position), SWP_SHOWWINDOW);
        }

        private int GetAppHeight(Rect position) => position.Bottom - position.Top;
        

        private int GetAppWidth(Rect position) => position.Right - position.Left;
        

        
    }
}
