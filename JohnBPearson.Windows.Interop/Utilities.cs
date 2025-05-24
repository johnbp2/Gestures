using System;
using System.Runtime.InteropServices;


namespace JohnBPearson.Windows.Interop
{

    public static class Utilities
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

        public static void MyMessageBox(string text, string caption)
        {
            // Invoke the function as a regular managed method.
            MessageBox(IntPtr.Zero, text, caption, 0);
        }


    }


}