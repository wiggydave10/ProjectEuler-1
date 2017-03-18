using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Problem4
{
    public static class V1
    {
        public static long LargestPalindrome(int nDigits)
        {
            var maxNDigitNumber = (int) Math.Pow(10, nDigits) - 1;

            foreach (var pair in Utils.DecreasingProductOrder(maxNDigitNumber))
            {
                var product = pair.Item1*pair.Item2;
                if (Utils.IsPalendrome(product)) return product;
            }

            // shouldn't ever get here
            return 0;
        }
    }
}
