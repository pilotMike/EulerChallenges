using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Numbers;
using EulerTools.Primes;
using EulerTools.Program;

namespace TruncatablePrimes
{
    class Program
    {
        //The number 3797 has an interesting property. Being prime itself, 
        //it is possible to continuously remove digits from left to right, 
        //and remain prime at each stage: 3797, 797, 97, and 7. Similarly 
        //we can work from right to left: 3797, 379, 37, and 3.

        //Find the sum of the only eleven primes that are both truncatable 
        //from left to right and right to left.

        //NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.

        static PrimeCalculator primeCalculator = new PrimeCalculator();
        static DigitHelper dHelper = new DigitHelper();

        static void Main(string[] args)
        {
            Benchmarker b = new Benchmarker();
            b.Benchmark(Do);
            Console.ReadLine();
        }

        private static void Do()
        {
            int itemsFound = 0;
            const int itemsFoundLimit = 11;
            int sum = 0;

            int i = 10;
            while (itemsFound < itemsFoundLimit)
            {
                if (primeCalculator.IsPrime(i) &&
                    IsPrimeFromLeft(i) &&
                    IsPrimeFromRight(i))
                {
                    itemsFound++;
                    sum += i;
                    // Console.WriteLine(i);
                }
                i++;
            }

            Console.WriteLine(sum);
        }

        /// <summary>
        /// Removes digits one at a time starting from the left
        /// and returns whether it is prime
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        static bool IsPrimeFromLeft(int i)
        {
            int temp = i;
            while (temp > 10)
            {
                temp = dHelper.RemoveLeftMostDigit(temp);
                if (!primeCalculator.IsPrime(temp))
                    return false;
            }

            return true;
        }

        static bool IsPrimeFromRight(int i)
        {
            int temp = i;
            while (temp > 10)
            {
                temp /= 10;
                if (!primeCalculator.IsPrime(temp))
                    return false;
            }
            return true;
        }
    }
}
