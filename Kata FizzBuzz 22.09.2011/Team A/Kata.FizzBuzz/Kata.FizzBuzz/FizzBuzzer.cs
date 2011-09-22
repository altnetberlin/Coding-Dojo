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
			string fizz = "Fizz";
			string buzz = "Buzz";

			var result = new StringBuilder();

			if ((number % 3 == 0) || (number.ToString().Contains('3')))
				result.Append(fizz);

			if (number % 5 == 0)
				result.Append(buzz);

			return result.ToString().Any() ? result.ToString() : number.ToString();
		}
	}
}
