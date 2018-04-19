using System;
using System.Collections.Generic;
using System.Linq;
using Solutions.Utils.MathematicalObjects;

namespace Solutions.Utils
{
    public static class Series
    {
        public static Func<int, double> FindPolynomial(int[] xs)
        {
            var order = FindPolynomialOrder(xs);
            if (order == null) return null;

            var coefficients = new double[order.Value + 1];
            coefficients[order.Value] = xs[0];

            return null;
        }

        public static int? FindPolynomialOrder(int[] xs)
        {
            var order = 0;
            while (xs.Any(x => x != xs[0]))
            {
                xs = GetDifferences(xs);
                order++;
            }

            return xs.Length > 1 ? order : (int?)null;
        }

        private static int[] GetDifferences(int[] xs)
        {
            var differences = new int[xs.Length - 1];
            for (var i = 0; i < differences.Length; i++)
            {
                differences[i] = xs[i + 1] - xs[i];
            }

            return differences;
        }

        public static void Resolve()
        {
            var c1 = new Constant(3);
            var c2 = new Constant(6);
            var c3 = new Constant(11);
            var a = new Variable(1, 1);
            var b = new Variable(2, 1);

            var lhs1 = new Expression(c1);
            var rhs1 = new Expression(new [] { (Number)c2, a * -1, b * -1 });
            var eq1 = new Equation(lhs1, rhs1);

            var lhs2 = new Expression(c1);
            var rhs2 = new Expression(new[] { (Number)c3, a * -4, b * -2 });
            var eq2 = new Equation(lhs2, rhs2);

            var ex1 = eq1.Get(a);
            var ex2 = eq2.Get(a);

            var eq3 = new Equation(ex1, ex2);

            var x = Resolve(eq3);
        }

        public static Dictionary<Variable, double> Resolve(Equation[] es)
        {
            var resolved = es.Where(e => e.Variables.Distinct().Count() == 1)
                .ToDictionary(e => e.Variables[0].GetSingle(), e => e.Get(e.Variables[0]).Resolve());

            var variables = es.SelectMany(e => e.Variables).Distinct();
            foreach (var variable in variables)
            {
                var ves = es.Where(e => e.Variables.Contains(variable));

            }

            return resolved;
        }

        public static Tuple<Variable, double> Resolve(Equation equation)
        {
            var variables = equation.Variables;
            if (!variables.Any()) return null;

            if (variables.Distinct().Count() > 1) throw new Exception($"Can't resolve equation, too many unknowns: {equation}");

            var variable = variables[0];
            return Tuple.Create(variable.GetSingle(), equation.Get(variable).Resolve());
        }

        public static string ToSubstring(int x)
        {
            return new string(x.ToString().Select(c => (char) ('₀' + c - '0')).ToArray());
        }
    }
}
