using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using JohnBPearson.KeyBindingButler.Model;

namespace JohnBPearson.Windows.Interop
{

    public delegate void KeyBindCallBack(IContainer item);
    public class InteropFacade
    {
        public InteropFacade() { }



        // Registers a hot key with Windows.
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        // Unregisters the hot key with Windows.
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    }
}
