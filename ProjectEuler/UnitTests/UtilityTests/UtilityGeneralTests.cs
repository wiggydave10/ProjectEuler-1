using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Utils;

namespace UnitTests.UtilityTests
{
    [TestClass]
    public class UtilityGeneralTests
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

        [TestMethod]
        public void Maths_Polynomial_0()
        {
            Assert.AreEqual(1, Maths.Polynomial(41 / 3d, -15, 76 / 3d, 1)(0));
        }

        [TestMethod]
        public void Maths_Polynomial_1()
        {
            Assert.AreEqual(25, Maths.Polynomial(41 / 3d, -15, 76 / 3d, 1)(1));
        }

        [TestMethod]
        public void Maths_Polynomial_2()
        {
            Assert.AreEqual(101, Maths.Polynomial(41 / 3d, -15, 76 / 3d, 1)(2));
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
