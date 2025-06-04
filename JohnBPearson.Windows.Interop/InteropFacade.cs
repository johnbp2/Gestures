using System;
using System.Runtime.InteropServices;
using JohnBPearson.Application.Gestures.Model;

namespace JohnBPearson.Windows.Interop
{

    public delegate void KeyBindCallBack(IContainer item);
    internal class InteropFacade
    {
        public InteropFacade() { }



        // Registers a hot key with Windows.
        [DllImport("user32.dll")]
        internal static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        // Unregisters the hot key with Windows.
        [DllImport("user32.dll")]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    }
}
