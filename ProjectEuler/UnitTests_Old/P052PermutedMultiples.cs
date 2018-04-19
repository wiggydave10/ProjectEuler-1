using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem052;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P052PermutedMultiples
    {
        [TestMethod]
        public void Version1_Practise()
        {
            V1.Main(2).ShouldBe(125874);
        }

        [TestMethod]
        public void Version1_Answer()
        {
            V1.Main(6).ShouldBe(142857);
        }
    }
}
