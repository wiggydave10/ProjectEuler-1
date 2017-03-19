using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem012;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class UtilityTests
    {
        [TestMethod]
        public void FactorUtils_GetFactors_1()
        {
            AssertEqual(new long[] {1}, FactorUtils.GetFactors((long)1));
        }

        [TestMethod]
        public void FactorUtils_GetFactors_2()
        {
            AssertEqual(new long[] { 1,2 }, FactorUtils.GetFactors((long)2));
        }

        [TestMethod]
        public void FactorUtils_GetFactors_10()
        {
            AssertEqual(new long[] { 1,2,5,10 }, FactorUtils.GetFactors((long)10));
        }

        [TestMethod]
        public void FactorUtils_GetFactors_28()
        {
            AssertEqual(new long[] { 1, 2, 4, 7, 14, 28 }, FactorUtils.GetFactors((long)28));
        }

        private void AssertEqual<T>(IEnumerable<T> xs, IEnumerable<T> ys)
        {
            var xsArr = xs.OrderBy(x => x).ToArray();
            var ysArr = ys.OrderBy(y => y).ToArray();
            Assert.AreEqual(xsArr.Length, ysArr.Length);
            Assert.IsTrue(xsArr.Select((x,i) => x.Equals(ysArr[i])).All(b => b));
        }
    }
}
