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
            Assert.That(FizzBuzzTranslator.TranslateExtractedMethods(input), Is.EqualTo(expected));
            Assert.That(FizzBuzzTranslator.TranslateBuild(input), Is.EqualTo(expected));
            Assert.That(FizzBuzzTranslator.TranslateBuildPrivateMethods(input), Is.EqualTo(expected));
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

        public static string TranslateExtractedMethods(int input)
        {
            if (ShouldFizz(input) && ShouldBuzz(input)) return "FizzBuzz";
            if (ShouldFizz(input)) return "Fizz";
            if (ShouldBuzz(input)) return "Buzz";
            return input.ToString();
        }

        private static bool ShouldFizz(int input)
        {
            return input % 3 == 0;
        }

        private static bool ShouldBuzz(int input)
        {
            return input % 5 == 0;
        }

        public static string TranslatePrivateMethods(int input)
        {
            Func<int, bool> shouldFizz = i => i % 3 == 0;
            Func<int, bool> shouldBuzz = i => i % 5 == 0;
            if (shouldFizz(input) && shouldBuzz(input)) return "FizzBuzz";
            if (shouldFizz(input)) return "Fizz";
            if (shouldBuzz(input)) return "Buzz";
            return input.ToString();
        }

        public static string TranslateBuild(int input)
        {
            string output = "";
            output = Fizzy(input, output);
            output = Buzzy(input, output);
            output = Other(input, output);
            return output;
        }

        private static string Fizzy(int input, string inputString)
        {
            return inputString + (input % 3 == 0 ? "Fizz" : "");
        }
        private static string Buzzy(int input, string inputString)
        {
            return inputString + (input % 5 == 0 ? "Buzz" : "");
        }
        private static string Other(int input, string inputString)
        {
            return inputString == "" ? input.ToString() : inputString;
        }

        public static string TranslateBuildPrivateMethods(int input)
        {
            Func<int, string, string> fizzy = (i, s) => s + (i % 3 == 0 ? "Fizz" : "");
            Func<int, string, string> buzzy = (i, s) => s + (i % 5 == 0 ? "Buzz" : "");
            Func<int, string, string> other = (i, s) => s == "" ? i.ToString() : s;
            return other(input, buzzy(input, fizzy(input, "")));
        }
    }
}
