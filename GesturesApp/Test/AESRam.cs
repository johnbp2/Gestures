using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace JohnBPearson.Windows.Forms.Gestures.Test
{
    internal class AESRam
    {
        [DllImport("KERNEL32.DLL", EntryPoint = "SetProcessWorkingSetSize", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool SetProcessWorkingSetSize(IntPtr pProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

        [DllImport("KERNEL32.DLL", EntryPoint= "GetCurrentProcess", SetLastError= true, CallingConvention= CallingConvention.StdCall)]
        internal static extern IntPtr GetProcessWorkingSetSize();

        internal AESRam() {

            var phandle = GetProcessWorkingSetSize();
            SetProcessWorkingSetSize(phandle, -1, -1);

        }

    }
}
