using System;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem045;

namespace UnitTests
{
    [TestClass]
    public class P045TriangularPentagonalHexagonal
    {
        [TestMethod]
        public void Version1_Practise()
        {
            var fns = new Func<BigInteger, BigInteger>[] {V1.Triangle, V1.Pentagonal, V1.Hexagonal};
            V1.Satisfies(fns).ShouldContain(40755);
        }

        [TestMethod]
        public void Version1_Answer()
        {
            var fns = new Func<BigInteger, BigInteger>[] { V1.Triangle, V1.Pentagonal, V1.Hexagonal };
            V1.Satisfies(fns).First(x => x > 40755).ShouldBe(1533776805);
        }
    }
}
