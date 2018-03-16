using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Problem006
{
    public static class V1
    {
        public static long SumSquareSumDifference(int n)
        {
            var nNaturalNumbers = Enumerable.Range(1, n).ToList();
            return (int)Math.Pow(nNaturalNumbers.Sum(), 2) - nNaturalNumbers.Sum(x => x*x);
        }
    }
}
