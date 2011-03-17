using System;
using System.Collections.Generic;

namespace altnet.codingdojo.fizzbuzz.contract
{
    public interface IFizzBuzzService
    {
        IEnumerable<string> GetFizzBuzzEnumBy(uint maxValue);
    }
}
