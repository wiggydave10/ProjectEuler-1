using System;
using System.Collections.Generic;
using System.Linq;

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

        public static double Sum(this IEnumerable<double> xs, Func<double, int, double> fn)
        {
            return xs.Select(fn).Sum();
        }

        public static long Product(this IEnumerable<int> xs)
        {
            return xs.Aggregate((a, b) => a*b);
        }

        public static int Product(this IEnumerable<int> xs, Func<int,int> fn)
        {
            return xs.Select(fn).Aggregate((a, b) => a * b);
        }

        public static IEnumerable<TU> Map<T,TU>(this IEnumerable<T> xs, Func<T, TU> func)
        {
            return xs.Select(func);
        }

        public static IEnumerable<TU> Map<T, TU>(this IEnumerable<T> xs, Func<T, int, TU> func)
        {
            return xs.Select(func);
        }

        public static bool IsConsecutive(this IEnumerable<int> xs)
        {
            return !xs.Select((i, j) => i - j).Distinct().Skip(1).Any();
        }

        public static bool IsPalendrome<T>(this IEnumerable<T> xs)
        {
            var arr = xs.ToArray();
            return arr.SequenceEqual(arr.Reverse());
        }
    }
}
