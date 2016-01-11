using NUnit.Framework;

namespace Stringcalculator.Test
{
    public class StringCalculatorTest
    {
        [TestFixture]
        public class TheAddMethodShould
        {
            [Test]
            public void Returns0WhenGivenAnEmptyString()
            {
                Assert.That(StringCalculator.Add(string.Empty), Is.EqualTo(0));
            }

            [TestCase("1", 1)]
            [TestCase("1,2", 3)]
            [TestCase("1,2,3,4", 10)]
            public void SumCommaSeparatedNumbers(string csv, int sum)
            {
                Assert.That(StringCalculator.Add(csv), Is.EqualTo(sum));
            }

            [Test]
            public void SumNumbersSeparatedByNewLines()
            {
                Assert.That(StringCalculator.Add("1\n2,3"), Is.EqualTo(6));
            }

            [Test]
            public void SumNumbersSeparatedByCustomDelimiter()
            {
                Assert.That(StringCalculator.Add("//;\n1;2"), Is.EqualTo(3));
            }

            [Test]
            public void ReportIfAnyNegativeNumbersAreInTheCsv()
            {
                Assert.That(() => StringCalculator.Add("1,-2,-4"),
                    Throws.ArgumentException.With.Message.EqualTo("negatives not allowed: -2, -4"));
            }
        }
    }
}