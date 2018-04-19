using System.Linq;

namespace Solutions.Problem003
{
    public static class V1
    {
        public static int LargestPrimeFactor(long n)
        {
            return Utils.PrimeFactors(n).Max();
        }
    }
}
