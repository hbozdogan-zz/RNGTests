using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace RNGTests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Random Test started");

            Console.WriteLine("-------------------");

            Console.WriteLine("Simple Random results");
            SimpleRandom();
            Console.WriteLine("-------------------");

            Console.WriteLine("Guid Seed Random results");
            GuidSeedRandom();
            Console.WriteLine("-------------------");

            Console.WriteLine("Crypto Provider Seed Random results");
            CryptoRandom();
            Console.WriteLine("-------------------");

            Console.WriteLine("Random Test finished");

            Console.ReadLine();
        }

        private static void CryptoRandom()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var resultList = new List<int>();

            for (int i = 0; i < 20; i++)
            {
                var byteArray = new byte[4];
                provider.GetBytes(byteArray);

                //Byte - Integer cevrimi
                var result = BitConverter.ToInt32(byteArray, 0);

                var randNumber = new Random(result).Next(0, 100);

                resultList.Add(randNumber);
            }

            resultList.Sort();

            foreach (var number in resultList)
            {
                Console.WriteLine(number);
            }
        }

        private static void GuidSeedRandom()
        {
            var guidSeedRandom = new Random(Guid.NewGuid().GetHashCode());

            var resultList = new List<int>();

            for (int i = 0; i < 20; i++)
            {
                var randNumber = guidSeedRandom.Next(0, 100);
                resultList.Add(randNumber);
            }

            resultList.Sort();

            foreach (var number in resultList)
            {
                Console.WriteLine(number);
            }
        }

        private static void SimpleRandom()
        {
            var simpleRand = new Random();

            var resultList = new List<int>();

            for (int i = 0; i < 20; i++)
            {
                var randNumber = simpleRand.Next(0, 100);
                resultList.Add(randNumber);
            }

            resultList.Sort();

            foreach (var number in resultList)
            {
                Console.WriteLine(number);
            }
        }
    }
}