using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CallCppFromNet
{
    internal class Program
    {
        private const string CppLib = "CppSourceCodeProject.dll";

        [DllImport(CppLib, CallingConvention = CallingConvention.Cdecl/**/)]
        public static extern int SumInts(int[] a);
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4,5,6,7,8, 0 };

            string separator = " + ";
            Console.WriteLine($@"Call cpp code from {CppLib} {nameof(SumInts)} ({String.Join(separator,a)}) = {SumInts(a)}");
        }
    }
}
