using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.Problem026
{
    public static class V1
    {
        /*
            Reciprocal cycles
            Problem 26 
            A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:

            1/2	= 	0.5
            1/3	= 	0.(3)
            1/4	= 	0.25
            1/5	= 	0.2
            1/6	= 	0.1(6)
            1/7	= 	0.(142857)
            1/8	= 	0.125
            1/9	= 	0.(1)
            1/10	= 	0.1
            Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.

            Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
        */

        public static int UnitFractionBase10LongestCycle(int limit)
        {
            var maxN = Tuple.Create(1, 0);
            for (var i = 2; i < limit; i++)
            {
                var count = UnitFractionCycle(i).Length;
                if (count > maxN.Item2) maxN = Tuple.Create(i, count);
            }

            return maxN.Item1;
        }

        public static int[] UnitFractionCycle(int n)
        {
            var history = new List<Tuple<int,int>>();
            var remainder = 1;
            while (remainder != 0)
            {
                if (n > remainder)
                {
                    remainder *= 10;
                    continue;
                }
                var d = remainder / n;
                var nextR = remainder % n;
                var historyTuple = Tuple.Create(d, nextR);
                var historyIndex = history.IndexOf(historyTuple);
                if (historyIndex > -1) return history.Skip(historyIndex).Select(h => h.Item1).ToArray();
                history.Add(historyTuple);
                remainder = nextR;
            }

            return new int[0];
        }
    }
}
