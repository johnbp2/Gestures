using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JohnBPearson.Windows.Interop
{
    public static class WindowHelper
    {
        public enum FindBy
        {
        ClassName,
        Title
        }

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void ShowExistingInstance(string identifier,FindBy findBy)
        {

            IntPtr? hWnd = null;
            if(findBy == FindBy.ClassName)
            {

                // Get the window handle of the main form
                  hWnd = FindWindow(identifier, null); // Replace "YourMainFormTitle" with the actual title
            }
            else
            {
                 hWnd = FindWindow(null, identifier); // Replace "YourMainFormTitle" with the actual title
            }
            if(hWnd != IntPtr.Zero)
            {
                // Activate the existing instance
                SetForegroundWindow((IntPtr)hWnd);
            }
        }
    }
}
  