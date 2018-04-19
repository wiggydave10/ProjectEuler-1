using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.Problem009
{
    public static class V1
    {
        public static long Answer()
        {
            var sqs = new SortedSet<long>(Squares().TakeWhile((s,i) => i < 1000));
            for (var i = 0; i < sqs.Count; i++)
            {
                var a = sqs.ElementAt(i);
                for (var j = i+1; j < sqs.Count; j++)
                {
                    var b = sqs.ElementAt(j);
                    var c = a + b;
                    if (sqs.Contains(c) && IsTarget(a, b, c))
                    {
                        return (long)(Math.Sqrt(a)*Math.Sqrt(b)*Math.Sqrt(c));
                    } 
                }
            }

            // shouldn't get here
            return 0;
        }

        private static bool IsTarget(long aSqr, long bSqr, long cSqr)
        {
            return (int)Math.Sqrt(aSqr) + (int)Math.Sqrt(bSqr) + (int)Math.Sqrt(cSqr) == 1000;
        }

        private static IEnumerable<long> Squares()
        {
            var i = 2;
            while (true)
            {
                yield return i*i;
                i++;
            }
        }

        private static bool IsInteger(double d)
        {
            return Math.Abs(d%1) <= (Double.Epsilon*100);
        }
    }
}
