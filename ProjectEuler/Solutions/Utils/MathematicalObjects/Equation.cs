using System.Linq;

namespace Solutions.Utils.MathematicalObjects
{
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
            eq.Rhs.AddRange(others.Select(n => n * -1));
            if (!eq.Lhs.Any())
            {
                eq.Rhs.Remove(v);
                eq.Lhs.Add(v * -1);
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
}
