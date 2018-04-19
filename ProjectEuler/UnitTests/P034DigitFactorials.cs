using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem034;

namespace UnitTests
{
    [TestClass]
    public class P034DigitFactorials
    {
        [TestMethod]
        public void Version1_Answer()
        {
            V1.Get().Sum().ShouldBe(40730);
        }
    }
}
