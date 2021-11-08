using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        private Customer customer;
        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }

        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            // Arrange

            // Act
            customer.GreetAndCombineNames("Ben", "Sparky");

            // Assert
            // Multiple assert in the same time
            Assert.Multiple(() =>
            {
                Assert.AreEqual(customer.GreetMessage, "Hello, Ben Sparky");
                Assert.That(customer.GreetMessage, Does.Contain(","));
                Assert.That(customer.GreetMessage, Does.StartWith("Hello,"));
                Assert.That(customer.GreetMessage, Does.EndWith("sparky").IgnoreCase);
                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.IsNull(customer.GreetMessage);
        }

        [Test]
        public void DiscountCheck_DefaultCustumer_ReturnsDiscountInRange()
        {
            // Arrange
            int result = customer.Discount;

            // Act

            // Assert
            Assert.That(result, Is.InRange(10, 25));
        }
        
        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("ben", "");

            Assert.IsNotNull(customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            // Arrange

            // Act
            var exceptionDetails = Assert.Throws<ArgumentException>(()=>customer.GreetAndCombineNames("","Sparky"));

            // Assert
            Assert.AreEqual("Empty First Name", exceptionDetails.Message);
            Assert.That(() => customer.GreetAndCombineNames("","sparky"), 
                Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));

            // Testing the application without testing its value
            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Sparky"));
            Assert.AreEqual("Empty First Name", exceptionDetails.Message);
            Assert.That(() => customer.GreetAndCombineNames("", "sparky"), Throws.ArgumentException);
        }

        [Test]
        public void CustumerType_CreateCustomerWithLessThan100Order_ReturnsBasicCustomer()
        {
            // Arrange
            customer.OrderTotal = 10;

            // Act
            var result = customer.GetCustomerDetails();

            // Assert
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustumerType_CreateCustomerWithMoreThan100Order_ReturnsPlatinumCustomer()
        {
            // Arrange
            customer.OrderTotal = 110;

            // Act
            var result = customer.GetCustomerDetails();

            // Assert
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
