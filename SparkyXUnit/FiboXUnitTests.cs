using Xunit;

namespace Sparky
{
    public class FiboXUnitTests
    {
        private Fibo fibo;

        public FiboXUnitTests()
        {
            fibo = new Fibo();
        }

        [Fact]
        public void FiboChecker_Input1_ReturnsFiboSeries()
        {
            fibo.Range = 1;

            List<int> expectedRange = new() { 0 };

            List<int> results = fibo.GetFiboSeries();

            Assert.NotEmpty(results);
            Assert.Equal(results.OrderBy(x => x), results);
            Assert.True(results.SequenceEqual(expectedRange));
        }

        [Fact]
        public void FiboChecker_Input6_ReturnsFiboSeries()
        {
            fibo.Range = 6;

            List<int> expectedRange = new() { 0, 1, 1, 2, 3, 5 };

            List<int> results = fibo.GetFiboSeries();

            Assert.Contains(3, results);
            Assert.Equal(6, results.Count);
            Assert.DoesNotContain(4, results);
            Assert.Equal(expectedRange, results);
        }
    }
}
