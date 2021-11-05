using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            // Arrange
            Customer customer = new Customer();

            // Act
            string fullName = customer.GreetAndCombineNames("Ben", "Sparky");

            // Assert
            Assert.AreEqual(fullName, "Hello, Ben Sparky");
            Assert.That(fullName, Does.Contain(","));
            Assert.That(fullName, Does.StartWith("Hello,"));
            Assert.That(fullName, Does.EndWith("sparky").IgnoreCase);
            Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }
    }
}
