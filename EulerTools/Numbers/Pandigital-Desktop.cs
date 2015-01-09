using System.Diagnostics;
using System.Linq;

namespace EulerTools.Numbers
{
    public class Pandigital
    {
        private static readonly char[] Digits = {'1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public bool IsPandigital(int multiplicand, int multiplier, int product)
        {
            string prospective = multiplicand.ToString() + multiplier.ToString() + product.ToString();
            if (prospective.Length != 9) return false;
            var containsAll = !Digits.Except(prospective).Any();
            return containsAll;
        }
    }

    public class OnlinePandigital
    {
        // source: http://www.mathblog.dk/project-euler-32-pandigital-products/

        public bool IsPandigital(int a, int b)
        {
            long concatted = concat(concat(a*b, b), a);
            return IsPandigital(concatted);
        }

        // use bitshifting to check if pandigital
        public bool IsPandigital(long n)
        {
            // source notes
            //It takes a while (at least for me) to digest this pieces of code.
            //On line 8 I chop off the last digit of the number we want to check,
            //and make a bit shift to get the right bit changed to one. The reason 
            //I or the storage integer and bitshifted one is to be able to check if 
            //the digit already has been found. In line 9-11 I check if the number 
            //has changed – if not we have two of the same digits or a zero in the 
            //input number, in either case the number isn’t pandigital.
            int digits = 0;
            int count = 0;
            int tmp;

            while (n > 0)
            {
                tmp = digits;
   /*line 8*/   digits = digits | 1 << (int)((n % 10) - 1);
                if (tmp == digits) // check if the number has changed from the previous
                {
                    return false;
                }

                count++;
                n /= 10;
            }
            return digits == (1 << count) - 1;
        }

        // shifts the furst integer a number of places
        // in order to add the second integer.
        public long concat(long a, long b)
        {
            long c = b;
            while (c > 0)
            {
                a *= 10;
                c /= 10;
            }
            return a + b;
        }
    }
}
