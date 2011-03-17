using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using altnet.codingdojo.fizzbuzz.contract;

namespace altnet.codingdojo.fizzbuzz.gui
{
    class NullFizzBuzzService: IFizzBuzzService
    {
        public IEnumerable<string> GetFizzBuzzEnumBy(uint maxValue)
        {
            return Enumerable.Range(1, (int)maxValue).Select(x => x.ToString());
        }
    }
}
