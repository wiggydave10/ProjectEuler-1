using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Solutions.Utils;

namespace Solutions.Problem041
{
    /*
        Pandigital prime
        Problem 41 
        We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. 
        For example, 2143 is a 4-digit pandigital and is also prime.

        What is the largest n-digit pandigital prime that exists?
    */
    public static class V1
    {
        public static long Get()
        {
            var pandigit = 9;
            var prime = 0;
            while (prime == 0)
            {
                var arr = SetUtils.LexicographicPermutations(Enumerable.Range(1, pandigit--))
                    .Select(x => x.Reverse().DigitsToNumber())
                    .Reverse()
                    .ToArray();
                prime = arr.FirstOrDefault(x => PrimeUtils.IsPrime(x));
            }

            return prime;

        }
    }
}
