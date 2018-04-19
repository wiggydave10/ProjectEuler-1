using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.Problem001
{
    public static class V2
    {
        public static long SumMultiples(int n)
        {
            var duplicateSums = 15* Enumerable.Range(1, (int) Math.Floor((double) n/15)).Select(i => (long)i).Sum();
            return SumMultiplesOf(3, n) + SumMultiplesOf(5, n) - duplicateSums;
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
