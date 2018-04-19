using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem044;

namespace UnitTests
{
    [TestClass]
    public class P044PentagonNumbers
    {
        [TestMethod]
        public void Version1_Answer()
        {
            V1.Get().ShouldBe(5482660L);
        }
    }
}
