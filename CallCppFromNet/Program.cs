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
        [DllImport("CppSourceCodeProject.dll", CallingConvention = CallingConvention.Cdecl/**/)]
        public static extern int SumInts(int[] a);
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4,5,6,7, 0 };
            Console.WriteLine(SumInts(a));
        }
    }
}
