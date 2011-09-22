using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace fizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            new FizzBuzzer().Do().ForEach(Console.WriteLine);
            Console.ReadLine();
        }
    }

    internal class FizzBuzzer
    {
        public List<string> Do()
        {
            List<string> resutList = new List<string>();



            for (int i = 1; i <= 100; i++)
            {
                var dividableByThree = i % 3 == 0;
                var dividableByFive = i % 5 == 0;
                
                if (dividableByThree && dividableByFive)
                    resutList.Add("FizzBuzz");
                else if (dividableByThree)
                    resutList.Add("Fizz");
                else if (dividableByFive)
                    resutList.Add("Buzz");
                else 
                    resutList.Add(i.ToString());
            }

            return resutList;
        }
    }

    class ProgramSpecs
    {
        private static FizzBuzzer sut;
        private static List<string> result;

        // Arrange
        Establish context = () => { sut = new FizzBuzzer(); };

        // Act
        private Because of = () => { result = sut.Do(); };

        // Assert
        private It should_return_100_elements = () => { result.Count.ShouldEqual(100); };
        private It should_return_1_on_first_place = () => { result[0].ShouldEqual("1"); };
        private It should_return_2_on_second_place = () => { result[1].ShouldEqual("2"); };
        private It should_return_Fizz_on_third_place = () => { result[2].ShouldEqual("Fizz"); };
        private It should_return_Fizz_for_numbers_divideable_by_three = () =>
                                                                            {
                                                                                result.Where((s, i) => (i+1)%3 == 0 && (i+1)%5 !=0).All(
                                                                                    s => s == "Fizz").ShouldBeTrue();
                                                                            };
        private It should_return_Buzz_for_numbers_divideable_by_five = () =>
        {
            result.Where((s, i) => (i + 1) % 5 == 0 && (i+1)%3 !=0).All(
                s => s == "Buzz").ShouldBeTrue();
        };

        private It should_return_FizzBuzz_for_numbers_divideable_by_three_and_five = () =>
        {
            result.Where((s, i) => (i + 1) % 5 == 0 && (i + 1) % 3 == 0).All(
                s => s == "FizzBuzz").ShouldBeTrue();
        };
    }
}
