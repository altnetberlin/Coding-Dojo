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

    class FizzBuzzer
    {
        public List<string> Do()
        {
            List<string> resutList = new List<string>();

            for (int i = 0; i < 100; i++)
            {
                resutList.Add("");
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
        private It should_return_empty_string = () => { result.Count.ShouldEqual(100); };
    }
}
