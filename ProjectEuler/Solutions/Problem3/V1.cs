using System.Collections.Generic;
using System.Linq;

namespace Solutions.Problem3
{
    public static class V1
    {
        public static int LargestPrimeFactor(long n)
        {
            return Utils.PrimeFactors(n).Max();
        }
    }
}
