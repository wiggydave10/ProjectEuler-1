﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem030;

namespace UnitTests
{
    [TestClass]
    public class P030DigitPowers
    {
        [TestMethod]
        public void Version1_DistinctPowers_Practise()
        {
            Assert.AreEqual(19316, V1.DigitPowers(4, 10000));
        }

        [TestMethod]
        public void Version1_DistinctPowers_Question()
        {
            Assert.AreEqual(443839, V1.DigitPowers(5, 1000000));
        }
    }
}
