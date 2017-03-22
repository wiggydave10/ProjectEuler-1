using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;
using Solutions.Utils;

namespace Solutions.Problem025
{
    public static class V1
    {
        public static int FibIndexWithGreaterThanNDigits(int n)
        {
            var i = 1;
            foreach (var f in Fib())
            {
                if (f.GetDigits().Count() == n) return i;
                i++;
            }

            // wont get here
            return 0;
        }

        public static IEnumerable<BigInteger> Fib()
        {
            BigInteger fst = 1;
            BigInteger snd = 1;
            while (true)
            {
                yield return fst;
                var temp = fst;
                fst = snd;
                snd = fst + temp;
            }
        }

    }
}
