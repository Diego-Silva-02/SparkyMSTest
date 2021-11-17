using Xunit;

namespace Sparky
{
    public class CalculatorXUnitTests
    {
        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            // → Test phases
            //Arrange
            Calculator calc = new();

            // Act
            int result = calc.AddNumbers(11, 20);
            bool isOddNumber = calc.IsOddNumber(result);

            // Assert
            Assert.Equal(31, result);
            Assert.True(isOddNumber);
            // Expect, actual
        }

        [Fact]
        public void IsOddChecker_InputEvenNumber_ReturnFalse()
        {
            Calculator calc = new();

            bool isOdd = calc.IsOddNumber(10);
            // Assert.That(isOdd, Is.EqualTo(false));
            Assert.False(isOdd);
        }

        [Theory] // used to pass dinamic parameters
        [InlineData(11)]
        [InlineData(13)]
        [InlineData(25)]
        public void IsOddChecker_InputOddNumber_ReturnTrue(int number)
        {
            Calculator calc = new();

            bool isOdd = calc.IsOddNumber(number);
            // Assert.That(isOdd, Is.EqualTo(true));
            Assert.True(isOdd);
        }

        [Theory] // used to pass dinamic parameters
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsOddChecker_InputOddNumber_ReturnTrueIfOdd(int number, bool expectedResult)
        {
            Calculator calc = new();
            var actualResult = calc.IsOddNumber(number);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory] // used to pass dinamic parameters
        [InlineData(5.4, 10.5)] // 15.9
        //[InlineData(5.43, 10.53)] // 15.96
        //[InlineData(5.49, 10.59)] // 16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            // → Test phases
            //Arrange
            Calculator calc = new();

            // Act
            double result = calc.AddNumbersDoubles(a, b);

            // Assert
            Assert.Equal(15.9, result, 1);
            // Expect, actual
        }

        [Fact]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            // Arrange
            Calculator calc = new();
            List<int> expectedRange = new() { 5, 7, 9 }; // 5-10

            // Act
            List<int> result = calc.GetOddRange(5, 10);

            // Assert
            Assert.Equal(expectedRange, result);
            Assert.Contains(7, result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);
            Assert.DoesNotContain(6, result);
            Assert.Equal(result.OrderBy(u => u), result); // Is.Ordered
            //Assert.That(result, Is.Unique); // This dont exists in XUnit tests
        }
    }
}
