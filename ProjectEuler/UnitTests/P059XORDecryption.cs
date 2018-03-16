using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem059;
using Solutions.Utils;

namespace UnitTests
{
    [TestClass]
    public class P059XORDecryption
    {
        private static readonly byte[] Ciphertext = 
            File.ReadAllText("../../Resources/Problem059/ciphertext.txt").Split(',').Select(byte.Parse).ToArray();
        private static readonly string Plaintext =
            File.ReadAllText("../../Resources/Problem059/plaintext.txt");

        [TestMethod]
        public void Version1_Answer()
        {
            V1.CheatDecrypt(Ciphertext).ShouldBe(Plaintext);
        }
    }
}
