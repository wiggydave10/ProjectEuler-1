using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem038;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P038PandigitalMultiples
    {
        [TestMethod]
        public void Version1_Practise()
        {
            V1.ConcatenatedProduct(192, new[] { 1,2,3}).DigitsToNumber().ShouldBe(192384576);
        }

        [TestMethod]
        public void Version1_LargestProduct()
        {
            V1.LargestProduct(192).ShouldBe(192384576);
        }

        [TestMethod]
        public void Version1_Answer()
        {
            V1.Get().ShouldBe(932718654);
        }
    }
}
