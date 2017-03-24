using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Utils
{
    public static class PrimeUtils
    {
        public static IEnumerable<long> Primes => GetPrimes();

        private static IEnumerable<long> GetPrimes()
        {
            var primes = new List<long>();
            var curr = 1L;
            while (true)
            {
                if (!IsCoprimeOf(++curr, primes)) continue;
                yield return curr;
                primes.Add(curr);
            }
        }

        public static long NthPrime(int n)
        {
            return Primes.ElementAt(n - 1);
        }

        public static bool IsCoprimeOf(long x, IEnumerable<long> ns)
        {
            return ns.All(i => x % i != 0);
        }

        public static bool IsPrime(long n)
        {
            return n >= 0 && IsCoprimeOf(n, GetPrimes().TakeWhile(p => p < n/2));
        }
    }
}
