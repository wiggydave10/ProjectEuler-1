using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Problem024
{
    public static class V1
    {
        public static IEnumerable<T[]> LexicographicPermutations<T>(IEnumerable<T> set)
        {
            return Helper(new SortedSet<T>(set).ToArray(), new T[0]);
        }

        public static T[][] Helper<T>(T[] xs, T[] ys)
        {
            if (!xs.Any()) return new[] { ys };

            return Enumerable.Range(0, xs.Length).SelectMany(i =>
                        Helper(xs.Take(i).Concat(xs.Skip(i + 1)).ToArray(),
                        ys.Concat(new[] { xs.ElementAt(i) }).ToArray())).ToArray();
        }
    }
}
