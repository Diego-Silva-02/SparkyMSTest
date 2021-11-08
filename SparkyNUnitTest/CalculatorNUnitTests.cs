using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            // → Test phases
            //Arrange
            Calculator calc = new();

            // Act
            int result = calc.AddNumbers(11, 20);
            bool isOddNumber = calc.IsOddNumber(result);

            // Assert
            Assert.AreEqual(31, result);
            Assert.IsTrue(isOddNumber);
            // Expect, actual
        }

        [Test]
        public void IsOddChecker_InputEvenNumber_ReturnFalse()
        {
            Calculator calc = new();

            bool isOdd = calc.IsOddNumber(10);
            Assert.That(isOdd, Is.EqualTo(false));
            Assert.IsTrue(!isOdd);
        }

        [Test]
        [TestCase(11)]
        [TestCase(13)]
        [TestCase(25)]
        public void IsOddChecker_InputOddNumber_ReturnTrue(int number)
        {
            Calculator calc = new();

            bool isOdd = calc.IsOddNumber(number);
            Assert.That(isOdd, Is.EqualTo(true));
            Assert.IsTrue(isOdd);
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_InputOddNumber_ReturnTrueIfOdd(int number)
        {
            Calculator calc = new();

            return calc.IsOddNumber(number);
        }

        [Test]
        [TestCase(5.4, 10.5)] // 15.9
        [TestCase(5.43, 10.53)] // 15.96
        [TestCase(5.49, 10.59)] // 16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            // → Test phases
            //Arrange
            Calculator calc = new();

            // Act
            double result = calc.AddNumbersDoubles(a, b);

            // Assert
            Assert.AreEqual(15.9, result, .2);
            // Expect, actual
        }

        [Test]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            // Arrange
            Calculator calc = new();
            List<int> expectedRange = new() { 5, 7, 9 }; // 5-10

            // Act
            List<int> result = calc.GetOddRange(5, 10);

            // Assert
            // Assert.That(result, Is.EquivalentTo(expectedRange));
            Assert.AreEqual(expectedRange, result);
            //Assert.That(result, Does.Contain(7));
            Assert.Contains(7, result);
            //Assert.That(result, Is.Not.Empty);
            Assert.IsNotEmpty(result);
            //Assert.That(result.Count, Is.EqualTo(3));
            Assert.AreEqual(result.Count, 3);
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }
    }
}
