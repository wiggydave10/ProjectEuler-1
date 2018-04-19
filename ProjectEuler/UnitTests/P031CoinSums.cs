using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem031;

namespace UnitTests
{
    [TestClass]
    public class P031CoinSums
    {
        [TestMethod]
        public void Version1_HashTest()
        {
            V1.Hash(new HashSet<int>{1, 2, 5}, new[] {2, 2, 5}).ShouldBe(15);
        }

        [TestMethod]
        public void Version1_5p_from_1p_2p()
        {
            V1.GetCombinations(5, new HashSet<int> {1, 2}).ShouldBe(3);
        }

        [TestMethod]
        public void Version1_Question()
        {
            V1.GetCombinations(200, new HashSet<int> { 1, 2, 5, 10, 20, 50, 100 }).ShouldBe(0);
        }

        [TestMethod]
        public void Version2_5()
        {
            V2.CoinCounting(5).ShouldBe(4);
        }

        [TestMethod]
        public void Version2_10()
        {
            V2.CoinCounting(10).ShouldBe(11);
        }

        [TestMethod]
        public void Version2_20()
        {
            V2.CoinCounting(20).ShouldBe(41);
        }

        [TestMethod]
        public void Version2_200()
        {
            V2.CoinCounting(200).ShouldBe(73682);
        }
    }
}
