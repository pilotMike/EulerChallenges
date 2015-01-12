using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Numbers;
using EulerTools.Program;

namespace ChampernownesConstant
{
    class Program
    {
        //An irrational decimal fraction is created by concatenating the positive integers:

        //0.123456789101112131415161718192021...

        //It can be seen that the 12th digit of the fractional part is 1.

        //If dn represents the nth digit of the fractional part, find the value of the following expression.

        //d1 × d10 × d100 × d1000 × d10000 × d100000 × d1000000
        static void Main(string[] args)
        {
            var b = new Benchmarker();
            b.Benchmark(Do);
            Console.ReadLine();
        }

        private static void Do()
        {
            var digitHelper = new DigitHelper();
            var incrementor = new Incrementor();

            const int digitLimit = 9;
            int append = 1;
            int prefixNum = 0;
            int[] placesToGet = {1, 10, 100, 1000, 10000, 100000, 1000000};
            int totalPlaces = 0;
            int finalProduct = 1;

            // enumerate up to 1M iterations
            int finalNumber = placesToGet.Last();
            while (totalPlaces <= finalNumber)
            {
                // the current number is the prefix number + the append number
                // however, for the first 10 digits, 0 is not appended.
                // step 2 is to make an array of each digit. For the tools that I have,
                // it's easier to concat and then split.
                int current = prefixNum == 0 ? append : digitHelper.Concat(prefixNum, append);
                var splitDigits = digitHelper.SplitDigits(current).ToArray();
                int digitCount = splitDigits.Length;

                // Since I've made an array of each new position, iterate
                // over the array, incrementing the total digit count, to 
                // get the digit at that position.
                for (int i = 0; i < digitCount; i++)
                {
                    totalPlaces++;
                    var grabTheDigit = placesToGet.Any(p => p == totalPlaces);
                    if (grabTheDigit)
                    {
                        finalProduct *= splitDigits[i];
                        //Console.Write("current = " + current + ".");
                        //Console.WriteLine("grabbed value " + splitDigits[i] + " at position " + totalPlaces);
                    }
                }

                // increment the prefix number every 10 times the 
                // append number is incremented.
                append = incrementor.Increment(append, digitLimit);
                if (append == 0) prefixNum++;
            }

            Console.WriteLine(finalProduct);
        }
    }
}
