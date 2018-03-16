using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Problem031
{
    /*
        In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:

        1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
        It is possible to make £2 in the following way:

        1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
        How many different ways can £2 be made using any number of coins?
    */
    public static class V2
    {
        public static int CoinCounting(int n)
        {
            var coinCount = new CoinCount(n);
            var i = 1;
            while (Step(coinCount)) i++;

            return i;
        }

        public static bool Step(CoinCount coinCount)
        {
            var coin = 2;
            while (coin <= coinCount.Total)
            {
                if (coinCount.CanBuild(coin))
                {
                    coinCount.Build(coin);
                    return true;
                }

                coinCount.Break(coin);
                coin = CoinCount.Coins.OrderBy(x => x).FirstOrDefault(x => x > coin);
                if (coin == 0) break;
            }

            return false;
        }
    }

    public class CoinCount
    {
        public static int[] Coins = new[] {1, 2, 5, 10, 20, 50, 100, 200};
        private Dictionary<int, int> coinCount = Coins.ToDictionary(x => x, x => 0);

        public CoinCount(int total)
        {
            coinCount[1] = total;
        }

        public int Total => coinCount.Sum(x => x.Key * x.Value);

        public bool CanBuild(int coin)
        {
            return coinCount[1] >= coin;
        }

        // Create the given coin from 1 pences
        public void Build(int coin)
        {
            coinCount[1] -= coin;
            coinCount[coin]++;
        }

        // Break up all of the given coin into 1 pences
        public void Break(int coin)
        {
            coinCount[1] += coinCount[coin] * coin;
            coinCount[coin] = 0;
        }
    }
}
