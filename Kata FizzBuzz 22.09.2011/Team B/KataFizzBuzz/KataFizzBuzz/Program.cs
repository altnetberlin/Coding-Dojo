using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests;

namespace KataFizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var printer = new FizzBuzzPrinter();

            for (int i = 1; i <= 100; i++)
            {
                var result = printer.Translate(i);

                Console.WriteLine(result);
            }
        }
    }
}
