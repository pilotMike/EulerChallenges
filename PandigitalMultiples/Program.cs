using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Numbers;
using EulerTools.Program;

namespace PandigitalMultiples
{
    class Program
    {
        //Take the number 192 and multiply it by each of 1, 2, and 3:

        // 192 × 1 = 192
        // 192 × 2 = 384
        // 192 × 3 = 576

        //By concatenating each product we get the 1 to 9 pandigital,
        //192384576. We will call 192384576 the concatenated product
        //of 192 and (1,2,3)

        //The same can be achieved by starting with 9 and multiplying
        //by 1, 2, 3, 4, and 5, giving the pandigital, 918273645, which
        //is the concatenated product of 9 and (1,2,3,4,5).

        //What is the largest 1 to 9 pandigital 9-digit number that
        //can be formed as the concatenated product of an integer
        //with (1,2, ... , n) where n > 1?

        static Pandigital pan = new Pandigital();
        static DigitHelper dHelper = new DigitHelper();
        private const int numberDigits = 9;

        static void Main(string[] args)
        {
            Benchmarker b = new Benchmarker();
            b.Benchmark(Do);
            Console.ReadLine();
        }

        private static void Do()
        {
            const int max = 10000;
            // it's supposed to go up to a 9 digit number, so make a 10 digit number
            // to compare it to.
            int lessThan = (int) Math.Pow(10, numberDigits);
                
            int largest = 0;

            for (int i = 2; i < max; i++)
            {
                int j = 1;
                // initialize concatted to the first iteration
                int concatted = i*j;
                j++;

                while (concatted < lessThan)
                {
                    concatted = dHelper.Concat(concatted, i*j);

                    if (dHelper.GetDigitCount(concatted) == 9 &&
                        concatted > largest &&
                        pan.IsPandigital(concatted))
                    {
                        largest = concatted;
                        // Console.WriteLine(i + "\t" + largest);
                    }
                    j++;
                }
            }

            Console.WriteLine("done " + largest);
        }
    }
}
