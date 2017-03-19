using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Problem015
{
    public static class V1
    {
        public static ulong LatticePathCount(int n)
        {
            var row = new List<ulong> {1};

            for (var i = 1; i < n+1; i++)
            {
                ulong prev = 1;
                for (var j = 1; j < i; j++)
                {
                    row[j] += prev;
                    prev = row[j];
                }
                row.Add(prev * 2);
            }

            return row.Last();
        }
    }
}
