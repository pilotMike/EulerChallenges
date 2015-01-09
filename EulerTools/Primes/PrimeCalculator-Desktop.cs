using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools.Primes
{
    public class PrimeCalculator
    {
        private List<int> _primes = new List<int>() { 2, 3 };

        /// <summary>
        /// Returns whether a number is prime. Set addNewPrimes to false
        /// for parallel use.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="addNewPrimes">whether or not to add new found 
        /// primes to the internal collection. Set to false for Parallel operations.</param>
        /// <returns></returns>
        public bool IsPrime(int i, bool addNewPrimes = false)
        {
            if (i > 0 && i < 4) return true;

            // there are 2 methods for finding primes: 
            // checking agains a pre-existing list and calculating.
            // this loop checks agains pre-existing primes. If it is
            // not found, then it is calculated.
            foreach (var prime in _primes)
            {
                if (prime == i) return true; // if equal to itself
                if (i % prime == 0) return false; // if even
            }

            // calculate whether a number is prime by dividing
            // it by numbers from 2 up to its square root. 
            // e.g. for 100, divide up to 10.
            int limit = (int)Math.Sqrt(i) + 1;
            for (int j = 2; j < limit; j++)
                if (i % j == 0)
                    return false;

            if (addNewPrimes)
                _primes.Add(i);
            return true;
        }

        /// <summary>
        /// Returns all of the prime numbers from
        /// 0 up to and including the limit.
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public IEnumerable<int> GetPrimesUpTo(int limit)
        {
            var primes = new List<int>() { 2, 3 };
            for (int i = 4; i <= limit; i++)
                if (IsPrime(i, true))
                    primes.Add(i);

            return primes;
        }
    }
}
