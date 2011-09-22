using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class FizzBuzzPrinterTests
    {
        [Test]
        public void FizzBuzzPrinterCanBeConstructed()
        {
            new FizzBuzzPrinter();
        }

        [Test]
        public void When_FizzBuzzPrinter_Is_called_with_1_it_returns_1()
        {
            var fizzbuzzer = new FizzBuzzPrinter();

            var result = fizzbuzzer.Translate(1);

            Assert.AreEqual("1", result);
        }

        [Test]
        public void When_Translate_is_called_with_3_it_returns_Fizz()
        {
            var fizzbuzz = new FizzBuzzPrinter();

            var result = fizzbuzz.Translate(3);

            Assert.AreEqual("Fizz", result);
        }

        [Test]
        public void When_Translate_is_call_with_12_it_returns_Fizz()
        {
            var fizzbuzz = new FizzBuzzPrinter();

            var result = fizzbuzz.Translate(12);

            Assert.AreEqual("Fizz", result);
        }
        [Test]
        public void When_Translate_is_called_with_10_it_returns_Buzz()
        {
            var fizzbuzz = new FizzBuzzPrinter();

            var result = fizzbuzz.Translate(10);

            Assert.AreEqual("Buzz", result);
        }

    }



    public class FizzBuzzPrinter
    {
        public string Translate(int i)
        {
            if (i % 3 == 0)
                return "Fizz";

            if (i % 5 == 0)
                return "Buzz";

            return "1";
        }
    }
}