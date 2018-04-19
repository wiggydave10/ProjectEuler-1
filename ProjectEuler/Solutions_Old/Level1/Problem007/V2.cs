using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Problem007
{
    public static class V2
    {
        public static long NthPrime(int n)
        {
            var primes = new List<int>();
            var curr = 1;
            while (n > 0)
            {
                if (!IsCoprimeOf(++curr, primes)) continue;
                n--;
                primes.Add(curr);
            }

            return curr;
        }

        private static bool IsCoprimeOf(int x, IEnumerable<int> ns)
        {
            return ns.All(i => x % i != 0);
        }
    }
}
