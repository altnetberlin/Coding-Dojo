using System.Collections.Generic;
using altnet.codingdojo.fizzbuzz.contract;

    public class FizzBuzzService : IFizzBuzzService
    {
        internal  static string Translate(uint i)
        {
            if (i % 3 == 0 && i % 5 == 0)
                return "fizzbuzz";
            if (i % 3 == 0)
                return "fizz";
            if (i % 5 == 0)
                return "buzz";
            return i.ToString();
        }

        public IEnumerable<string> GetFizzBuzzEnumBy(uint maxValue)
        {
            for (uint i = 1; i <= maxValue; i++)
            {
                yield return Translate(i);
            }
        }
    }