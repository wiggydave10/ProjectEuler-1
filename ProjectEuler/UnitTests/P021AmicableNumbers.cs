using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem021;

namespace UnitTests
{
    [TestClass]
    public class P021AmicableNumbers
    {
        [TestMethod]
        public void Version1_AmicableSumUnderN()
        {
            Assert.AreEqual(31626, V1.AmicableSumUnderN(10000));
        }

        [TestMethod]
        public void Version2_AmicableSumUnderN()
        {
            Assert.AreEqual(31626, V2.AmicableSumUnderN(10000));
        }
    }
}
