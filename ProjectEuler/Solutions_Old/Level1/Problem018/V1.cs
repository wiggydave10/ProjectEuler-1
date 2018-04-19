using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Problem018
{
    public static class V1
    {
        public static int MaximumPathTriangle(int[][] triangle)
        {
            for (var i = 1; i < triangle.Length; i++)
            {
                var row = triangle[i];
                var parentRow = triangle[i - 1];
                for (var j = 0; j < row.Length; j++)
                {
                    var parentLeft = (j == 0) ? 0 : parentRow[j-1];
                    var parentRight = (j == row.Length-1) ? 0 : parentRow[j];
                    row[j] += Math.Max(parentLeft, parentRight);
                }
            }

            return triangle.Last().Max();
        }
    }
}
