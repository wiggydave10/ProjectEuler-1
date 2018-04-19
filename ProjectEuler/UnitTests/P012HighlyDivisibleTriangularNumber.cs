using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem012;

namespace UnitTests
{
    [TestClass]
    public class P012HighlyDivisibleTriangularNumber
    {
        [TestMethod]
        public void Version1_TriangleNumberWithNDivisors()
        {
            Assert.AreEqual(28, V1.TriangleNumberWithNDivisors(5));
            Assert.AreEqual(76576500, V1.TriangleNumberWithNDivisors(500));
        }
    }
}
