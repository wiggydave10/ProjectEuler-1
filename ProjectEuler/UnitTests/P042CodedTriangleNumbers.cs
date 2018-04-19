using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem042;

namespace UnitTests
{
    [TestClass]
    public class P042CodedTriangleNumbers
    {
        private const string FilePath = "../../Resources/Problem042/Words.txt";

        [TestMethod]
        public void Version1_Practise()
        {
            V1.WordValue("SKY").ShouldBe(55);
            V1.NthTriangleNumber(10).ShouldBe(55);
        }

        [TestMethod]
        public void Version1_Answer()
        {
            V1.GetTriangleWords(File.ReadAllText(FilePath)).Count().ShouldBe(162);
        }
    }
}
