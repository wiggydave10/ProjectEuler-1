using System;
using System.Collections.Generic;
using System.Linq;
using Solutions.Utils;

namespace Solutions.Problem032
{
    /*
        Pandigital products

        We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; 
        for example, the 5-digit number, 15234, is 1 through 5 pandigital.

        The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.

        Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.

        HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.
    */
    public static class V1
    {
        public static IEnumerable<ProductEquation> PandigitalProducts(int pandigital)
        {
            var digits = new HashSet<int>(Enumerable.Range(1, pandigital));
            var lhsHistory = new HashSet<Tuple<int, int>>();
            foreach (var multiplicand in DistinctNumbers().TakeWhile(x => x.Length <= pandigital - 2))
            {
                var multiplicandN = multiplicand.DigitsToNumber();
                foreach (var multiplier in GetMultipliers(multiplicand, pandigital))
                {
                    var multiplierN = multiplier.DigitsToNumber();
                    if (lhsHistory.Contains(Tuple.Create(multiplierN, multiplicandN))) continue;
                    
                    var product = multiplicandN * multiplierN;
                    var productDigits = MiscUtils.GetDigits(product).ToArray();

                    var equationDigits = multiplicand.Concat(multiplier).Concat(productDigits).ToArray();

                    var isPandigitalProduct = equationDigits.Length == pandigital
                                              && equationDigits.Distinct().Count() == pandigital
                                              && digits.IsSubsetOf(equationDigits);
                    if (isPandigitalProduct)
                    {
                        yield return
                            new ProductEquation
                            {
                                Multiplicand = multiplicandN,
                                Multiplier = multiplierN,
                                Product = product
                            };

                        lhsHistory.Add(Tuple.Create(multiplicandN, multiplierN));
                    }
                }
            }
        }

        public static IEnumerable<int[]> GetMultipliers(int[] multiplicand, int pandigital)
        {
            var digitSet = new HashSet<int>(Enumerable.Range(1, pandigital)).Except(multiplicand);

            var upper = (pandigital + 1) / 2 - multiplicand.Length;
            var lower = (int)Math.Max(1, Math.Floor((double)pandigital / 2) - multiplicand.Length);

            if (upper < lower) return new int[0][];

            var windowRange = Enumerable.Range(lower, upper - lower + 1);

            return windowRange.SelectMany(w => digitSet.Choose(w).SelectMany(SetUtils.Permutations));
        }

        public static IEnumerable<int[]> PandigitalNumbers(int pandigital)
        {
            return SetUtils.Permutations(Enumerable.Range(1, pandigital));
        }

        public static IEnumerable<int[]> DistinctNumbers()
        {
            var i = 1;
            while (true)
            {
                var digits = MiscUtils.GetDigits(i).ToArray();
                if (AreDistinct(digits)) yield return digits;
                i++;
            }
        }

        public static bool AreDistinct(int[] digits)
        {
            return digits.Distinct().Count() == digits.Count();
        }
    }

    public class ProductEquation
    {
        public int Multiplicand { get; set; }
        public int Multiplier { get; set; }
        public int Product { get; set; }
    }
}
