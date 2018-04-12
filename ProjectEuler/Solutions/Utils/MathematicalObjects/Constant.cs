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

        protected override Number Divide(double x)
        {
            return new Constant(Value / x);
        }

        protected override Number Multiply(double x)
        {
            return new Constant(Value * x);
        }

        public override string ToString()
        {
            return Value.ToString("F");
        }

        public static Constant operator +(Constant c1, Constant c2)
        {
            return new Constant(c1.Value + c2.Value);
        }

        public static Constant operator /(Constant c1, double x)
        {
            return (Constant)c1.Divide(x);
        }
    }
}
