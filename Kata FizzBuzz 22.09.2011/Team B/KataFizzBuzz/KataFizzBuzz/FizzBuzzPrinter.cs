namespace Tests
{
    public class FizzBuzzPrinter
    {

        const string Fizz = "Fizz";
        const string Buzz = "Buzz";

        public string Translate(int i)
        {
            if (IsFizz(i) && IsBuzz(i))
                return Fizz + Buzz;

            if (IsFizz(i))
            {
                return Fizz;
            }

            if (IsBuzz(i))
                return Buzz;

            return i.ToString();
        }

        static bool IsBuzz(int i)
        {
            return (i % 5 == 0);
        }

        static bool IsFizz(int i)
        {
            return (i % 3 == 0);
        }
    }
}