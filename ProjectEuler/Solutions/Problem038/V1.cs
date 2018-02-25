using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Solutions.Utils;

namespace Solutions.Problem038
{
    /*
        Pandigital multiples
        Problem 38 
        Take the number 192 and multiply it by each of 1, 2, and 3:

        192 × 1 = 192
        192 × 2 = 384
        192 × 3 = 576
        By concatenating each product we get the 1 to 9 pandigital, 192384576. We will call 192384576 the concatenated product of 192 and (1,2,3)

        The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and 5, giving the pandigital, 918273645, 
        which is the concatenated product of 9 and (1,2,3,4,5).

        What is the largest 1 to 9 pandigital 9-digit number that can be formed as the concatenated product of an integer with (1,2, ... , n) where n > 1?
    */
    public static class V1
    {
        // As multipliers are added in order starting with 1, the first digit of the multiplicand has to be 9
        public static int Get()
        {
            var largest = 0;

            for (var i = 10; i < 10000; i *= 10)
            {
                for (var j = 0; j < i; j++)
                {
                    var multiplicand = 9 * i + j;
                    var product = LargestProduct(multiplicand);

                    largest = Math.Max(largest, product ?? 0);                   
                }
            }

            return largest;
        }

        public static int? LargestProduct(int n)
        {
            var multiplier = 3;
            var productDigits = ConcatenatedProduct(n, new []{1,2});

            while (productDigits.Length <= 9)
            {
                if (productDigits.Distinct().Count() != productDigits.Length || productDigits.Any(d => d == 0)) break;
                if (productDigits.Length == 9)
                {
                    return productDigits.DigitsToNumber();
                }

                productDigits = MiscUtils.GetDigits(n * multiplier++).Concat(productDigits).ToArray();
            }

            return null;
        }

        public static int[] ConcatenatedProduct(int n, IEnumerable<int> multipliers)
        {
            return multipliers
                .OrderBy(m => m)
                .Select(m => n * m)
                .Select(x => MiscUtils.GetDigits(x))
                .Aggregate((a, b) => b.Concat(a))
                .ToArray();
        }
    }
}
