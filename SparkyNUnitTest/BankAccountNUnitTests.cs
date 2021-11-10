using Moq;
using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class BankAccountNUnitTests
    {
        private BankAccount account;
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void BankDepositLogFakker_Add100_ReturnsTrue()
        {
            BankAccount bankAccount = new (new LogFakker());
            var result = bankAccount.Deposit(100);
            Assert.True(result);
            Assert.AreEqual(100, bankAccount.GetBalance());
        }

        [Test]
        public void BankDeposit_Add100_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.Message("Deposit invoked"));

            BankAccount bankAccount = new(logMock.Object);
            var result = bankAccount.Deposit(100);
            Assert.True(result);
            Assert.AreEqual(100, bankAccount.GetBalance());
        }
    }
}
