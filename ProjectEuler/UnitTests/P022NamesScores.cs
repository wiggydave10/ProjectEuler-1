using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem022;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P022NamesScores
    {
        [TestMethod]
        public void Version1_SumNameScores()
        {
            var names = File.ReadAllText("../../Resources/Problem022/names.txt").Replace("\"","").Split(',');
            Assert.AreEqual(871198282, V1.SumNameScores(names));
        }
    }
}
