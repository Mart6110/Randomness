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

            // Define mapping for Danish characters
            Dictionary<char, char> danishCharMapping = new Dictionary<char, char>()
            {
                {'æ', 'å'},
                {'ø', 'æ'},
                {'å', 'ø'},
                {'Æ', 'Å'},
                {'Ø', 'Æ'},
                {'Å', 'Ø'}
            };

            // StringBuilder to store the encrypted text
            StringBuilder encrypted = new StringBuilder();

            // Iterate through each character in the input string
            foreach (char c in input)
            {
                // Encrypt each character based on its ASCII value
                // Handle uppercase letters
                if (c >= 'A' && c <= 'Z')
                {
                    char encryptedChar = (char)((c - 'A' + 3) % 26 + 'A');
                    encrypted.Append(encryptedChar);
                }
                // Handle lowercase letters
                else if (c >= 'a' && c <= 'z')
                {
                    char encryptedChar = (char)((c - 'a' + 3) % 26 + 'a');
                    encrypted.Append(encryptedChar);
                }
                // Handle Danish characters
                else if (danishCharMapping.ContainsKey(c))
                {
                    encrypted.Append(danishCharMapping[c]);
                }
                else
                {
                    encrypted.Append(c); // Keep non-alphabetic characters unchanged
                }
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

            // Define mapping for Danish characters
            Dictionary<char, char> danishCharMapping = new Dictionary<char, char>()
            {
                {'æ', 'å'},
                {'ø', 'æ'},
                {'å', 'ø'},
                {'Æ', 'Å'},
                {'Ø', 'Æ'},
                {'Å', 'Ø'}
            };

            // StringBuilder to store the decrypted text
            StringBuilder decrypted = new StringBuilder();

            // Iterate through each character in the input string
            foreach (char c in input)
            {
                // Decrypt each character based on its ASCII value
                // Handle uppercase letters
                if (c >= 'A' && c <= 'Z')
                {
                    char decryptedChar = (char)(((c - 'A' - 3) % 26 + 26) % 26 + 'A');
                    decrypted.Append(decryptedChar);
                }
                // Handle lowercase letters
                else if (c >= 'a' && c <= 'z')
                {
                    char decryptedChar = (char)(((c - 'a' - 3) % 26 + 26) % 26 + 'a');
                    decrypted.Append(decryptedChar);
                }
                // Handle Danish characters
                else if (danishCharMapping.ContainsKey(c))
                {
                    decrypted.Append(danishCharMapping[c]);
                }
                else
                {
                    decrypted.Append(c); // Keep non-alphabetic characters unchanged
                }
            }

            // Return the decrypted string
            return decrypted.ToString();
        }
    }
}
