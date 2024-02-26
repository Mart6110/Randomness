using System;
using System.Text;

namespace Randomness
{
    public class Encrypter
    {
        // Method to encrypt a string by adding 1 to each character's ASCII value
        public static string Encrypt(string input)
        {
            // Check if the input string is null or empty
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input string cannot be null or empty");

            // StringBuilder to store the encrypted text
            StringBuilder encrypted = new StringBuilder();

            // Iterate through each character in the input string
            foreach (char c in input)
            {
                // Encrypt each character by adding 1 to its ASCII value
                char encryptedChar = (char)(c + 3);
                encrypted.Append(encryptedChar);
            }

            // Return the encrypted string
            return encrypted.ToString();
        }

        // Method to decrypt an encrypted string by subtracting 1 from each character's ASCII value
        public static string Decrypt(string input)
        {
            // Check if the input string is null or empty
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input string cannot be null or empty");

            // StringBuilder to store the decrypted text
            StringBuilder decrypted = new StringBuilder();

            // Iterate through each character in the input string
            foreach (char c in input)
            {
                // Decrypt each character by subtracting 1 from its ASCII value
                char decryptedChar = (char)(c - 3);
                decrypted.Append(decryptedChar);
            }

            // Return the decrypted string
            return decrypted.ToString();
        }
    }
}
