using System;

namespace MathLibContract
{
   public interface IMathLibService:IDisposable
    {
        int SumInts(int[] numberToSum);
    }
}
