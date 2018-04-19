using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Problem059
{
    /*
        XOR decryption
        Problem 59 
        Each character on a computer is assigned a unique code and the preferred standard is 
        ASCII (American Standard Code for Information Interchange). For example, 
        uppercase A = 65, asterisk (*) = 42, and lowercase k = 107.

        A modern encryption method is to take a text file, convert the bytes to ASCII, 
        then XOR each byte with a given value, taken from a secret key. 
        The advantage with the XOR function is that using the same encryption key on the cipher text, 
        restores the plain text; for example, 65 XOR 42 = 107, then 107 XOR 42 = 65.

        For unbreakable encryption, the key is the same length as the plain text message, 
        and the key is made up of random bytes. The user would keep the encrypted message 
        and the encryption key in different locations, and without both "halves", 
        it is impossible to decrypt the message.

        Unfortunately, this method is impractical for most users, 
        so the modified method is to use a password as a key. 
        If the password is shorter than the message, which is likely, 
        the key is repeated cyclically throughout the message. 
        The balance for this method is using a sufficiently long password key for security, 
        but short enough to be memorable.

        Your task has been made easy, as the encryption key consists of three lower case characters. 
        Using cipher.txt (right click and 'Save Link/Target As...'), a file containing the encrypted ASCII codes, 
        and the knowledge that the plain text must contain common English words, 
        decrypt the message and find the sum of the ASCII values in the original text.
    */

    public static class V1
    {
        private static string[] CommonWords = new[]
        {
            "the", "of", "and", "to", "a", "in", "for", "is", "on", "that", "by", "this", "with", "i", "you", "it",
            "not", "or", "be", "are", "from", "at", "as", "your", "all", "have", "new", "more", "an", "was", "we"
        };

        /// <summary>
        /// Using the clues: keyLength, English words, Key is lowercase (implies alphabetical)
        /// This function brute forces all possible keys and looks for a crude list of common english words
        /// Surprised this worked off the bat.
        /// </summary>
        public static string CheatDecrypt(byte[] ciphertext)
        {
            var scored = new Dictionary<string, int>();

            foreach (var key in PossibleKeys())
            {
                var plaintext = XOR(ciphertext, key);
                var plainString = BytesToString(plaintext);
                var score = CommonWords.Count(word => plainString.Contains(word));
                scored.Add(plainString, score);
            }

            return scored.OrderByDescending(p => p.Value).First().Key;
        }

        public static string BytesToString(byte[] text)
        {
            return new string(text.Select(b => (char)b).ToArray());
        }

        public static byte[] XOR(byte[] text, byte[] key)
        {
            return Enumerable.Repeat(key, (int)Math.Ceiling(text.Length / 3d))
                .SelectMany(x => x)
                .Take(text.Length)
                .Select((b, i) => (byte)(b ^ text[i]))
                .ToArray();
        }

        public static IEnumerable<byte[]> PossibleKeys()
        {
            for (var i = 'a'; i <= 'z'; i++)
            {
                for (var j = 'a'; j <= 'z'; j++)
                {
                    for (var k = 'a'; k <= 'z'; k++)
                    {
                        yield return new[] {(byte) i, (byte) j, (byte) k};
                    }
                }
            }
        }
    }
}
