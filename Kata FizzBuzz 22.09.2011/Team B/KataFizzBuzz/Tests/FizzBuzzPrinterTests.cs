using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class FizzBuzzPrinterTests
    {
        FizzBuzzPrinter _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new FizzBuzzPrinter();
        }

        [Test]
        public void FizzBuzzPrinterCanBeConstructed()
        {
            new FizzBuzzPrinter();
        }

        [Test]
        public void When_Translate_Is_called_with_1_it_returns_1()
        {
            var result = _sut.Translate(1);

            Assert.AreEqual("1", result);
        }

        [Test]
        public void When_Translate_Is_called_with_2_it_returns_2()
        {
            var result = _sut.Translate(2);

            Assert.AreEqual("2", result);
        }

        [Test]
        public void When_Translate_is_called_with_3_it_returns_Fizz()
        {
            var result = _sut.Translate(3);

            Assert.AreEqual("Fizz", result);
        }

        [Test]
        public void When_Translate_is_call_with_12_it_returns_Fizz()
        {
            var result = _sut.Translate(12);

            Assert.AreEqual("Fizz", result);
        }

        [Test]
        public void When_Translate_is_called_with_10_it_returns_Buzz()
        {
            var result = _sut.Translate(10);

            Assert.AreEqual("Buzz", result);
        }

        [Test]
        public void When_Translate_is_called_with_15_it_returns_FizzBuzz()
        {
            var result = _sut.Translate(15);

            Assert.AreEqual("FizzBuzz", result);
        }

        [Test]
        public void When_Translate_is_called_with_30_it_returns_FizzBuzz()
        {
            var result = _sut.Translate(30);

            Assert.AreEqual("FizzBuzz", result);
        }

        [Test]
        [TestCase(3, Result = "Fizz")]
        [TestCase(6, Result = "Fizz")]
        [TestCase(12, Result = "Fizz")]
        public string When_Translate_is_called_with_multiple_of_3(int value)
        {
            return _sut.Translate(value);
        }

        [Test]
        [TestCase(15, Result = "FizzBuzz")]
        [TestCase(30, Result = "FizzBuzz")]
        [TestCase(45, Result = "FizzBuzz")]
        [TestCase(60, Result = "FizzBuzz")]
        [TestCase(75, Result = "FizzBuzz")]
        [TestCase(90, Result = "FizzBuzz")]
        public string When_Translate_is_called_with_multiple_of_15(int value)
        {
            return _sut.Translate(value);
        }

        [Test]
        [TestCase(7, Result = "7")]
        [TestCase(14, Result = "14")]
        [TestCase(23, Result = "23")]
        public string When_Translate_is_called_with_some_random_numbers(int value)
        {
            return _sut.Translate(value);
        }
    }
}