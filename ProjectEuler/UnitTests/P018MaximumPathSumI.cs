using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem018;

namespace UnitTests
{
    [TestClass]
    public class P018MaximumPathSumI
    {
        [TestMethod]
        public void Version1_MaximumPathTriangle_small()
        {
            var triangle = Utils.GetTriangle("../../Resources/Problem018/small triangle.txt");
            Assert.AreEqual(23, V1.MaximumPathTriangle(triangle));
        }

        [TestMethod]
        public void Version1_MaximumPathTriangle_large()
        {
            var triangle = Utils.GetTriangle("../../Resources/Problem018/large triangle.txt");
            Assert.AreEqual(1074, V1.MaximumPathTriangle(triangle));
        }
    }
}
