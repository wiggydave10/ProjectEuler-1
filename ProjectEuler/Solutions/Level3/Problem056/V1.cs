using System;
using System.Linq;
using System.Numerics;
using Solutions.Utils;

namespace Solutions.Problem056
{
    /*
        Powerful digit sum
        Problem 56 
        A googol (10^100) is a massive number: one followed by one-hundred zeros; 100^100 is almost unimaginably large: one followed by two-hundred zeros. Despite their size, the sum of the digits in each number is only 1.

        Considering natural numbers of the form, a^b, where a, b < 100, what is the maximum digital sum?
    */

    public static class V1
    {
        public static int MaximalDigitSum(int limit)
        {
            var maxDigitSum = 0;
            for (var i = new BigInteger(1); i < limit; i++)
            {
                for (var j = 1; j < limit; j++)
                {
                    var digitSum = BigInteger.Pow(i, j).GetDigits().Sum();
                    maxDigitSum = Math.Max(maxDigitSum, digitSum);
                }
            }

            return maxDigitSum;
        }
    }
}
