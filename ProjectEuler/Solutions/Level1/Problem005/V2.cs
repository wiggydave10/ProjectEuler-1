using System.Collections.Generic;
using System.Linq;

namespace Solutions.Problem005
{
    public static class V2
    {
        public static long SmallestMultiple(HashSet<int> factors)
        {
            var hFactors = GetHighestCoPrimes(factors);
            var minFactor = hFactors.Min();
            var n = minFactor*2;
            while (hFactors.Any(f => n % f != 0))
            {
                n += minFactor;
            }

            return n;
        }

        private static HashSet<int> GetHighestCoPrimes(HashSet<int> factors)
        {
            var ordered = new SortedSet<int>(factors.OrderByDescending(f => f));
            for (var i = ordered.Count-1; i > -1 ; i--)
            {
                for (var j = i-1; j > -1; j--)
                {
                    var b = ordered.ElementAt(j);
                    if (IsCofactor(ordered.ElementAt(i), b))
                    {
                        ordered.Remove(b);
                        i--;
                        j--;
                    }
                }
            }
            return new HashSet<int>(ordered);
        }

        private static bool IsCofactor(int a, int b)
        {
            return a%b == 0 || b%a == 0;
        }
    }
}
