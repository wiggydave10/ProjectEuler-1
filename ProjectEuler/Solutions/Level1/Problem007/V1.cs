
using System.Linq;

namespace Solutions.Problem007
{
    public static class V1
    {
        public static long NthPrime(int n)
        {
            int curr = 1;
            while (n > 0)
            {
                curr++;
                if (IsPrime(curr)) n--;
            }

            return curr;
        }

        private static bool IsPrime(int x)
        {
            return Enumerable.Range(2, x - 2).All(i => x % i != 0);
        }
    }
}
