using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solutions.Utils;

namespace Solutions.Problem027
{
    public static class V1
    {
        public static int QuadraticPrimes(int limit)
        {
            var maxCoefficients = Tuple.Create(0, 0, 0L);
            for (var i = -limit; i < limit; i++)
            {
                for (var j = -limit; j <= limit; j++)
                {
                    var count = QuadraticPrimeCount(i, j);
                    if (count > maxCoefficients.Item3)
                    {
                        maxCoefficients = Tuple.Create(i, j, count);
                    }
                }
            }
            return maxCoefficients.Item1 * maxCoefficients.Item2;
        }

        public static long QuadraticPrimeCount(int a, int b)
        {
            return InfiniteSet.NaturalNumbers(true).SkipWhile(n => PrimeUtils.IsPrime(n*n + a*n + b)).First();
        }
    }
}
