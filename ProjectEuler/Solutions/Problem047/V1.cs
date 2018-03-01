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

namespace Solutions.Problem047
{
    /*
        Distinct primes factors
        Problem 47 
        The first two consecutive numbers to have two distinct prime factors are:

        14 = 2 × 7
        15 = 3 × 5

        The first three consecutive numbers to have three distinct prime factors are:

        644 = 2² × 7 × 23
        645 = 3 × 5 × 43
        646 = 2 × 17 × 19.

        Find the first four consecutive integers to have four distinct prime factors each. What is the first of these numbers?
    */
    public static class V1
    {
        public static long Main(int distinctCount)
        {
            var primes = new List<long>{2};
            var count = 0;
            var n = 2L;
            while (count != distinctCount)
            {
                if (primes.Last() < n) primes.Add(PrimeUtils.NextPrime(primes));
                // stop collecting factors if more than distinct count
                var primeFactors = GetPrimeFactors(n, primes).TakeWhile((x, i) => i <= distinctCount);

                count = primeFactors.Count() == distinctCount ? count + 1 : 0;
                n++;
            }

            return n - distinctCount;
        }

        public static IEnumerable<PrimeFactor> GetPrimeFactors(long n, List<long> primes)
        {
            if (primes.Last() == n)
            {
                yield return new PrimeFactor(n, 1);
                yield break;
            }

            foreach (var prime in primes)
            {
                var exponant = 0;
                var remainder = n;
                while (remainder > 1 && remainder % prime == 0)
                {
                    exponant++;
                    remainder /= prime;
                }

                if (exponant == 0) continue;

                yield return new PrimeFactor(prime, exponant);
            }
        }
    }

    public class PrimeFactor : Tuple<long, int>
    {
        public PrimeFactor(long prime, int exponant) : base(prime, exponant) {}
        public long Value => (long) Math.Pow(Item1, Item2);
    }
}
