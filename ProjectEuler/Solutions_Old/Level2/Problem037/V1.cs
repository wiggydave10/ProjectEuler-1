using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Solutions.Utils;

namespace Solutions.Problem037
{
    /*
        Truncatable primes

        The number 3797 has an interesting property. Being prime itself, 
        it is possible to continuously remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7. 
        Similarly we can work from right to left: 3797, 379, 37, and 3.

        Find the sum of the only eleven primes that are both truncatable from left to right and right to left.

        NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.
    */
    public static class V1
    {
        public static IEnumerable<long> Get()
        {
            var primeHistory = new HashSet<long>(PrimeUtils.Primes.Take(4));
            var count = 0;

            foreach (var prime in PrimeUtils.Primes.Skip(4))
            {
                if (count >= 11) break;
                primeHistory.Add(prime);

                if (IsTruncatablePrime(prime, primeHistory))
                {
                    yield return prime;
                    count++;
                }
            }
        }

        public static bool IsTruncatablePrime(long prime, ISet<long> primes)
        {
            return IsTruncatablePrime(prime, primes, TruncateLeft) &&
                   IsTruncatablePrime(prime, primes, TruncateRight);
        }

        public static bool IsTruncatablePrime(long prime, ISet<long> primes, Func<IEnumerable<int>, IEnumerable<int>> truncateFunc)
        {
            var digits = MiscUtils.GetDigits(prime).ToArray();
            if (digits.Length == 1) return primes.Contains(prime);

            return primes.Contains(prime)
                   && IsTruncatablePrime(truncateFunc(digits).DigitsToNumber(), primes, truncateFunc);
        }

        public static IEnumerable<T> TruncateLeft<T>(IEnumerable<T> e)
        {
            return e.Skip(1);
        }

        public static IEnumerable<T> TruncateRight<T>(IEnumerable<T> e)
        {
            var arr = e.ToList();
            return arr.GetRange(0, arr.Count - 1);
        }
    }
}
