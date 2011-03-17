using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit;
using NUnit.Framework;

namespace FizzBuzzServiceTest
{

    [TestFixture]
    public class FizzBuzzServiceTest
    {
        public IEnumerable<string> expectedResult = new List<string>
                                                        {
                                                            "1",
                                                            "2",
                                                            "fizz",
                                                            "4",
                                                            "buzz",
                                                            "fizz",
                                                            "7",
                                                            "8",
                                                            "fizz",
                                                            "buzz",
                                                            "11",
                                                            "fizz",
                                                            "13",
                                                            "14",
                                                            "fizzbuzz",
                                                            "16",
                                                            "17",
                                                            "fizz",
                                                            "19",
                                                            "buzz"
                                                        };

        [Test]
        public void Should_return_fizz_if_3_is_given()
        {
            var result = FizzBuzzService.Translate(3);
            Assert.That(result == "fizz");
        }

        [Test]
        public void Should_return_buzz_if_5_is_given()
        {
            var result = FizzBuzzService.Translate(5);
            Assert.That(result == "buzz");
        }

        [Test]
        public void Should_return_1_if_1_is_given()
        {
            var result = FizzBuzzService.Translate(1);
            Assert.That(result == "1");
        }

        [Test]
        public void Should_return_fizzbuzz_if_15_is_given()
        {
            var result = FizzBuzzService.Translate(15);
            Assert.That(result == "fizzbuzz");
        }

      
        [Test]
        public void Should_return_expected_list_if_20_is_given()
        {
            var sut = new FizzBuzzService();
            var result = sut.GetFizzBuzzEnumBy(20);
            Assert.IsTrue( expectedResult.SequenceEqual(result ));
        }
    }
}
