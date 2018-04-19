using System;
using System.Collections.Generic;
using System.Linq;
using Solutions.Utils;

namespace Solutions.Problem011
{
    public static class V1
    {
        public static long GreatestAdjacentProduct(int[][] grid, int length)
        {
            var maxRowProduct = grid.MaxGridRowProduct(length);
            var maxColProduct = grid.MaxGridColumnProduct(length);

            var maxLeftDiagonalProduct = grid.Select((row, i) => row.Skip(i)).MaxGridColumnProduct(length);
            var maxRightDiagonalProduct = grid.Select((row, i) => Enumerable.Repeat(0, i).Concat(row)).MaxGridColumnProduct(length);

            return Max(maxRowProduct, maxColProduct, maxLeftDiagonalProduct, maxRightDiagonalProduct);
        }

        private static long Max(params long[] xs)
        {
            return xs.Aggregate(Math.Max);
        }

        private static long MaxGridRowProduct(this IEnumerable<IEnumerable<int>> grid, int windowSize)
        {
            return grid.SelectMany(row => GetWindowProducts(row, windowSize)).Max();
        }

        private static long MaxGridColumnProduct(this IEnumerable<IEnumerable<int>> grid, int windowSize)
        {
            return GetColumns(grid).SelectMany(col => GetWindowProducts(col, windowSize)).Max();
        }

        private static IEnumerable<long> GetWindowProducts(IEnumerable<int> xs, int windowSize)
        {
            return xs.GetWindows(windowSize).Select(w => w.Product());
        }

        private static IEnumerable<IEnumerable<T>> GetColumns<T>(IEnumerable<IEnumerable<T>> grid)
        {
            var gridArr = grid.Select(r => r.ToArray()).ToArray();
            return Enumerable.Range(0, gridArr[0].Length).Select(i => gridArr.Where(row => i > -1 && i < row.Length).Select(row => row[i]));
        }
    }
}
