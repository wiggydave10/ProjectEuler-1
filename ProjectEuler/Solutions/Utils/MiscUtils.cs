using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Utils
{
    public static class MiscUtils
    {
        public static IEnumerable<int> GetDigits(int n)
        {
            return GetDigits((long)n);
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

        public static IEnumerable<int> GetDigits(this BigInteger n)
        {
            while (n >= 1)
            {
                var digit = n % 10;
                n /= 10;
                yield return (int)digit;
            }
        }

        public static int DigitsToNumber(this IEnumerable<int> digits)
        {
            return (int) digits.Select((x, i) => new {x, i}).Sum(p => Math.Pow(10, p.i) * p.x);
        }

        public static int[] Add(int[] a, int[] b)
        {
            var rSmaller = (a.Length < b.Length) ? a.Reverse().ToArray() : b.Reverse().ToArray();
            var rBigger = (a.Length < b.Length) ? b.Reverse().ToArray() : a.Reverse().ToArray();

            var res = new List<int>();
            var carry = 0;
            for (var i = 0; i < rSmaller.Length; i++)
            {
                var sum = rSmaller[i] + rBigger[i] + carry;

                res.Add(sum % 10);
                carry = sum >= 10 ? 1 : 0;
            }

            foreach (var x in rBigger.Skip(rSmaller.Length))
            {
                var sum = x + carry;
                res.Add(sum % 10);
                carry = sum >= 10 ? 1 : 0;
            }

            if (carry == 1) res.Add(1);

            res.Reverse();
            return res.ToArray();
        }
    }
}
