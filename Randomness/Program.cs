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

            string originalText = "MartinusÆØÅ";
            string encryptedText = Encrypter.Encrypt(originalText);
            string decryptedText = Encrypter.Decrypt(encryptedText);

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
        }
    }
}
