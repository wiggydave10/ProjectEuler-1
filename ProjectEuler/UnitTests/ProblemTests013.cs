using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.Problem013;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class ProblemTests013
    {
        private int[][] numbers;

        public ProblemTests013()
        {
            numbers =
                File.ReadAllLines("../../Resources/Problem013.txt")
                    .Select(l => l.Select(ch => ch.ToString()).Select(int.Parse).ToArray())
                    .ToArray();
        }

        [TestMethod]
        public void Version1_FirstNDigitsOfLargeSum()
        {
            Assert.AreEqual("5537376230", string.Join("", V1.FirstNDigitsOfLargeSum(10, numbers)));
        }
    }
}
