using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Solutions.Utils;

namespace Solutions.Problem036
{
    /*
        Double-base palindromes

        The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.

        Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.

        (Please note that the palindromic number, in either base, may not include leading zeros.)
    */
    public static class V1
    {
        public static IEnumerable<int> Get(int n)
        {
            return Enumerable.Range(1, n)
                    .Where(x => IsPalindromic(MiscUtils.GetDigits(x)) && IsPalindromic(MiscUtils.GetDigits(x, 2)));
        }

        public static bool IsPalindromic(IEnumerable<int> e)
        {
            var xs = e.ToArray();
            return xs.Any()
                   && xs.First() != 0
                   && xs.Take(xs.Length / 2).SequenceEqual(xs.Skip((xs.Length + 1) / 2).Reverse());
        }
    }
}
