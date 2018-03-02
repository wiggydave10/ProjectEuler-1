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

namespace Solutions.Problem050
{
    /*
        Consecutive prime sum
        Problem 50 
        The prime 41, can be written as the sum of six consecutive primes:

        41 = 2 + 3 + 5 + 7 + 11 + 13
        This is the longest sum of consecutive primes that adds to a prime below one-hundred.

        The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.

        Which prime, below one-million, can be written as the sum of the most consecutive primes?
    */

    public static class V1
    {
        public static IEnumerable<string> Main()
        {
            return null;
        }

        public static long MaxConsecutivePrimeSum(IEnumerable<long> primes)
        {
            var arr = primes.ToArray();
            var primeSet = new SortedSet<long>(arr);
            var max = primeSet.Max;

            var sum = 0L;
            var i = 0;
            foreach (var prime in arr)
            {
                if (sum > max) break;
                sum += prime;
                i++;
            }

            for (; i >= 0; i--)
            {
                var maxSum = 0L;
                foreach (var window in arr.GetWindows(i))
                {
                    var sum2 = window.Sum();
                    if (sum2 > max) break;

                    if (primeSet.Contains(sum2))
                    {
                        return sum2;
                    }
                }
            }

            // shouldn't normally get here
            return 0;
        }
    }
}
