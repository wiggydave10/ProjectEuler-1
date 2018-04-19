using System;

namespace Solutions.Utils.MathematicalObjects
{
    class Polynomial
    {
        private double[] coefficients;

        public Polynomial(int order)
        {
            coefficients = new double[order + 1];
        }

        public Polynomial(params double[] coefficients)
        {
            this.coefficients = coefficients;
        }

        public int Order => coefficients.Length - 1;

        public double Call(int n) => coefficients.Sum((c, i) => c * Math.Pow(n, Order - i));
    }
}
