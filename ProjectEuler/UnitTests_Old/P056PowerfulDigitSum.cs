using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem056;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P056PowerfulDigitSum
    {
        
        [TestMethod]
        public void Version1_Practise()
        {
            V1.MaximalDigitSum(10).ShouldBe(45);
        }

        [TestMethod]
        public void Version1_Answer()
        {
            V1.MaximalDigitSum(100).ShouldBe(972);
        }
    }
}
