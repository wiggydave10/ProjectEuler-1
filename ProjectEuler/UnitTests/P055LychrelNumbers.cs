using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem055;

namespace UnitTests
{
    [TestClass]
    public class P055LychrelNumbers
    {
        
        [TestMethod]
        public void Version1_Practise_4994_IsLychrel()
        {
            V1.IsLychrel("4994", 50).ShouldBeTrue();
        }

        [TestMethod]
        public void Version1_Practise_10677_IsNotLychrel()
        {
            V1.IsLychrel("10677", 53).ShouldBeFalse();
        }

        [TestMethod]
        public void Version1_Answer()
        {
            Enumerable.Range(0, 10000).Count(x => V1.IsLychrel(x.ToString(), 50)).ShouldBe(249);
        }
    }
}
