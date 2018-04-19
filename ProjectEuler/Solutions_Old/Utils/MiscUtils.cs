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
        public static IEnumerable<int> GetDigits(int n, int b = 10)
        {
            return GetDigits((long)n, b);
        }
        public static IEnumerable<int> GetDigits(long n, int b = 10)
        {
            while (n >= 1)
            {
                var digit = n % b;
                n /= b;
                yield return (int)digit;
            }
        }

        public static IEnumerable<int> GetDigits(this BigInteger n, int b = 10)
        {
            while (n >= 1)
            {
                var digit = n % b;
                n /= b;
                yield return (int)digit;
            }
        }

        public static int DigitsToNumber(this IEnumerable<int> digits)
        {
            return (int) digits.Select((x, i) => new {x, i}).Sum(p => Math.Pow(10, p.i) * p.x);
        }

        public static long DigitsToNumber(this IEnumerable<long> digits)
        {
            return (long)digits.Select((x, i) => new { x, i }).Sum(p => Math.Pow(10, p.i) * p.x);
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
