﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Solutions.Utils;

namespace Solutions.Problem044
{
    /*
        Pentagon numbers
        Problem 44 
        Pentagonal numbers are generated by the formula, Pn=n(3n−1)/2. The first ten pentagonal numbers are:

        1, 5, 12, 22, 35, 51, 70, 92, 117, 145, ...

        It can be seen that P4 + P7 = 22 + 70 = 92 = P8. However, their difference, 70 − 22 = 48, is not pentagonal.

        Find the pair of pentagonal numbers, Pj and Pk, for which their sum and difference are pentagonal and D = |Pk − Pj| is minimised; what is the value of D?
    */
    public static class V1
    {
        public static long Get()
        {
            var minDiff = long.MaxValue;
            var pentagons = new SortedSet<long>();
            var n = 1;
            while (true)
            {
                var pentagon = PentagonNumber(n++);
                foreach (var p2 in pentagons.Reverse().Where(x => x < pentagon).ToArray())
                {
                    var sum = pentagon + p2;
                    var dif = pentagon - p2;

                    if (dif > minDiff) break;

                    var n2 = n + 1;
                    while (sum > pentagons.Max) pentagons.Add(PentagonNumber(n2++));

                    if (dif < minDiff && pentagons.Contains(sum) && pentagons.Contains(dif))
                    {
                        return dif;
                    }
                }

                pentagons.Add(pentagon);
            }

            return 0;
        }

        public static long PentagonNumber(long n)
        {
            return n * (3 * n - 1) / 2;
        }
    }
}
