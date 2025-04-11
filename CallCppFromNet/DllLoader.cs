using System.Runtime.InteropServices;
using System;

namespace CallCppFromNet
{
    abstract class DllLoader : IDisposable 
    {
        //[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //private static extern IntPtr LoadLibrary(string libname);

        //[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        //private static extern bool FreeLibrary(IntPtr hModule);

        //[DllImport("kernel32.dll", CharSet = CharSet.Auto)]


        // private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        //[DllImport("kernel32.dll")]
        //protected static extern IntPtr LoadLibrary(string dllToLoad);

        //[DllImport("kernel32.dll")]
        //protected static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        //[DllImport("kernel32.dll")]
        //protected  static extern bool FreeLibrary(IntPtr hModule);

        /// <summary>
        ///  указатель на загруженную Dll
        /// </summary>
        protected  IntPtr Handle { get; private set; }

        public DllLoader(string filename)
        {
            Handle = NativeMethods.LoadLibrary(filename);
            if (Handle == IntPtr.Zero)
            {
                int errorCode = Marshal.GetLastWin32Error();
                throw new Exception(
                   string.Format("Failed to load library (ErrorCode: {0})", errorCode));
            }
        }

        protected T GetDelegate<T>(string functionName)where T : Delegate 
    {
        IntPtr funcaddr = NativeMethods.GetProcAddress(Handle, functionName);
       // return Marshal.GetDelegateForFunctionPointer<T>(funcaddr);
        // или для старых версий .NET
         return (T)Marshal.GetDelegateForFunctionPointer(funcaddr, typeof(T));
    }

    public void Dispose()
        {
            if (Handle != IntPtr.Zero)
                NativeMethods.FreeLibrary(Handle);
        }
    }


}
