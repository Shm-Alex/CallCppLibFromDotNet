using System.Runtime.InteropServices;
using DotNetStandardCppWrapper;
using MathLibContract;
namespace CrossPlatformConsole
{
    internal class Program
    {

            private const string CppLib = "CppSourceCodeProject.dll";

            [DllImport(CppLib, CallingConvention = CallingConvention.Cdecl/**/)]
            public static extern int SumInts(int[] a);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            private delegate int SumIntsDelegate(int[] numberToSum);
            static void Main(string[] args)
            {
            #region Call SumInts from CppLib using DllImport
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };

            string separator = " + ";
            Console.WriteLine($@"Line 22 Call cpp code from {CppLib} {nameof(SumInts)} ({String.Join(separator, a)}) = {SumInts(a)}");
            #endregion

            #region  manual loading dll to memory using system32 LoadLibrary and   Call SumInts from CppLib and call SumInts  binding delegete SumIntsDelegate  with  cpp code via   GetDelegateForFunctionPointer  
            IntPtr pDll = NativeMethods.LoadLibrary(CppLib);
            IntPtr pAddressOfFunctionToCall = NativeMethods.GetProcAddress(pDll, $"{nameof(SumInts)}");
            var SumIntsDelegateObj = (SumIntsDelegate)Marshal.GetDelegateForFunctionPointer(
                                                                                    pAddressOfFunctionToCall,
                                                                                    typeof(SumIntsDelegate));
            Console.WriteLine($@"Line 31 Call cpp code from {CppLib} {nameof(SumInts)} ({String.Join(separator, a)}) = {SumIntsDelegateObj(a)}");

            #endregion
            #region same as previous method, but using  IDisposable wrapper class

            using (IMathLibService cppDll = new SumIntsCallWrapper(CppLib))
            {
                Console.WriteLine($@"line 38  Call cpp code from {CppLib} {nameof(SumInts)} ({String.Join(separator, a)}) = {cppDll.SumInts(a)}");
            }
            #endregion
        }
    }
    
}
