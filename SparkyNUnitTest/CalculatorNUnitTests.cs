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
        public void IsOddChecker_InputOffNumber_ReturnTrue()
        {
            Calculator calc = new();

            bool isOdd = calc.IsOddNumber(11);
            Assert.That(isOdd, Is.EqualTo(true));
            Assert.IsTrue(isOdd);
        }
    }
}
