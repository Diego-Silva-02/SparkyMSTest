using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class FiboNUnitTests
    {
        private Fibo fibo;
        [SetUp]

        public void Setup()
        {
            fibo = new Fibo();
        }

        [Test]
        public void FiboChecker_Input1_ReturnsFiboSeries()
        {
            fibo.Range = 1;

            List<int> expectedFiboSeries = new () { 0 };

            List<int> results = fibo.GetFiboSeries();

            Assert.IsNotEmpty(results);
            Assert.That(results, Is.Ordered);
            Assert.AreEqual(expectedFiboSeries, results);
        }

        [Test]
        public void FiboChecker_Input6_ReturnsFiboSeries()
        {
            fibo.Range = 6;

            List<int> expectedFiboSeries = new() { 0, 1, 1, 2, 3, 5 };

            List<int> results = fibo.GetFiboSeries();

            Assert.Contains(3, results);
            Assert.AreEqual(results.Count, 6);
            Assert.That(results, Has.No.Member(4));
            Assert.AreEqual(expectedFiboSeries, results);
        }
    }
}
