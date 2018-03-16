using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Solutions.Utils;

namespace Solutions.Problem040
{
    /*
        Champernowne's constant
        Problem 40 
        An irrational decimal fraction is created by concatenating the positive integers:

        0.123456789101112131415161718192021...

        It can be seen that the 12th digit of the fractional part is 1.

        If dn represents the nth digit of the fractional part, find the value of the following expression.

        d1 × d10 × d100 × d1000 × d10000 × d100000 × d1000000
    */
    public static class V1
    {
        public static int Get()
        {
            var fractionDigits = ChampernownesSequence(1000000).ToArray();
            var fractionalParts = Enumerable.Range(0, 7).Select(x => (int) Math.Pow(10, x) - 1).ToArray();

            return fractionalParts.Product(i => fractionDigits[i]);
        }

        public static IEnumerable<int> ChampernownesSequence(int limit)
        {
            return Enumerable.Range(1, limit).SelectMany(i => MiscUtils.GetDigits(i).Reverse());
        }
    }
}
