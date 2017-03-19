using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Utils
{
    public static class FactorUtils
    {
        public static IEnumerable<int> GetFactors(int n)
        {
            return Enumerable.Range(1, n/2).Where(i => n%i == 0);
        }

        public static IEnumerable<long> GetFactors(long n)
        {
            var lowestOtherFactor = n;
            for (var i = 1; i < lowestOtherFactor; i++)
            {
                if (n % i != 0) continue;
                var otherFactor = n/i;
                yield return i;
                yield return otherFactor;
                lowestOtherFactor = Math.Min(lowestOtherFactor, otherFactor);
            }

            if (n == 1) yield return 1;
        }
    }
}
