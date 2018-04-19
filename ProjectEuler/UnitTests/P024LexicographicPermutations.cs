using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem024;

namespace UnitTests
{
    [TestClass]
    public class P024LexicographicPermutations
    {
        [TestMethod]
        public void Version1_LexicographicPermutations()
        {
            Assert.AreEqual("2783915460", string.Join("", V1.LexicographicPermutations(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }).ElementAt(1000000 - 1)));
        }
    }
}
