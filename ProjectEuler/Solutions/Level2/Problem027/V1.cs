using System;
using System.Linq;
using Solutions.Utils;

namespace Solutions.Problem027
{
    public static class V1
    {
        /*
            Quadratic primes
            Problem 27 
            Euler discovered the remarkable quadratic formula:

            n2+n+41
            It turns out that the formula will produce 40 primes for the consecutive integer values 0≤n≤39. However, when n=40,402+40+41=40(40+1)+41 is divisible by 41, and certainly when n=41,412+41+41 is clearly divisible by 41.

            The incredible formula n2−79n+1601 was discovered, which produces 80 primes for the consecutive values 0≤n≤79. The product of the coefficients, −79 and 1601, is −126479.

            Considering quadratics of the form:

            n^2+an+b, where |a|<1000 and |b|≤1000

            where |n| is the modulus/absolute value of n
            e.g. |11|=11 and |−4|=4
            Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n=0.
        */

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
