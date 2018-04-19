using System.Linq;

namespace Solutions.Problem022
{
    public static class V1
    {
        public static long SumNameScores(string[] names)
        {
            return names.OrderBy(n => n).Select((n, i) => AlphabeticalValue(n)*(i + 1)).Sum();
        }

        private static int AlphabeticalValue(string str)
        {
            return str.Sum(ch => (int)ch%32);
        }
    }
}
