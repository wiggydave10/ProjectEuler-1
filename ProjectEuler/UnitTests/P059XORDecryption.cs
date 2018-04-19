using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Solutions.Problem059;

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

        //[TestMethod]
        //public void Version2_Answer()
        //{
        //    V2.Decrypt(Ciphertext, 3).ShouldBe(Plaintext);
        //}
    }
}
