using System;
using System.Security.Cryptography;
using System.Text;

namespace Kronos.AcceleratedTool.UI.Cryphography
{
    public class CryphographyService
    {
        public string GetHash(SHA256 sha256Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            foreach (byte t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public bool VerifyHash(SHA256 sha256Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetHash(sha256Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (comparer.Compare(hashOfInput, hash) == 0)
            {
                return true;
            }

            return false;
        }
    }
}
