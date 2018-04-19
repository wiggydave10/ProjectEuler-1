using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem039;

namespace UnitTests
{
    [TestClass]
    public class P039IntegerRightTriangles
    {
        [TestMethod]
        public void Version1_Practise()
        {
            var solutions = V1.GetSolutions(120).ToArray();
            V1.GetSolutions(120).Count().ShouldBe(3);
        }

        [TestMethod]
        public void Version1_Answer()
        {
            V1.PerimeterWithMaxSolutions(1000).ShouldBe(840);
        }
    }
}
