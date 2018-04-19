using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Solutions.Utils;

namespace Solutions.Problem053
{
    /*
        Combinatoric selections
        Problem 53 
        There are exactly ten ways of selecting three from five, 12345:

        123, 124, 125, 134, 135, 145, 234, 235, 245, and 345

        In combinatorics, we use the notation, 5C3 = 10.

        In general,

        nCr = n! / r!(n−r)! ,where r ≤ n, n! = n×(n−1)×...×3×2×1, and 0! = 1.
        It is not until n = 23, that a value exceeds one-million: 23C10 = 1144066.

        How many, not necessarily distinct, values of  nCr, for 1 ≤ n ≤ 100, are greater than one-million?
    */

    public static class V1
    {
        public static IEnumerable<double> Main(int limit)
        {
            for (var n = 1; n <= limit; n++)
            {
                for (var r = 1; r <= n; r++)
                {
                    yield return Factorial(n) / (Factorial(r) * Factorial(n - r));
                }
            }
        }

        public static double Factorial(int n)
        {
            double ret = 1;
            while (n > 1)
            {
                ret *= n;
                n--;
            }

            return ret;
        }
    }
}
