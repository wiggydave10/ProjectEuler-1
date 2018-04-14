using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem060;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P060PrimePairSets
    {
        [TestMethod]
        public void Version1_Answer()
        {
            V1.Main();
        }

        [TestMethod]
        public void Version2_Answer()
        {
            V2.Main();
        }
    }
}
