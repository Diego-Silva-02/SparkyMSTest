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
            Assert.That(fullName, Is.EqualTo("Hello, Ben Sparky"));
        }
    }
}
