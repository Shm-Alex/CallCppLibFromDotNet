using System.Runtime.InteropServices;
using System;
using System.IO;

namespace CallCppFromNet
{
    abstract class DllLoader : IDisposable 
    {

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
       
             return Marshal.GetDelegateForFunctionPointer<T>(funcaddr);

        // или для старых версий .NET
        // return (T)Marshal.GetDelegateForFunctionPointer(funcaddr, typeof(T));
    }
        // Detect redundant Dispose() calls.
        private bool _isDisposed;


        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                _isDisposed = true;

                if (disposing)
                {
                    // Dispose managed state.
                    if (Handle != IntPtr.Zero)
                    {
                        NativeMethods.FreeLibrary(Handle);
                        Handle = IntPtr.Zero;
                    }
                }
            }
        }

        
    }


}
