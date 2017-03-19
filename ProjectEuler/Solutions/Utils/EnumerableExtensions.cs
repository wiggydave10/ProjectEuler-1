using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Utils
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T[]> GetWindows<T>(this IEnumerable<T> xs, int length)
        {
            var list = xs.ToList();
            var offset = 0;
            while (offset + length <= list.Count)
            {
                yield return list.Skip(offset).Take(length).ToArray();
                offset++;
            }
        }

        public static long Product(this IEnumerable<int> xs)
        {
            return xs.Aggregate((a, b) => a*b);
        }

        public static IEnumerable<TU> Map<T,TU>(this IEnumerable<T> xs, Func<T, TU> func)
        {
            return xs.Select(func);
        }

        public static IEnumerable<TU> Map<T, TU>(this IEnumerable<T> xs, Func<T, int, TU> func)
        {
            return xs.Select(func);
        }
    }
}
