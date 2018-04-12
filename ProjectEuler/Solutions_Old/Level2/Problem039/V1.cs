using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Solutions.Utils;

namespace Solutions.Problem039
{
    /*
        Integer right triangles
        Problem 39 
        If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.

        {20,48,52}, {24,45,51}, {30,40,50}

        For which value of p ≤ 1000, is the number of solutions maximised?
    */
    public static class V1
    {
        public static int PerimeterWithMaxSolutions(int limit)
        {
            var maxCount = 0;
            var maximisedPerimeter = 0;
            for (var p = 3; p <= limit; p++)
            {
                var count = GetSolutions(p).Count();
                if (count > maxCount)
                {
                    maxCount = count;
                    maximisedPerimeter = p;
                }
            }

            return maximisedPerimeter;
        }

        public static IEnumerable<Tuple<int,int,int>> GetSolutions(int perimeter)
        {
            for (var a = 1; a < perimeter/3; a++)
            {
                for (var b = a + 1; b < perimeter*2/3; b++)
                {
                    var c = Math.Sqrt(a * a + b * b);
                    if (a + b + (int)c == perimeter && Math.Abs(c % 1) < 0.0001)
                    {
                        yield return Tuple.Create(a, b, (int)c);
                    }
                }
            }
        }
    }
}
