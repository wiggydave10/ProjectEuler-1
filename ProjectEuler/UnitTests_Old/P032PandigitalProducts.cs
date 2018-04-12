using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem032;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P032PandigitalProducts
    {
        [TestMethod]
        public void Version1_PandigitalNumbers_3()
        {
            var ps = V1.PandigitalProducts(3).ToArray();
        }

        [TestMethod]
        public void Version1_PandigitalNumbers_5()
        {
            var ps = V1.PandigitalProducts(5).ToArray();
        }

        [TestMethod]
        public void Version1_PandigitalNumbers_9()
        {
            var ps = V1.PandigitalProducts(9).ToArray();
        }

        [TestMethod]
        public void Version1_PandigitalNumbers_t()
        {
            var t1 = new[] {0, 1}.DigitsToNumber();
            var t2 = new[] {1, 0}.DigitsToNumber();
            var t3 = new[] {1, 2}.DigitsToNumber();
            var tt = MiscUtils.GetDigits(10).ToArray();
            var ds = V1.DistinctNumbers().Take(100).ToArray();
            var ps = V1.GetMultipliers(new[] {3, 9}, 9).Select(x => x.DigitsToNumber()).OrderBy(x => x).ToArray();
        }

        [TestMethod]
        public void Version1_Answer()
        {
            V1.PandigitalProducts(9).Select(x => x.Product).Distinct().Sum().ShouldBe(45228);
        }

        [TestMethod]
        public void Version1_GetMultipliers_3()
        {
            var m = new[] {1, 2};
            var res = V1.GetMultipliers(m, 7);
        }

        [TestMethod]
        public void Version1_Choose()
        {
            var res = SetUtils.Choose(new []{1,2,3,4,5}, 3);
        }
    }
}
