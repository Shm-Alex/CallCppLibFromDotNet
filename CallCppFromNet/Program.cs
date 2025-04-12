using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DotNetStandardCppWrapper;
namespace CallCppFromNet
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
            int[] a = { 1, 2, 3, 4,5,6,7,8, 0 };

            string separator = " + ";
            Console.WriteLine($@"Call cpp code from {CppLib} {nameof(SumInts)} ({String.Join(separator,a)}) = {SumInts(a)}");
            IntPtr pDll = NativeMethods.LoadLibrary(CppLib);
            IntPtr pAddressOfFunctionToCall = NativeMethods.GetProcAddress(pDll, $"{nameof(SumInts)}");
            var SumIntsDelegateObj = (SumIntsDelegate)Marshal.GetDelegateForFunctionPointer(
                                                                                    pAddressOfFunctionToCall,
                                                                                    typeof(SumIntsDelegate));
            using (SumIntsCallWrapper cppDll=new SumIntsCallWrapper(CppLib))
            {
                Console.WriteLine($@"Call cpp code from {CppLib} {nameof(SumInts)} ({String.Join(separator, a)}) = {cppDll.SumInts(a)}");
            }

            Console.WriteLine($@"Call cpp code from {CppLib} {nameof(SumInts)} ({String.Join(separator, a)}) = {SumInts(a)}");         
        }
    }
}
