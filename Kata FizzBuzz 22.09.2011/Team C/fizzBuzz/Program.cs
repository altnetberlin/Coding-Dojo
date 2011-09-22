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
        }
    }

    internal class FizzBuzzer
    {
        public List<string> Do()
        {
            List<string> resutList = new List<string>();



            for (int i = 1; i <= 100; i++)
            {
                if (i == 3)
                    resutList.Add("Fizz");
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
    }
}
