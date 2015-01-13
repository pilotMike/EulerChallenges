using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Numbers;
using EulerTools.Primes;
using EulerTools.Program;

namespace PandigitalPrimes
{
    class Program
    {
        //We shall say that an n-digit number is pandigital if it 
        //makes use of all the digits 1 to n exactly once. For example, 
        //2143 is a 4-digit pandigital and is also prime.

        //What is the largest n-digit pandigital prime that exists?


        static void Main(string[] args)
        {
            var b = new Benchmarker();
            b.Benchmark(Do);
            Console.ReadLine();
        }

        private static void Do()
        {
            var primeHelper = new PrimeCalculator();
            var panHelper = new Pandigital();

            // create a 10 digit number to serve as the limit of the max prime
            // int limit = (int) Math.Pow(10, 9);
            // after solving, the largest is 7652413

            int limit = 7652414;
            int max = 10;

            // takes 4 seconds
            for (int i = 10; i < limit; i++)
                if (primeHelper.IsPrime(i) &&
                    panHelper.IsPandigitalToOwnDigitCount(i))
                {
                    max = i;
                    //Console.WriteLine("max is " + max);
                }

            Console.WriteLine("max is " + max);
        }

        private static int WayTooSlowMethod()
        {
            Stopwatch sw = new Stopwatch();
            PrimeCalculator primeHelper = new PrimeCalculator();
            int limit = (int) Math.Pow(10, 9) - 1;;
            Pandigital panHelper = new Pandigital();

            Console.WriteLine("getting primes up to 1B");
            sw.Start();
            var primes = primeHelper.GetPrimesUpToParallel(limit); // takes well over 1 minute
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            Console.WriteLine("filtering pandigital primes");
            sw.Start();
            var pandigitalPrimes = primes.AsParallel().Where(panHelper.IsPandigitalToOwnDigitCount);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            Console.WriteLine("getting max");
            sw.Start();
            var highest = pandigitalPrimes.AsParallel().Max();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            return highest;
        }
    }
}
