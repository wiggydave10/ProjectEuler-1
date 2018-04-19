using System.Collections.Generic;
using System.Linq;
using Solutions.Utils;

namespace Solutions.Problem035
{
    /*
        Circular primes

        The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.

        There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.

        How many circular primes are there below one million?
    */
    public static class V1
    {
        public static IEnumerable<long> Get(int n)
        {
            var primes = new HashSet<long>(PrimeUtils.Primes.TakeWhile(x => x < n));
            return primes.Where(x => IsCircularPrime(x, primes));
        }

        public static bool IsCircularPrime(long n, HashSet<long> primes)
        {
            var digits = MiscUtils.GetDigits(n).ToArray();
            return Enumerable.Range(1, digits.Length)
                .Select(i =>
                        digits.Select((x, ix) => new {x, ix})
                            .OrderBy(p => (p.ix + i) % digits.Length)
                            .Select(p => p.x)
                            .DigitsToNumber())
                .All(x => primes.Contains(x));
        }
    }
}
