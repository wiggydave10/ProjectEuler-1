using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Solutions.Problem025
{
    public static class V1
    {
        public static int FibIndexWithGreaterThanNDigits(int n)
        {
            return Fib()
                .Select((x, i) => new {n = x.ToString().Length, i})
                .First(x => x.n == n).i + 1;
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
