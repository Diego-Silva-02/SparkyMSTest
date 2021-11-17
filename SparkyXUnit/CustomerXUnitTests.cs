using Xunit;

namespace Sparky
{
    public class CustomerXUnitTests
    {
        private Customer customer;
        public CustomerXUnitTests()
        {
            customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            // Arrange

            // Act
            customer.GreetAndCombineNames("Ben", "Sparky");

            // Assert
            // XUnit dnot have multiple asserts
            Assert.Equal("Hello, Ben Sparky", customer.GreetMessage);
            Assert.Contains(",", customer.GreetMessage);
            Assert.StartsWith("Hello,", customer.GreetMessage);
            Assert.EndsWith("Sparky", customer.GreetMessage);
            //Assert.That(customer.GreetMessage, Does.EndWith("sparky").IgnoreCase);
            Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetMessage);
        }

        [Fact]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.Null(customer.GreetMessage);
        }

        [Fact]
        public void DiscountCheck_DefaultCustumer_ReturnsDiscountInRange()
        {
            // Arrange
            int result = customer.Discount;

            // Act

            // Assert
            Assert.InRange(result, 10, 25);
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("ben", "");

            Assert.NotNull(customer.GreetMessage);
            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            // Arrange

            // Act
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Sparky"));

            // Assert
            Assert.Equal("Empty First Name", exceptionDetails.Message);

            // Testing the application without testing its value
            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Sparky"));
        }

        [Fact]
        public void CustumerType_CreateCustomerWithLessThan100Order_ReturnsBasicCustomer()
        {
            // Arrange
            customer.OrderTotal = 10;

            // Act
            var result = customer.GetCustomerDetails();

            // Assert
            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]
        public void CustumerType_CreateCustomerWithMoreThan100Order_ReturnsPlatinumCustomer()
        {
            // Arrange
            customer.OrderTotal = 110;

            // Act
            var result = customer.GetCustomerDetails();

            // Assert
            Assert.IsType<PlatinumCustomer>(result);
        }
    }
}
