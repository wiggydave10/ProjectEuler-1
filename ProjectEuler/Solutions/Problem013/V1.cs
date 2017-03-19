using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Problem013
{
    public static class V1
    {
        public static IEnumerable<int> FirstNDigitsOfLargeSum(int n, int[][] xs)
        {
            return xs.Aggregate(Add).Take(n);
        }

        private static int[] Add(int[] a, int[] b)
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
