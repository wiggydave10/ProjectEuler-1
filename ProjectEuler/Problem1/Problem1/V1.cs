using System.Collections.Generic;
using System.Linq;

namespace Solutions.Problem1
{
    public static class V1
    {
        public static long SumMultiples(int n)
        {
            return GetMultiples(n).Sum();
        }

        private static IEnumerable<long> GetMultiples(int n)
        {
            for (var i = 1; i < n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0) yield return i;
            }
        }
    }
}
