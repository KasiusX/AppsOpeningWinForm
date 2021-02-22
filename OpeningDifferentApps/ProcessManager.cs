using OpeningDifferentApps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;

namespace OpeningDifferentApps
{
    internal static class ProcessManager
    {
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr window, out int id);
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
            //return String.IsNullOrEmpty(p.MainWindowTitle) ? false : true;
            if (String.IsNullOrEmpty(p.MainWindowTitle))
                return false;
            else if (p.MainWindowHandle == IntPtr.Zero)
                return false;
            
            return true;
        }

        public static List<AppModel> ConvertProceessOnAppModel(this List<Process> processes)
        {
            List<AppModel> output = new List<AppModel>();
            foreach (Process p in processes)
            {        
                try
                {
                    output.Add(new AppModel
                    {
                        FilePath = p.MainModule.FileName,
                        Name = p.ProcessName
                    });
                }
                catch(Win32Exception CanGetSartFileException)
                {
                    
                }
            }
            return output;
        }

        public static void GetStartingFileAndName(IntPtr window,List<Process> visibleProcesses,
            out string path,
            out string name)
        {
            int id;
            GetWindowThreadProcessId(window, out id);
            Process p = GetProcessFromVisibleProcesses(id, visibleProcesses);

            if(p == null)
            {
                path = null;
                name = null;
                return;
            }
            

            try
            {
                path = p.MainModule.FileName;
                name = p.ProcessName;
            }
            catch (Win32Exception e)
            {
                Console.WriteLine(e.Message +$"({p.ProcessName})");
                path = null;
                name = null;
                return;
            }
            
        }

        private static Process GetProcessFromVisibleProcesses(int id,List<Process> visibleProcesses)
        {
            try
            {
                return visibleProcesses.Where(x => x.Id == id).First();
            }
            catch (InvalidOperationException)
            {                
                return null;
            }
        }

        public static void CloseAllVisibleProcesses(List<string> ExceptionNames = null)
        {
            List<Process> processesToClose = GetVisibleProcesses().GetClosableProcesses();            
            if(ExceptionNames != null)
            {
                processesToClose = processesToClose.Where(x => !ExceptionNames.Contains(x.ProcessName)).ToList();
            }
            foreach (Process process in processesToClose)
            {
                try
                {
                    process.Kill();
                }
                catch(Win32Exception)
                {
                    Process currentProcess = process;
                    while (!String.IsNullOrEmpty(currentProcess.MainWindowTitle))
                    {
                        currentProcess.CloseMainWindow();
                        currentProcess = Process.GetProcessById(currentProcess.Id);
                    }
                }
            }
        }

        public static List<Process> GetClosableProcesses(this List<Process> processes)
        {            
            processes = processes.RemoveThisAppProcess();
            if (Debugger.IsAttached)
                processes = processes.RemoveDevelopingEnvironment();
            return processes;
        }

        public static List<Process> RemoveThisAppProcess(this List<Process> processesToValidate)
        {
            string thisAppName = AppDomain.CurrentDomain.FriendlyName;
            return processesToValidate.Where(x => x.ProcessName != RemoveSuffix(thisAppName)).ToList();
        }

        private static string RemoveSuffix(string stringToEdit)
        {
            return stringToEdit.Substring(0, stringToEdit.Length - 4);
        }

        public static List<Process> RemoveDevelopingEnvironment(this List<Process> processesToValidate)
        {
            string[] stayOpenInDev = { "devenv" };
            return processesToValidate.Where(x => !stayOpenInDev.Contains(x.ProcessName)).ToList();
        }

        public static IntPtr GetWindowByName(string processName)
        {
            List<Process> visibleProcesses = GetVisibleProcesses();
            Process selectedProcess = visibleProcesses.Where(x => x.ProcessName == processName).ToList().First();
            return selectedProcess.MainWindowHandle;
        }

        public static bool IsAppOpen(AppModel app)
        {
            List<Process> visibleProccesses = GetVisibleProcesses();
            return visibleProccesses.Where(x => x.ProcessName == app.Name).ToList().Count == 0 ? false : true;
        }

    }
}
