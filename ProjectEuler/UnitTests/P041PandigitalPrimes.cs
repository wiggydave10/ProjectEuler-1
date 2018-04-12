using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem041;

namespace UnitTests
{
    [TestClass]
    public class P041PandigitalPrimes
    {
        [TestMethod]
        public void Version1_Answer()
        {
            V1.Get().ShouldBe(7652413);
        }
    }
}
