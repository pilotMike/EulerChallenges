using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Numbers;
using EulerTools.Primes;
using EulerTools.Program;

namespace CircularPrimes
{
    class Program
    {
        //The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.

        //There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.

        //How many circular primes are there below one million?

        private static int Limit = 1000000;
        //private static int Limit = 100;
        static void Main(string[] args)
        {
            int count = 0;
            Benchmarker b = new Benchmarker();
            b.Benchmark(() => count = Do());

            //foreach (var number in list)
            //{
            //    Console.Write(number + " ");
            //}

            Console.WriteLine(count);
            Console.ReadLine();
        }

        private static int Do()
        {
            var dHelper = new DigitHelper();
            var pCalculator = new PrimeCalculator();
            var list = new List<int>();

            Parallel.For(2, Limit, (i) =>
            //for (int i = 2; i < Limit; i++)
            {
                var rotations = dHelper.RotateDigits(i);
                if (rotations.All(r => pCalculator.IsPrime(r)))
                {
                    list.Add(i);
                    //Console.WriteLine(i);
                    //foreach (var rotation in rotations)
                    //    Console.Write(rotation + " ");
                    //Console.WriteLine();
                    
                }
            }
                );
            return list.Count;
        }
    }
}
