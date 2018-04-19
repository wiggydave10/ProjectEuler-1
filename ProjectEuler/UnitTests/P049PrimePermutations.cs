using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem049;

namespace UnitTests
{
    [TestClass]
    public class P049PrimePermutations
    {
        [TestMethod]
        public void Version1_Practise()
        {
            V1.Main().ShouldContain("148748178147");
        }

        [TestMethod]
        public void Version1_Answer()
        {
            V1.Main().ShouldContain("296962999629");
        }
    }
}
