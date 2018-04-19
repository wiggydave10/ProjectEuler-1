using System.Collections.Generic;
using System.Linq;

namespace Solutions.Problem003
{
    public static class Utils
    {
        public static IEnumerable<int> PrimeFactors(long n)
        {
            var prevPrimes = new List<int> {2};
            for (var i = 0; i <= prevPrimes.Count; i++)
            {
                if (n == 1) yield break;
                if (i == prevPrimes.Count) prevPrimes.Add(NextPrime(prevPrimes.Last()));
                var prime = prevPrimes[i];
                if (n % prime != 0) continue;

                n = n / prime;
                i = -1;
                yield return prime;
            }
        }

        public static int NextPrime(int n)
        {
            int curr = n;
            while (true)
            {
                curr++;
                if (IsPrime(curr)) return curr;
            }
        }

        public static bool IsPrime(int x)
        {
            return Enumerable.Range(2, x - 2).All(i => x % i != 0);
        }
    }
}
