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
        public string Do()
        {
            return "";
        }
    }

    class ProgramSpecs
    {
        private static FizzBuzzer sut;
        private static string result;

        // Arrange
        Establish context = () => { sut = new FizzBuzzer(); };

        // Act
        private Because of = () => { result = sut.Do(); };

        // Assert
        private It should_return_empty_string = () => { result.ShouldEqual(""); };
    }
}
