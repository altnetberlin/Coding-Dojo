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
			
			if (number % 5 == 0 && number % 3 == 0)
				return fizz + buzz;

			if (number % 5 == 0)
				return buzz;

			if (number % 3 == 0)
				return fizz;

			return number.ToString();
		}
	}
}
