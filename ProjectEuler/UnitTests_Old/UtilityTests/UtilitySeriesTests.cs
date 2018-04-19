using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Utils;

namespace UnitTests.UtilityTests
{
    [TestClass]
    public class UtilitySeriesTests
    {
        [TestMethod]
        public void Series_FindPolynomialOrder_1()
        {
            var series = new [] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            Assert.AreEqual(1, Series.FindPolynomialOrder(series));
        }

        [TestMethod]
        public void Series_FindPolynomialOrder_3()
        {
            var series = new [] { 1, 25, 101, 261, 537 };
            Assert.AreEqual(3, Series.FindPolynomialOrder(series));
        }

        [TestMethod]
        public void Series_FindPolynomialOrder_null()
        {
            var series = new[] { 1, 25, 101, 261 };
            Assert.AreEqual(null, Series.FindPolynomialOrder(series));
        }

        [TestMethod]
        public void Series_resolve()
        {
            Series.Resolve();
        }
    }
}
