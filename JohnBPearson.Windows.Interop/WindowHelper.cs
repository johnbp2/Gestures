using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JohnBPearson.Windows.Interop
{
    public static class WindowHelper
    {
        public enum FindBy
        {
//ClassName,
        Title
        }

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void ShowExistingInstance(string identifier)
        {

            IntPtr? hWnd = null;
            //if(findBy == FindBy.ClassName)
            //{

            //    // Get the window handle of the main form
            //      hWnd = FindWindow(identifier, null); // Replace "YourMainFormTitle" with the actual title
            //}
            //else
            //{
                 hWnd = FindWindow(null, identifier); // Replace "YourMainFormTitle" with the actual title
            //}
            if(hWnd != IntPtr.Zero)
            {
                // Activate the existing instance
                SetForegroundWindow((IntPtr)hWnd);
            }
        }
    }

    static public class WinApi
    {
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);

        public static int RegisterWindowMessage(string format, params object[] args)
        {
            string message = String.Format(format, args);
            return RegisterWindowMessage(message);
        }

        public const int HWND_BROADCAST = 0xffff;
        public const int SW_SHOWNORMAL = 1;

        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImportAttribute("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void ShowToFront(IntPtr window)
        {
            ShowWindow(window, SW_SHOWNORMAL);
            SetForegroundWindow(window);
        }
    }

    static public class SingleInstance
    {
        public static readonly int WM_SHOWFIRSTINSTANCE =
         WinApi.RegisterWindowMessage("WM_SHOWFIRSTINSTANCE|{0}", ProgramInfo.AssemblyGuid);
        static Mutex mutex;
        static public bool Start()
        {
            bool onlyInstance = false;
            string mutexName = String.Format("Local\\{0}", ProgramInfo.AssemblyGuid);

            // if you want your app to be limited to a single instance
            // across ALL SESSIONS (multiple users & terminal services), then use the following line instead:
            // string mutexName = String.Format("Global\\{0}", ProgramInfo.AssemblyGuid);

            mutex = new Mutex(true, mutexName, out onlyInstance);
            return onlyInstance;
        }
        static public void ShowFirstInstance()
        {
            WinApi.PostMessage(
             (IntPtr)WinApi.HWND_BROADCAST,
             WM_SHOWFIRSTINSTANCE,
             IntPtr.Zero,
             IntPtr.Zero);
        }
        static public void Stop()
        {
            mutex.ReleaseMutex();
     
        }
    }


    static public class ProgramInfo
    {
        static public string AssemblyGuid
        {
            get
            {


                var ca = (GuidAttribute)Attribute.GetCustomAttribute(Assembly.GetEntryAssembly(), typeof(GuidAttribute));
                string guid = ca.Value;
                return guid;
               // object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
                //if(attributes.Length == 0)
                //{
                //    return String.Empty;
                //}
                //return ((System.Runtime.InteropServices.GuidAttribute)attributes[0]).Value;
            }
        }
    }

}
