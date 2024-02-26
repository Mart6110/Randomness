using System.Security.Cryptography;

namespace Randomness
{
    internal class Program
    {
        public static void Main()
        {
            // Define number of tests and array size
            int numberOfTests = 100;
            int arraySize = 4;

            string originalText = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
            string originalText2 = "abcdefghijklmnopqrstuvwxzæøå";
            string encryptedText = Encrypter.Encrypt(originalText);
            string decryptedText = Encrypter.Decrypt(encryptedText);
            string encryptedText2 = Encrypter.Encrypt(originalText2);
            string decryptedText2 = Encrypter.Decrypt(originalText2);

            // Create an instance of RandomnessTester
            RandomnessTester tester = new RandomnessTester(numberOfTests, arraySize);

            // Perform randomness test with RNGCryptoServiceProvider
            tester.RandomnessWithRNGCrypto();

            // Perform randomness test with Random
            tester.RandomnessWithRandom();

            // Benchmarking
            Console.WriteLine("Benchmarking:");
            RandomnessTester.RunBenchmark(RandomnessTester.BenchmarkRandom, "RandomnessWithRandom");
            RandomnessTester.RunBenchmark(RandomnessTester.BenchmarkRandomnessWithRNGCrypto, "RandomnessWithRNGCrypto");

            // Encrypted & Decrypted
            Console.WriteLine();
            Console.WriteLine($"Encrypted text: {encryptedText}");
            Console.WriteLine($"Decrypted text: {decryptedText}");
            Console.WriteLine();
            Console.WriteLine($"Encrypted text: {encryptedText2}");
            Console.WriteLine($"Decrypted text: {decryptedText2}");
        }
    }
}
