using System.Linq;
using Solutions.Utils;

namespace Solutions.Problem012
{
    public static class V1
    {
        public static long TriangleNumberWithNDivisors(int n)
        {
            return TriangleNumberUtils.TriangleNumbers.SkipWhile(t => FactorUtils.GetFactors(t).Count() < n).First();
        }
    }
}
