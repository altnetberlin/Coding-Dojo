using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.FizzBuzz
{
	class Program
	{
		static void Main(string[] args)
		{

			for (int i = 1; i <= 100; i++)
			{
				string result = FizzBuzzer.GetResult(i);
				int j;
				bool isNumber = int.TryParse(result, out j);
			
				Console.ForegroundColor = isNumber ? ConsoleColor.Red : ConsoleColor.Green;
				
				Console.WriteLine(FizzBuzzer.GetResult(i));
			}

			Console.ReadLine();
		}
	}
}
