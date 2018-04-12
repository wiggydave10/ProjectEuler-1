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

namespace Solutions.Problem057
{
    /*
        Square root convergents
        Problem 57 
        It is possible to show that the square root of two can be expressed as an infinite continued fraction.

        √ 2 = 1 + 1/(2 + 1/(2 + 1/(2 + ... ))) = 1.414213...

        By expanding this for the first four iterations, we get:

        1 + 1/2 = 3/2 = 1.5
        1 + 1/(2 + 1/2) = 7/5 = 1.4
        1 + 1/(2 + 1/(2 + 1/2)) = 17/12 = 1.41666...
        1 + 1/(2 + 1/(2 + 1/(2 + 1/2))) = 41/29 = 1.41379...

        The next three expansions are 99/70, 239/169, and 577/408, but the eighth expansion, 1393/985, is the first example where the number of digits in the numerator exceeds the number of digits in the denominator.

        In the first one-thousand expansions, how many fractions contain a numerator with more digits than denominator?
    */

    public static class V1
    {
        public static bool Condition(Fraction f)
        {
            return f.Numerator.ToString().Length > f.Denominator.ToString().Length;
        }

        public static Fraction Expansion(int n)
        {
            return 1 + ExpansionHelper(n);
        }

        private static Fraction ExpansionHelper(int depth)
        {
            if (depth == 0) return new Fraction(1, 2);

            return new Fraction(1, 2 + ExpansionHelper(depth - 1));
        }
    }

    public struct Fraction
    {
        public Fraction(long numerator, long denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction(BigInteger numerator, BigInteger denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction(int numerator, Fraction denominator)
        {
            Numerator = numerator * denominator.Denominator;
            Denominator = denominator.Numerator;
        }

        public BigInteger Numerator { get; }
        public BigInteger Denominator { get; }

        public static Fraction operator +(int n, Fraction f)
        {
            return f + n;
        }

        public static Fraction operator +(Fraction f, int n)
        {
            return new Fraction(f.Numerator + n * f.Denominator, f.Denominator);
        }
    }
}
