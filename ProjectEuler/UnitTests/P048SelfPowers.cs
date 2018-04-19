using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem048;

namespace UnitTests
{
    [TestClass]
    public class P048SelfPowers
    {
        [TestMethod]
        public void Version1_Practise()
        {
            V1.Main(10, 10).ShouldBe(405071317);
        }

        [TestMethod]
        public void Version1_Answer()
        {
            V1.Main(10, 1000).ShouldBe(9110846700);
        }
    }
}
