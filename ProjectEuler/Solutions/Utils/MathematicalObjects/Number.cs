namespace Solutions.Utils.MathematicalObjects
{
    public abstract class Number
    {
        public abstract Number Clone();

        protected abstract Number Divide(double x);
        protected abstract Number Multiply(double x);

        public static Number operator /(Number n, double x) => n.Divide(x);
        //public static Number operator /(double x, Number n) => n.Divide(x);

        public static Number operator *(Number n, double x) => n.Multiply(x);
        public static Number operator *(double x, Number n) => n.Multiply(x);
    }
}
