using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.UtilExternal;
using Solutions.Utils;

namespace UnitTests.UtilityTests
{
    [TestClass]
    public class UtilityExPrimeUtilTests
    {
        [TestMethod]
        public void FindPrimesBySieveOfAtkins_500()
        {
            ExPrimeUtils.FindPrimesBySieveOfAtkins(10000).Count.ShouldBe(1229);
        }

        [TestMethod]
        public void FindPrimesBySieveOfAtkins_1000000()
        {
            ExPrimeUtils.FindPrimesBySieveOfAtkins(1000000).Count.ShouldBe(78498);
        }

        [TestMethod]
        public void FindPrimesBySieveOfAtkins_max()
        {
        }
    }
}
