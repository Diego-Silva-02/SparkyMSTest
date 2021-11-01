using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
