using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Solutions.Utils;

namespace Solutions.Problem033
{
    /*
        Digit cancelling fractions

        The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may incorrectly believe that 
        49/98 = 4/8, which is correct, is obtained by cancelling the 9s.

        We shall consider fractions like, 30/50 = 3/5, to be trivial examples.

        There are exactly four non-trivial examples of this type of fraction, less than one in value, 
        and containing two digits in the numerator and denominator.

        If the product of these four fractions is given in its lowest common terms, find the value of the denominator.
    */
    public static class V1
    {
        public static IEnumerable<Fraction> Get()
        {
            for (var numerator = 10; numerator < 100; numerator++)
            {
                for (var denominator = numerator+1; denominator < 100; denominator++)
                {
                    if (numerator == denominator || !CanCancelDigits(numerator, denominator)) continue;

                    yield return new Fraction
                    {
                        Numerator = numerator,
                        Denominator = denominator
                    };
                }
            }
        }

        public static bool CanCancelDigits(int numerator, int denominator)
        {
            var nDigits = MiscUtils.GetDigits(numerator).ToArray();
            var dDigits = MiscUtils.GetDigits(denominator).ToArray();

            var f = (decimal)numerator / denominator;

            for (var i = 0; i < nDigits.Length; i++)
            {
                for (var j = 0; j < dDigits.Length; j++)
                {
                    var nC = nDigits[i];
                    var dC = dDigits[j];

                    if (nC != dC || dC == 0) continue;

                    var d = dDigits[dDigits.Length - j - 1];
                    if (d == 0) continue;

                    var fC = (decimal)nDigits[nDigits.Length - i - 1] / d;

                    if (f == fC) return true;
                }
            }

            return false;
        }
    }

    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return new Fraction
            {
                Numerator = f1.Numerator * f2.Numerator,
                Denominator = f1.Denominator * f2.Denominator
            };
        }
    }
}
