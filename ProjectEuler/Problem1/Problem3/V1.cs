using System.Collections.Generic;
using System.Linq;

namespace Solutions.Problem3
{
    public static class V1
    {
        public static int LargestPrimeFactor(long n)
        {
            return PrimeFactors(n).Max();
        }

        private static IEnumerable<int> PrimeFactors(long n)
        {
            foreach (var prime in Primes())
            {
                if (n == 1) yield break;
                if (n % prime != 0) continue;

                n = n / prime;
                yield return prime;
            }
        }

        private static IEnumerable<int> Primes()
        {
            int curr = 1;
            while (true)
            {
                curr++;
                if (IsPrime(curr)) yield return curr;
            }
        }

        private static bool IsPrime(int x)
        {
            return Enumerable.Range(2, x - 2).All(i => x%i != 0);
        }
    }
}
