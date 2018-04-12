using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        public void PrimeUtils_Primes_1000000()
        {
            PrimeUtils.Primes.TakeWhile(x => x <= 1000000).Count().ShouldBe(78498);
        }

        [TestMethod]
        public void PrimeUtils_Primes_Take200000()
        {
            PrimeUtils.Primes.Take(200000).Count().ShouldBe(200000);
        }
    }
}
