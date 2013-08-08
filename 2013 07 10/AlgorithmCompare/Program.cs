using System;
using CodingDojoDateAppointer;
using KataDojoCalendar;

namespace AlgorithmCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting comparing the algorithms...");

            int differenceCount = 0;
            for (int year = 2013; year < 10000; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    var calculator = new DojoCalendarCalculator();
                    var calculatorResult = calculator.GetDateFor(year, month);

                    var appointer = new Appointer();
                    var appointerResult = appointer.FindDateFor(year, month);

                    if (calculatorResult.Day != appointerResult.Day)
                    {
                        differenceCount++;
                        Console.WriteLine("Found difference for {0}/{1}", month, year);
                        Console.WriteLine("Calculator: {0}", calculatorResult);
                        Console.WriteLine("Appointer:  {0}", appointerResult);
                    }
                }

                Console.WriteLine("Year {0} completed.", year);
            }
            Console.WriteLine("Found {0} differences.", differenceCount);

            Console.ReadLine();
        }
    }
}