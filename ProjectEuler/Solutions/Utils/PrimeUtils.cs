using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Utils
{
    public static class PrimeUtils
    {
        private const string PrimesFileKey = "Primes";
        public static IEnumerable<long> Primes => GetPrimes();
        public static IEnumerable<long> FilePrimes => GetFilePrimes();

        public static long NextPrime(IEnumerable<long> primes)
        {
            return GetPrimes(primes).First();
        }

        private static IEnumerable<long> GetPrimes(IEnumerable<long> prevPrimes = null)
        {
            var primes = new List<long>(prevPrimes ?? new long[0]);

            if (primes.Count < 2)
            {
                primes.AddRange(new []{ 2L, 3L });
                yield return 2L;
                yield return 3L;
            }
            var curr = primes.Last();

            while (true)
            {
                if (!IsCoprimeOf(curr += 2, primes)) continue;

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
            var limit = (long)Math.Sqrt(x);
            return ns.Where(n => n <= limit).All(n => x % n != 0);
        }

        public static bool IsPrime(long n)
        {
            return n >= 0 && IsCoprimeOf(n, GetPrimes().TakeWhile(p => p < n/2));
        }

        public static bool IsPrimeBasic(long n)
        {
            var limit = (long)Math.Sqrt(n);
            for (var i = 2; i <= limit; i++)
            {
                if (n % i == 0) return false;
            }

            return true;
        }

        private static IEnumerable<long> GetFilePrimes()
        {
            var primeFilename = ConfigurationManager.AppSettings[PrimesFileKey];
            if (File.Exists(primeFilename))
            {
                return File.ReadAllText(primeFilename).Split(',').Select(long.Parse);
            }

            return null;
        }
    }
}
