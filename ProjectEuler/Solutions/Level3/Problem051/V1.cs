using System;
using System.Collections.Generic;
using System.Linq;
using Solutions.Utils;

namespace Solutions.Problem051
{
    /*
        Prime digit replacements
        Problem 51 
        By replacing the 1st digit of the 2-digit number *3, it turns out that six of the nine possible values: 13, 23, 43, 53, 73, and 83, are all prime.

        By replacing the 3rd and 4th digits of 56**3 with the same digit, this 5-digit number is the first example having 
        seven primes among the ten generated numbers, yielding the family: 56003, 56113, 56333, 56443, 56663, 56773, and 56993. 
        Consequently 56003, being the first member of this family, is the smallest prime with this property.

        Find the smallest prime which, by replacing part of the number (not necessarily adjacent digits) with the same digit, 
        is part of an eight prime value family.
    */

    public static class V1
    {
        public static IEnumerable<long[]> Main()
        {
            var primes = new SortedSet<long>{2, 3, 5, 7};
            var primesTodo = new SortedSet<long>();
            var digits = 2;
            while (true)
            {
                var maxForDigits = Math.Pow(10, digits);
                while (primes.Max < maxForDigits)
                {
                    var nxt = PrimeUtils.NextPrime(primes);
                    if (nxt >= maxForDigits) break;
                    primes.Add(nxt);
                    primesTodo.Add(nxt);
                }

                while (primesTodo.Any())
                {
                    var todo = primesTodo.First();
                    foreach (var family in Replacements(todo))
                    {
                        var familyPrimes = family.Where(x => primes.Contains(x)).ToArray();

                        yield return familyPrimes;
                        primesTodo.ExceptWith(familyPrimes);
                    }
                }

                digits++;
            }
        }

        public static IEnumerable<long[]> Replacements(long n)
        {
            var digits = MiscUtils.GetDigits(n).ToArray();
            var positions = Enumerable.Range(0, digits.Length).ToArray();

            for (var count = 1; count < digits.Length; count++)
            {
                foreach (var replacedIndexes in positions.Choose(count))
                {
                    var rets = new List<long>();
                    for (var i = 0; i < 10; i++)
                    {
                        var retDigits = new int[digits.Length];
                        digits.CopyTo(retDigits, 0);
                        foreach (var position in replacedIndexes)
                        {
                            retDigits[position] = i;
                        }

                        var ret = retDigits.DigitsToNumber();
                        if (ret.ToString().Length == retDigits.Length)
                        {
                            rets.Add(ret);
                        }
                    }

                    yield return rets.ToArray();
                }
            }
        }
    }
}
