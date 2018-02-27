using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Solutions.Utils;

namespace Solutions.Problem046
{
    /*
        Goldbach's other conjecture
        Problem 46 
        It was proposed by Christian Goldbach that every odd composite number can be written as the sum of a prime and twice a square.

        9 = 7 + 2×1^2 = 7 + 2
        15 = 7 + 2×2^2 = 7 + 8
        21 = 3 + 2×3^2 = 3 + 18
        25 = 7 + 2×3^2 = 7 + 18
        27 = 19 + 2×2^2 = 8
        33 = 31 + 2×1^2 = 31 + 2

        It turns out that the conjecture was false.

        What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?
    */
    public static class V1
    {
        public static long Get()
        {
            var primes = new SortedSet<long>();
            var twiceSquares = new SortedSet<long>{0}; // apparently zero is a square...
            var oddComposite = 33L;
            while (SatisfiesConjecture(oddComposite, primes, twiceSquares))
                oddComposite += 2;

            return oddComposite;
        }

        public static bool SatisfiesConjecture(long n, SortedSet<long> primes, SortedSet<long> twiceSquares)
        {
            while (primes.Max < n) primes.Add(PrimeUtils.NextPrime(primes));
            while (twiceSquares.Max < n) twiceSquares.Add(2 * (long)Math.Pow(twiceSquares.Count, 2));

            return primes.Any(p => twiceSquares.Contains(n - p));
        }
    }
}
