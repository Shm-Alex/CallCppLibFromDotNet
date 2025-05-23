﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DotNetStandardCppWrapper;
using MathLibContract;
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
            #region Call SumInts from CppLib using DllImport
            int[] a = { 1, 2, 3, 4,5,6,7,8, 0 };

            string separator = " + ";
            Console.WriteLine($@"line 27 Call cpp code from {CppLib} {nameof(SumInts)} ({String.Join(separator,a)}) = {SumInts(a)}");
            #endregion

            #region  manual loading dll to memory using system32 LoadLibrary and   Call SumInts from CppLib and call SumInts  binding delegete SumIntsDelegate  with  cpp code via   GetDelegateForFunctionPointer  
            IntPtr pDll = NativeMethods.LoadLibrary(CppLib);
            IntPtr pAddressOfFunctionToCall = NativeMethods.GetProcAddress(pDll, $"{nameof(SumInts)}");
            var SumIntsDelegateObj = (SumIntsDelegate)Marshal.GetDelegateForFunctionPointer(
                                                                                    pAddressOfFunctionToCall,
                                                                                    typeof(SumIntsDelegate));
            Console.WriteLine($@"line 36 Call cpp code from {CppLib} {nameof(SumInts)} ({String.Join(separator, a)}) = {SumInts(a)}");

            #endregion
            #region same as previous method, but using  IDisposable wrapper class

            using (IMathLibService cppDll =new SumIntsCallWrapper(CppLib))
            {
                Console.WriteLine($@"line 43 Call cpp code from {CppLib} {nameof(SumInts)} ({String.Join(separator, a)}) = {cppDll.SumInts(a)}");
            }
            #endregion

        }
    }
}
