using System.Linq;
using System.Numerics;
using Solutions.Utils;

namespace Solutions.Problem020
{
    public static class V1
    {
        public static int FactorialDigitCount(int n)
        {
            var x = new BigInteger(n);
            while (--n > 0)
            {
                x *= n;
            }

            return x.GetDigits().Sum();
        }
    }
}