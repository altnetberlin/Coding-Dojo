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
			if (number % 5 == 0 && number % 3 == 0)
				return "FizzBuzz";

			if (number % 5 == 0)
				return "Buzz";

			if (number % 3 == 0)
				return "Fizz";

			return number.ToString();
		}
	}
}
