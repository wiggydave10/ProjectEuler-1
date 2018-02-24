using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem035;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P035CircularPrimes
    {
        [TestMethod]
        public void Version1_Practise()
        {
            V1.Get(100).Count().ShouldBe(13);
        }

        [TestMethod]
        public void Version1_Answer()
        {
            V1.Get(1000000).Count().ShouldBe(55);
        }
    }
}
