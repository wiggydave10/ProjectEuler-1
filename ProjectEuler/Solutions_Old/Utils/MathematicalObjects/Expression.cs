using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Utils.MathematicalObjects
{
    public class Expression : List<Number>
    {
        public Expression() : base(new List<Number>())
        {
        }

        public Expression(IEnumerable<Number> ns) : base(ns)
        {
        }

        public Expression(Number n) : base(new List<Number> { n })
        {
        }

        public bool Resolvable => this.All(n => n.GetType() == typeof(Constant));

        public double Resolve()
        {
            if (!Resolvable) throw new Exception($"Can't resolve expression: {ToString()}");
            return this.Select(n => (Constant)n).Aggregate((a, b) => a + b).Value;
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
            var reduced = reducedVariables.Select(v => (Number)v).Concat(new[] { reducedConstant })
                .Where(n => n.GetType() == typeof(Variable) && ((Variable)n).Coefficient != 0
                            || n.GetType() == typeof(Constant) && ((Constant)n).Value != 0);
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
            return new Expression(ex.Concat(new[] { n * -1 })).Reduce();
        }

        public static Expression operator -(Expression ex1, Expression ex2)
        {
            return new Expression(ex1.Concat(ex2 * -1)).Reduce();
        }
    }
}
