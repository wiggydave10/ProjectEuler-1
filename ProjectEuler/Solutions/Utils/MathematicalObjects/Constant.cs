using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Utils.MathematicalObjects
{
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
}
