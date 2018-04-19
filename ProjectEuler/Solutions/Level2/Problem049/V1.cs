using System.Collections.Generic;
using System.Linq;
using Solutions.Utils;

namespace Solutions.Problem049
{
    /*
        Prime permutations
        Problem 49 
        The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways: 
            (i) each of the three terms are prime, and, 
            (ii) each of the 4-digit numbers are permutations of one another.

        There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, 
        but there is one other 4-digit increasing sequence.

        What 12-digit number do you form by concatenating the three terms in this sequence?
    */

    public static class V1
    {
        public static IEnumerable<string> Main()
        {
            var fourDigitPrimes =  new HashSet<long>(PrimeUtils.Primes
                .SkipWhile(x => x.ToString().Length < 4)
                .TakeWhile(x => x.ToString().Length == 4));

            while (fourDigitPrimes.Any())
            {
                var prime = fourDigitPrimes.First();
                var permutations = SetUtils.Permutations(MiscUtils.GetDigits(prime)).Select(x => (long)x.DigitsToNumber()).Where(x => x > 1000);
                var primePermutations = fourDigitPrimes.Intersect(permutations).ToArray();

                if (primePermutations.Length >= 3)
                {
                    var threes = primePermutations.Choose(3).ToArray();
                    foreach (var special in threes.Where(HaveEqualDifference))
                    {
                        yield return string.Join("", special.OrderBy(x => x));
                    }
                }

                fourDigitPrimes.ExceptWith(primePermutations);
            }
        }

        public static bool HaveEqualDifference(IEnumerable<long> xs)
        {
            long? diff = null;
            long? prev = null;
            foreach (var x in xs)
            {
               if (diff == null)
                {
                    diff = x - prev;
                }
                else if (x - prev.Value != diff.Value)
                {
                    return false;
                }

                prev = x;
            }

            return true;
        }
    }
}
