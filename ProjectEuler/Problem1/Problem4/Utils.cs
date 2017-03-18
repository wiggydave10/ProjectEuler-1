using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Problem4
{
    public static class Utils
    {
        public static bool IsPalendrome(long n)
        {
            var digits = GetDigits(n).ToArray();
            return Enumerable.Range(0, digits.Length / 2).All(i => digits.ElementAt(i) == digits.ElementAt(digits.Length - (i + 1)));
        }

        public static IEnumerable<int> GetDigits(long n)
        {
            while (n >= 1)
            {
                var digit = n % 10;
                n /= 10;
                yield return (int)digit;
            }
        }

        public static IEnumerable<Tuple<int,int>> DecreasingProductOrder(int n)
        {
            int j;
            var xMarker = j = n;
            var xChange = false;
            for (var i = n; i > 0; i--)
            {
                yield return Tuple.Create(i, j);
                if (j == n)
                {
                    if (xChange)
                    {
                        i = xMarker--;
                        j = xMarker;
                    }
                    else
                    {
                        i = xMarker;
                        j = xMarker;
                    }
                    xChange = !xChange;
                }
                else
                {
                    j++;
                }
            }
        }
    }
}
