using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static Tuple<Variable, double> Resolve(Equation eq)
        {
            var variables = eq.Variables;
            if (!variables.Any()) return null;

            if (variables.Distinct().Count() > 1) throw new Exception($"Can't resolve equation, too many unknowns: {eq}");

            var variable = variables[0];
            return Tuple.Create(variable.GetSingle(), eq.Get(variable).Resolve());
        }

        public static string ToSubstring(int x)
        {
            return new string(x.ToString().Select(c => (char) ('₀' + c - '0')).ToArray());
        }
    }

    public class Equation
    {
        public Equation(Expression lhs, Expression rhs)
        {
            Lhs = lhs;
            Rhs = rhs;
        }

        public Expression Lhs { get; set; }
        public Expression Rhs { get; set; }

        public Variable[] Variables => Lhs.Variables.Concat(Rhs.Variables).ToArray();

        public Expression Get(Variable v)
        {
            var eq = this - Rhs;
            var others = eq.Lhs.Where(n => !v.Equals(n)).ToList();
            others.ForEach(n => eq.Lhs.Remove(n));
            eq.Rhs.AddRange(others.Select(n => n.Minus()));
            if (!eq.Lhs.Any())
            {
                eq.Rhs.Remove(v);
                eq.Lhs.Add(v.Minus());
            }

            eq.Divide(((Variable)eq.Lhs.First()).Coefficient);
            return eq.Rhs;
        }

        public void Divide(double x)
        {
            Lhs /= x;
            Rhs /= x;
        }

        public Equation Clone()
        {
            return new Equation(Lhs.Clone(), Rhs.Clone());
        }

        public override string ToString()
        {
            return $"{Lhs} = {Rhs}";
        }

        public static Equation operator -(Equation eq, Expression ex)
        {
            return new Equation(eq.Lhs - ex, eq.Rhs - ex);
        }
    }

    public class Expression : List<Number>
    {
        public Expression() : base(new List<Number>())
        {
        }

        public Expression(IEnumerable<Number> ns) : base(ns)
        {
        }

        public Expression(Number n) : base(new List<Number> {n})
        {
        }

        public bool Resolvable => this.All(n => n.GetType() == typeof(Constant));

        public double Resolve()
        {
            if (!Resolvable) throw new Exception($"Can't resolve expression: {ToString()}");
            return this.Select(n => (Constant) n).Aggregate((a, b) => a + b).Value;
        }

        public Expression Clone()
        {
            return new Expression(this.Select(n => n.Clone()).ToList());
        }

        public Variable[] Variables => this.Where(n => n.GetType() == typeof(Variable)).Select(n => (Variable)n).ToArray();
        public Constant[] Constants => this.Where(n => n.GetType() == typeof(Constant)).Select(n => (Constant)n).ToArray();

        private Expression Reduce()
        {
            var reducedConstant = new Constant(Constants.Select(c => c.Value).Sum());

            var reducedVariables = Variables.GroupBy(v => v.Id).Select(g => new Variable(g.Key, g.Select(v => v.Coefficient).Sum()));
            this.Clear();
            var reduced = reducedVariables.Select(v => (Number) v).Concat(new[] {reducedConstant})
                .Where(n => n.GetType() == typeof(Variable) && ((Variable) n).Coefficient != 0
                            || n.GetType() == typeof(Constant) && ((Constant) n).Value != 0);
            this.AddRange(reduced);

            return this;
        }

        public override string ToString()
        {
            return string.Join(" + ", this);
        }

        public static Expression operator /(Expression ex, double d)
        {
            return new Expression(ex.Select(n => n / d).ToList());
        }

        public static Expression operator *(Expression ex, double d)
        {
            return new Expression(ex.Select(n => n * d).ToList());
        }

        public static Expression operator +(Expression ex, Number n)
        {
            return new Expression(ex.Concat(new[] { n })).Reduce();
        }

        public static Expression operator -(Expression ex, Number n)
        {
            return new Expression(ex.Concat(new[] { n.Minus() })).Reduce();
        }

        public static Expression operator -(Expression ex1, Expression ex2)
        {
            return new Expression(ex1.Concat(ex2 * -1)).Reduce();
        }
    }

    public class Variable : Number
    {
        public double Coefficient;
        public readonly int Id;

        public Variable(int id, double coefficient)
        {
            this.Coefficient = coefficient;
            this.Id = id;
        }

        public Variable GetSingle()
        {
            return new Variable(Id, 1);
        }

        public Constant Resolve(double value)
        {
            return new Constant(Coefficient * value);
        }

        public override Number Clone()
        {
            return new Variable(Id, Coefficient);
        }

        public override Number Minus()
        {
            Coefficient = -Coefficient;
            return this;
        }

        public override string ToString()
        {
            var coStr = Coefficient == 1 ? string.Empty : Coefficient.ToString("F");
            return $"{coStr}X{Series.ToSubstring(Id)}";
        }

        public override bool Equals(object obj)
        {
            return obj?.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static Expression operator +(Variable v1, Variable v2)
        {
            if (v1.Id == v2.Id)
            {
                return new Expression(new Variable(v1.Id, v1.Coefficient + v2.Coefficient));
            }
            return new Expression(new [] {v1, v2});
        }
    }

    public class Constant : Number
    {
        public Constant()
        {
            Value = 0;
        }

        public Constant(double value)
        {
            Value = value;
        }

        public double Value { get; set; }

        public override Number Clone()
        {
            return new Constant(Value);
        }

        public override Number Minus()
        {
            Value = -Value;
            return this;
        }

        public override string ToString()
        {
            return Value.ToString("F");
        }

        public static Constant operator +(Constant c1, Constant c2)
        {
            return new Constant(c1.Value + c2.Value);
        }
    }

    public abstract class Number
    {
        public abstract Number Clone();
        public abstract Number Minus();

        public static Number operator /(Number v1, double x)
        {
            var clone = v1.Clone();
            if (v1.GetType() == typeof(Variable))
            {
                var cloneV = (Variable) clone;
                cloneV.Coefficient /= x;
                return cloneV;

            }

            var cloneC = (Constant)clone;
            cloneC.Value /= x;
            return cloneC;
        }

        public static Number operator *(Number v1, double x)
        {
            var clone = v1.Clone();
            if (v1.GetType() == typeof(Variable))
            {
                var cloneV = (Variable)clone;
                cloneV.Coefficient *= x;
                return cloneV;

            }

            var cloneC = (Constant)clone;
            cloneC.Value *= x;
            return cloneC;
        }
    }
}
