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
        
        //[Test]
        //public void BankDepositLogFakker_Add100_ReturnsTrue()
        //{
        //    BankAccount bankAccount = new (new LogFakker());
        //    var result = bankAccount.Deposit(100);
        //    Assert.True(result);
        //    Assert.AreEqual(100, bankAccount.GetBalance());
        //}

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

        [Test]
        [TestCase (200, 100)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceAfterWithdraw(It.Is<int>(y=>y>0))).Returns(true);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withdraw(withdraw);

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(200, 300)]
        public void BankWithdraw_Withdraw200With300Balance_ReturnsFalse(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogBalanceAfterWithdraw(It.Is<int>(y => y > 0))).Returns(true);
            logMock.Setup(x => x.LogBalanceAfterWithdraw(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withdraw(withdraw);

            Assert.IsFalse(result);
        }

        [Test]
        public void BankLogDummy_LogMockString_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";
            logMock.Setup(x => x.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());
            // By default if the string is not configured your return is null

            Assert.That(logMock.Object.MessageWithReturnStr("HELLo"), Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_LogMockStringStr_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";
            logMock.Setup(x => x.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);
            string result = "";

            Assert.IsTrue(logMock.Object.LogWithOutputResult("Ben", out result));
            Assert.That(result, Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_LogRefChecker_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            Customer customer = new();
            Customer customerNotUsed = new();

            logMock.Setup(x => x.LogWithRefObject(ref customer)).Returns(true);
            // By default, other variable returns false

            Assert.IsTrue(logMock.Object.LogWithRefObject(ref customer));
            Assert.IsFalse(logMock.Object.LogWithRefObject(ref customerNotUsed));
        }

        [Test]
        public void BankLogDummy_SetAndGetLogTypeAndSeverityMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();
            logMock.SetupAllProperties();
            logMock.Setup(x => x.LogSeverity).Returns(10);
            logMock.Setup(x => x.LogType).Returns("warning");
            // if you want to assign a value to an mock it's this way (line 107)
            logMock.Object.LogSeverity = 100;

            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(100));
            Assert.That(logMock.Object.LogType, Is.EqualTo("warning"));

            // callbacks
            string logTemp = "Hello, ";
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true)
                .Callback((string str) => logTemp += str);
            logMock.Object.LogToDb("Ben");

            Assert.That(logTemp, Is.EqualTo("Hello, Ben"));

            // callbacks
            int counter = 5;
            logMock.Setup(x => x.LogToDb(It.IsAny<string>()))
                .Callback(()=> counter++)
                .Returns(true)
                .Callback(() => counter++);
            logMock.Object.LogToDb("Ben");
            logMock.Object.LogToDb("Ben");

            Assert.That(counter, Is.EqualTo(9));
        }

        [Test]
        public void BankLogDummy_VerifyExample()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(100);

            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));

            // Verification
            logMock.Verify(x => x.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(x => x.Message("Test"), Times.AtLeastOnce);
            logMock.VerifySet(x => x.LogSeverity = 101, Times.Once);
            logMock.VerifyGet(x => x.LogSeverity, Times.Once);
        }
    }
}
