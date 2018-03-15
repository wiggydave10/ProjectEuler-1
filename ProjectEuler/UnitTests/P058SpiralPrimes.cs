using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem058;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P058SpiralPrimes
    {
        [TestMethod]
        public void Version1_Practise()
        {
            V1.Main().ShouldBe(0);
        }

        [TestMethod]
        public void Version1_Answer()
        {
        }
    }
}
