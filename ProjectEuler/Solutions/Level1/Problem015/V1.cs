using System.Collections.Generic;
using System.Linq;

namespace Solutions.Problem015
{
    public static class V1
    {
        public static ulong LatticePathCount(int n)
        {
            var row = new List<ulong> {1};

            for (var i = 1; i < n+1; i++)
            {
                for (var j = 1; j < i; j++)
                {
                    row[j] += row[j-1];
                }
                row.Add(row[i-1] * 2);
            }

            return row.Last();
        }

        public static ulong LatticePathCount2(int n)
        {
            var row = new List<ulong> { 1 };

            for (var i = 1; i < n + 1; i++)
            {
                Enumerable.Range(1, row.Count-1).ToList().ForEach(j => row[j] += row[j-1]);
                row.Add(row.Last() * 2);
            }

            return row.Last();
        }
    }
}
