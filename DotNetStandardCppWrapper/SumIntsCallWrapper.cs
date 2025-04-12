using System.Runtime.InteropServices;

namespace DotNetStandardCppWrapper
{
   public  class SumIntsCallWrapper : DllLoader
    {
        public SumIntsCallWrapper(string filename) : base(filename)
        {
            SumIntsDelegate_ = GetDelegate<SumIntsDelegate>($"{nameof(SumInts)}");
        }
        public int SumInts(int[] numberToSum) => SumIntsDelegate_(numberToSum);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int SumIntsDelegate(int[] numberToSum);

        SumIntsDelegate SumIntsDelegate_;

    }
}
