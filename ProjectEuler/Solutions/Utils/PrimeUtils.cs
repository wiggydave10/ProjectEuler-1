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

        public static long NextPrime(IEnumerable<long> primes)
        {
            return GetPrimes(primes).First();
        }

        private static IEnumerable<long> GetPrimes(IEnumerable<long> prevPrimes = null)
        {
            var primes = new SortedSet<long>(prevPrimes ?? new long[0]);
            var curr = primes.Max > 0 ? primes.Max : 1L;
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
