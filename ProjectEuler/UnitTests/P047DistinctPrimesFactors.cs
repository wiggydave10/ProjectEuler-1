using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem047;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P047DistinctPrimesFactors
    {
        [TestMethod]
        public void Version1_Practise_2()
        {
            V1.Main(2).ShouldBe(14);
        }

        [TestMethod]
        public void Version1_Practise_3()
        {
            V1.Main(3).ShouldBe(644);
        }

        [TestMethod]
        public void Version1_Answer()
        {
            V1.Main(4).ShouldBe(134043);
        }
    }
}
