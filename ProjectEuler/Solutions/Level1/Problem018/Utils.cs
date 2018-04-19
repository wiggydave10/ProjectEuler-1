using System.IO;
using System.Linq;

namespace Solutions.Problem018
{
    public static class Utils
    {
        public static Node ParseTriangle(string filePath)
        {
            return LinkNodes(GetTriangle(filePath), 0, 0);
        }

        public static int[][] GetTriangle(string filePath)
        {
            return File.ReadAllLines(filePath).Select(l => l.Split(' ').Select(int.Parse).ToArray()).ToArray();
        }

        public static Node LinkNodes(int[][] triangle, int row, int col)
        {
            var node = new Node(triangle[row][col]);
            var nextRow = row + 1;
            if (nextRow > triangle.Length) return node;
            node.Left = LinkNodes(triangle, row + 1, col);
            node.Right = LinkNodes(triangle, row + 1, col + 1);
            return node;
        }
    }
}
