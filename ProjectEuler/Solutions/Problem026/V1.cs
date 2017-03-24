using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Problem026
{
    public static class V1
    {
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
                var d = remainder/n;
                var nextR = remainder%n;
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
