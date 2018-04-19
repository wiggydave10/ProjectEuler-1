using System.Linq;

namespace Solutions.Problem017
{
    public static class V1
    {
        private static string[] words = new[]
        {
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
            "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        };

        private static string[] word10s = new[]
        {
            "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
        };



        public static int NumberWordStringLength(int n)
        {
            return Enumerable.Range(1, n).SelectMany(Wordify).Count(char.IsLetter);
        }

        public static string Wordify(int n)
        {
            if (n < 20) return words[n];

            if (n < 100)
            {
                return (n%10 != 0) ? word10s[n/10 - 2] + "-" + words[n%10] : word10s[n/10 - 2];
            }

            if (n < 1000)
            {
                var hundreds = n/100;
                return (n%100 != 0) ? words[hundreds] + " hundred and " + Wordify(n - hundreds*100) : words[hundreds] + " hundred";
            }

            return "one thousand";
        }
    }
}
