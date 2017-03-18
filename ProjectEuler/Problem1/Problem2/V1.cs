using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Problem2
{
    public static class V1
    {
        public static long SumEvenFib(int n)
        {
            return Fib(n).TakeWhile(x => x < 4000000).Where(x => x%2 == 0).Sum();
        }

        private static IEnumerable<long> Fib(int n)
        {
            long fst = 0;
            long snd = 1;

            while (n-- > 0)
            {
                var tempSnd = snd;
                snd = fst + snd;
                fst = tempSnd;
                yield return snd;
            }
        }
    }
}
