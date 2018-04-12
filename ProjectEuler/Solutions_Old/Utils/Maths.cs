using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Utils
{
    public static class Maths
    {
        public static int Sum(int n, int i, Func<int, int> fn)
        {
            return Enumerable.Range(i, n - 1).Sum(fn);
        }

        public static int Product(int n, int i, Func<int, int> fn)
        {
            return Enumerable.Range(i, n - 1).Product(fn);
        }

        public static Func<int, double> Polynomial(params double[] coefficients)
        {
            var order = coefficients.Length - 1;
            return n => coefficients.Sum((c, i) => c * Math.Pow(n, order - i));
        }
    }
}
