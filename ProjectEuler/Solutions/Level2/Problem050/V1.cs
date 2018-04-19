using System.Collections.Generic;
using System.Linq;
using Solutions.Utils;

namespace Solutions.Problem050
{
    /*
        Consecutive prime sum
        Problem 50 
        The prime 41, can be written as the sum of six consecutive primes:

        41 = 2 + 3 + 5 + 7 + 11 + 13
        This is the longest sum of consecutive primes that adds to a prime below one-hundred.

        The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.

        Which prime, below one-million, can be written as the sum of the most consecutive primes?
    */

    public static class V1
    {
        public static IEnumerable<string> Main()
        {
            return null;
        }

        public static long MaxConsecutivePrimeSum(IEnumerable<long> primes)
        {
            var primesArr = primes.ToArray();
            var primeSet = new SortedSet<long>(primesArr);
            var maxPrime = primeSet.Max;

            var tmpSum = 0L;
            return Enumerable.Range(0, primesArr.Length)
                .TakeWhile(i => (tmpSum += primesArr[i]) < maxPrime)
                .Reverse()
                .Select(i => primesArr.GetWindows(i)
                    .Select(window => window.Sum())
                    .TakeWhile(sum => sum <= maxPrime)
                    .FirstOrDefault(primeSet.Contains))
                .First(x => x > 0);
        }
    }
}
