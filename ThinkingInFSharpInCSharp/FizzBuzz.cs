using System;
using NUnit.Framework;

namespace ThinkingInFSharpInCSharp
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(6, "Fizz")]
        [TestCase(10, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        public void Translate(int input, string expected)
        {
            Assert.That(FizzBuzzTranslator.Translate(input), Is.EqualTo(expected));
        }

        [Test]
        public void OneToOneHundred()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(FizzBuzzTranslator.Translate(i));
            }
        }
    }

    public class FizzBuzzTranslator
    {
        public static string Translate(int input)
        {
            if (input % 3 == 0 && input % 5 == 0) return "FizzBuzz";
            if (input % 3 == 0) return "Fizz";
            if (input % 5 == 0) return "Buzz";
            return input.ToString();
        }
    }
}
