using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Solutions.Utils;

namespace Solutions.Problem030
{
    public static class V1
    {
        /*
            Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:

            1634 = 1^4 + 6^4 + 3^4 + 4^4
            8208 = 8^4 + 2^4 + 0^4 + 8^4
            9474 = 9^4 + 4^4 + 7^4 + 4^4
            As 1 = 1^4 is not a sum it is not included.

            The sum of these numbers is 1634 + 8208 + 9474 = 19316.

            Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
        */

        public static int DigitPowers(int power, int gapLimit)
        {
            var specials = new List<int>();
            var n = 2;
            while (!specials.Any() || n - specials.Last() < gapLimit)
            {
                if (IsSpecial(n, power)) specials.Add(n);
                n++;
            }

            return specials.Sum();
        }

        public static bool IsSpecial(long n, int power)
        {
            return Math.Abs(MiscUtils.GetDigits(n).Sum(x => Math.Pow(x, power)) - n) < Double.Epsilon;
        }
    }
}
