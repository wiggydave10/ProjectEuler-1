using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem040;

namespace UnitTests
{
    [TestClass]
    public class P040ChampernownesConstant
    {
        [TestMethod]
        public void Version1_Answer()
        {
            V1.Get().ShouldBe(210);
        }
    }
}
