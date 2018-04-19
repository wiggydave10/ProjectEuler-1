using System.Collections.Generic;
using System.Linq;
using Solutions.Utils;

namespace Solutions.Problem034
{
    /*
        Digit factorials

        145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.

        Find the sum of all numbers which are equal to the sum of the factorial of their digits.

        Note: as 1! = 1 and 2! = 2 are not sums they are not included.
    */
    public static class V1
    {
        public static IEnumerable<int> Get()
        {
            var factorials = Factorials(10).ToArray();
            for (var i = 10; i < 100000; i++)
            {
                if (MiscUtils.GetDigits(i).Sum(d => factorials[d]) == i)
                {
                    yield return i;
                }
            }
        }

        public static IEnumerable<int> Factorials(int n)
        {
            var fac = 1;
            for (var i = 1; i <= n; i++)
            {
                yield return fac;

                fac *= i;
            }
        }
    }
}
