using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Randomness
{
    public class RandomnessTester
    {
        private readonly int _numberOfTests;
        private readonly int _arraySize;

        // Constructor to initialize number of tests and array size
        public RandomnessTester(int numberOfTests, int arraySize)
        {
            _numberOfTests = numberOfTests;
            _arraySize = arraySize;
        }

        // Method to test randomness using RNGCryptoServiceProvider
        public void RandomnessWithRNGCrypto()
        {
            Console.WriteLine("RandomnessWithRNGCrypto randomness test:");

            for (int i = 0; i < _numberOfTests; i++)
            {
                byte[] randomBytes = new byte[_arraySize];
                using (var randomNumberGenerator = RandomNumberGenerator.Create())
                {
                    randomNumberGenerator.GetBytes(randomBytes);
                }

                int randomInt = BitConverter.ToInt32(randomBytes, 0);
                Console.WriteLine($"Test {i + 1}: {BitConverter.ToString(randomBytes).Replace("-", "")} => {randomInt}");
            }
            Console.WriteLine();
        }

        // Method to test randomness using Random class
        public void RandomnessWithRandom()
        {
            Console.WriteLine("Random randomness test:");

            Random random = new Random();
            for (int i = 0; i < _numberOfTests; i++)
            {
                byte[] randomBytes = new byte[_arraySize];
                random.NextBytes(randomBytes);

                int randomInt = BitConverter.ToInt32(randomBytes, 0);
                Console.WriteLine($"Test {i + 1}: {BitConverter.ToString(randomBytes).Replace("-", "")} => {randomInt}");
            }
            Console.WriteLine();
        }

        // Method to run benchmarking for a given benchmark method
        public static void RunBenchmark(Action benchmarkMethod, string methodName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            benchmarkMethod();
            stopwatch.Stop();
            Console.WriteLine($"{methodName} time (ms): {stopwatch.ElapsedMilliseconds}");
        }

        // Benchmark method for Random class
        public static void BenchmarkRandom()
        {
            Random random = new Random();
            for (int i = 0; i < 1000000; i++)
            {
                random.Next(0, 1000);
            }
        }

        // Benchmark method for RNGCryptoServiceProvider
        public static void BenchmarkRandomnessWithRNGCrypto()
        {
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[4];
                for (int i = 0; i < 1000000; i++)
                {
                    randomNumberGenerator.GetBytes(randomBytes);
                    BitConverter.ToInt32(randomBytes, 0);
                }
            }
        }
    }
}
