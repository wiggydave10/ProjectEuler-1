using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solutions.Problem1
{
    public static class V2
    {
        public static long SumMultiples(int n)
        {
            var t1 = SumMultiplesOf(3, n);
            var t2 = SumMultiplesOf(5, n);
            var s1 = 15* Enumerable.Range(1, (int) Math.Floor((double) n/15)).Select(i => (long)i).Sum();
            return t1 + t2 - s1;
        }

        private static long SumMultiplesOf(int n, int limit)
        {
            return MultiplesOf(n, limit).Sum();
        }

        private static IEnumerable<long> MultiplesOf(int n, int limit)
        {
            limit -= n;
            var prev = 0;
            while (prev < limit)
            {
                prev += n;
                yield return prev;
            }
        }
    }
}
