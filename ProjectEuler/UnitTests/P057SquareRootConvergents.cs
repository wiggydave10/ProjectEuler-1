using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem057;

namespace UnitTests
{
    [TestClass]
    public class P057SquareRootConvergents
    {
        
        [TestMethod]
        public void Version1_Practise_0()
        {
            V1.Expansion(0).ShouldBe(new Fraction(3, 2));
        }

        [TestMethod]
        public void Version1_Practise_1()
        {
            V1.Expansion(1).ShouldBe(new Fraction(7, 5));
        }

        [TestMethod]
        public void Version1_Practise_2()
        {
            V1.Expansion(2).ShouldBe(new Fraction(17, 12));
        }

        [TestMethod]
        public void Version1_Answer()
        {
            Enumerable.Range(0, 1000)
                .Select(V1.Expansion)
                .Count(V1.Condition)
                .ShouldBe(153);
        }
    }
}
