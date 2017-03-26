using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Utils.MathematicalObjects
{
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
            return new Expression(new[] { v1, v2 });
        }
    }
}
