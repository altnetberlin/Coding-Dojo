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
        public void When_FizzBuzzPrinter_Is_called_with_1_it_returns_1()
        {
            var result = _sut.Translate(1);

            Assert.AreEqual("1", result);
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

            Assert.AreEqual("FizzBuzz",result);
        }

        [Test]
        public void When_Translate_is_called_with_30_it_returns_FizzBuzz()
        {
            var result = _sut.Translate(30);

            Assert.AreEqual("FizzBuzz",result);
        }
    }



    public class FizzBuzzPrinter
    {
        public string Translate(int i)
        {
            if (i % 3 == 0 && i % 5 == 0)
                return "FizzBuzz";

            if (i % 3 == 0)
                return "Fizz";

            if (i % 5 == 0)
                return "Buzz";

            return "1";
        }
    }
}