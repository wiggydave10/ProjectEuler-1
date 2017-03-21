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

        public static IEnumerable<long> GetProperFactors(long n)
        {
            yield return 1;
            var lowestOtherFactor = n;
            for (var i = 2; i < lowestOtherFactor; i++)
            {
                if (n % i != 0) continue;
                var otherFactor = n / i;
                yield return i;
                yield return otherFactor;
                lowestOtherFactor = Math.Min(lowestOtherFactor, otherFactor);
            }
        }

        public static IEnumerable<long> GetFactors(long n)
        {
            foreach (var factor in GetProperFactors(n))
            {
                yield return factor;
            }

            yield return n;
        }
    }
}
