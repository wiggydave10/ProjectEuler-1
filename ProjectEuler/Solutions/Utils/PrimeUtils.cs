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
            var primes = new List<int>();
            var curr = 1;
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

        private static bool IsCoprimeOf(int x, IEnumerable<int> ns)
        {
            return ns.All(i => x % i != 0);
        }
    }
}
