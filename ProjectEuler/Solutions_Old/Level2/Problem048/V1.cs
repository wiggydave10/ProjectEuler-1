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

namespace Solutions.Problem048
{
    /*
        Self powers
        Problem 48 
        The series, 1^1 + 2^2 + 3^3 + ... + 10^10 = 10405071317.

        Find the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000.
    */

    public static class V1
    {
        public static long Main(int digits, int limit)
        {
            var window = (long) Math.Pow(10, digits);
            var lastDigits = 0L;

            for (var i = 1; i <= limit; i++)
            {
                var d = (i < window) ? i : i % window;
                var dd = 1L;
                for (var j = 0; j < i; j++)
                {
                    dd *= d;
                    dd %= window;
                }
                lastDigits += dd;
                lastDigits %= window;
            }

            return lastDigits % window;
        }
    }
}
