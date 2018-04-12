using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem014;

namespace UnitTests
{
    [TestClass]
    public class P014LongestCollatzSequence
    {
        [TestMethod]
        public void Version1_FindLongestChainWithStartingNumberLessThanN()
        {
            Assert.AreEqual((uint)9, V1.FindLongestChainWithStartingNumberLessThanN(14));
            Assert.AreEqual((uint)837799, V1.FindLongestChainWithStartingNumberLessThanN(1000000));
        }
    }
}
