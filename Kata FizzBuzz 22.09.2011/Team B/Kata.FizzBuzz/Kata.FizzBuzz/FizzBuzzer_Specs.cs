using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace Kata.FizzBuzz
{
	[Subject("FizzBuzzer")]
	public class when_number_div_3
	{
		Because of = () =>
			{
				result = FizzBuzzer.GetResult(3);

			};

		It should_returns_Fizz = () =>
			{
				result.ShouldEqual("Fizz");
			};

		static string result;
	}

	public class when_number_div_5
	{
		Because of = () =>
		    result = FizzBuzzer.GetResult(5);

		It should_return_Buzz = () =>
			result.ShouldEqual("Buzz");

		static string result;
			
	}

	public class when_number_is_1
	{
		Because of = () =>
					result = FizzBuzzer.GetResult(1);

		It should_return_1 = () =>
			result.ShouldEqual("1");

		static string result;
	}

	public class when_number_is_15
	{
		Because of = () =>
			result = FizzBuzzer.GetResult(15);

		It should_return_1 = () =>
			result.ShouldEqual("FizzBuzz");

		static string result;
	}

	public class when_number_is_31
	{
		Because of = () =>
			result = FizzBuzzer.GetResult(31);

		It should_return_1 = () =>
			result.ShouldEqual("31");

		static string result;
	}

	public class when_numer_is_10
	{
		Because of = () =>
		             result = FizzBuzzer.GetResult(10);

		It should_returns_Buzz = () =>
		                         result.ShouldEqual("Buzz");

		static string result;
	}

	public class when_numer_is_30
	{
		Because of = () =>
					 result = FizzBuzzer.GetResult(30);

		It should_returns_Buzz = () =>
								 result.ShouldEqual("FizzBuzz");

		static string result;
	}

	public class when_numer_is_9
	{
		Because of = () =>
					 result = FizzBuzzer.GetResult(9);

		It should_returns_Buzz = () =>
								 result.ShouldEqual("Fizz");

		static string result;
	}
}
