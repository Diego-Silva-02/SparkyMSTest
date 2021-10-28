using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sparky;

namespace SparkyMSTest
{
    [TestClass]
    public class CalculatorMSTests
    {
        [TestMethod]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            // → Test phases
            //Arrange
            Calculator calc = new();

            // Act
            int result = calc.AddNumbers(10, 20);

            // Assert
            Assert.AreEqual(30, result);
            // Expect, actual
        }

        //[TestMethod]
        //public void AddNumbers_InputTwoInt_GetIncorrectAddition()
        //{
        //    // → Test phases
        //    //Arrange
        //    Calculator calc = new();

        //    // Act
        //    int result = calc.AddNumbers(10, 20);

        //    // Assert
        //    Assert.AreEqual(3, result);
        //    // Expect, actual
        //}

    }
}
