using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Utils.MathematicalObjects
{
    public abstract class Number
    {
        public abstract Number Clone();
        public abstract Number Minus();

        public static Number operator /(Number v1, double x)
        {
            var clone = v1.Clone();
            if (v1.GetType() == typeof(Variable))
            {
                var cloneV = (Variable)clone;
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
