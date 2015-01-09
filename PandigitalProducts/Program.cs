using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EulerTools.Numbers;
using EulerTools.Program;

namespace PandigitalProducts
{
    class Program
    {
        //We shall say that an n-digit number is pandigital if it makes use of 
        //all the digits 1 to n exactly once; for example, the 5-digit number, 15234, 
        //is 1 through 5 pandigital.

        //The product 7254 is unusual, as the identity, 39 × 186 = 7254, 
        //containing multiplicand, multiplier, and product is 1 through 9 pandigital.

        //Find the sum of all products whose multiplicand/multiplier/product 
        //identity can be written as a 1 through 9 pandigital.

        //HINT: Some products can be obtained in more than one way so be sure 
        //to only include it once in your sum.
        private const int Limit = 10000;
        private static List<int> products = new List<int>();

        static void Main(string[] args)
        {
            var b = new Benchmarker();
            b.Benchmark(Do);
            b.Benchmark(DoOnlineWay);
            Console.ReadLine();
        }

        private static void DoOnlineWay()
        {
            // I can't read any of this.
            var pand = new OnlinePandigital();
            List<long> products = new List<long>();
            long sum = 0;
            long prod, compiled;

            for (long m = 2; m < 100; m++)
            {
                long nbegin = (m > 9) ? 123 : 1234;
                long nend = 10000 / m + 1;

                for (long n = nbegin; n < nend; n++)
                {
                    prod = m * n;
                    compiled = pand.concat(pand.concat(prod, n), m);
                    if (compiled >= 1E8 &&
                        compiled < 1E9 &&
                        pand.IsPandigital(compiled))
                    {
                        if (!products.Contains(prod))
                        {
                            products.Add(prod);
                        }
                    }
                }
            }

            for (int i = 0; i < products.Count; i++)
            {
                sum += products[i];
            }

            Console.WriteLine(sum);
        }

        private static void Do()
        {
            var pandigital = new Pandigital();

            Parallel.For(1, Limit, (i) =>
            {
                for (int j = 0; j < i+1; j++)
                {
                    int product = i*j;
                    //if (pandigital.IsPandigital(i, j, product))
                    if (pandigital.IsPandigital(i, j, product))
                    {
                        products.Add(product);
                        //Console.WriteLine(i + " + " + j + " = " + product);
                    }
                }
            });

            products = products.Distinct().ToList();
            var sum = products.Sum();
            Console.WriteLine(sum);
        }
    }
}
