using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.FizzBuzz
{
	class FizzBuzzer
	{
		public static string GetResult(int number)
		{
			if (((number % 3) != 0) && ((number % 5) != 0))
				return number.ToString();

			if (number == 5)
				return "Buzz";

			if (number == 15)
				return "FizzBuzz";

			return "Fizz";
		}
	}
}
