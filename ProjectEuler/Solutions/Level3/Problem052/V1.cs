using System.Linq;

namespace Solutions.Problem052
{
    /*
        Permuted multiples
        Problem 52 
        It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits, but in a different order.

        Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.
    */

    public static class V1
    {
        public static long Main(int n)
        {
            var curr = 2;
            var currHash = PermutatedHash(curr);

            while (Enumerable.Range(2, n - 1).Select(i => PermutatedHash(curr * i)).Any(x => x != currHash))
            {
                currHash = PermutatedHash(++curr);
            }

            return curr;
        }

        public static string PermutatedHash(int n)
        {
            return new string(n.ToString().OrderBy(x => x).ToArray());
        }
    }
}
