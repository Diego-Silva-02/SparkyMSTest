using NUnit.Framework;

namespace Sparky
{
    [TestFixture]
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator gradingCalculator;
        [SetUp]

        public void Setup()
        {
            gradingCalculator = new GradingCalculator();
        }

        [Test]
        public void GradeCalc_InputScore95Attendance90_GetAGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercent = 90;

            string result = gradingCalculator.GetGrade();

            Assert.AreEqual(result, "A");
        }

        [Test]
        public void GradeCalc_InputScore85Attendance90_GetBGrade()
        {
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercent = 90;

            string result = gradingCalculator.GetGrade();

            Assert.AreEqual(result, "B");
        }

        [Test]
        public void GradeCalc_InputScore65Attendance90_GetCGrade()
        {
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercent = 90;

            string result = gradingCalculator.GetGrade();

            Assert.AreEqual(result, "C");
        }

        [Test]
        public void GradeCalc_InputScore95Attendance65_GetBGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercent = 65;

            string result = gradingCalculator.GetGrade();

            Assert.AreEqual(result, "B");
        }

        [Test]
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        [TestCase(50, 90)]
        public void GradeCalc_FailuresScenarios_GetFGrade(int score, int attendancePercent)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercent = attendancePercent;

            string result = gradingCalculator.GetGrade();

            Assert.AreEqual(result, "F");
        }

        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string GradeCalc_AllGradeLogicalScenarios_GradeOutput(int score, int attendancePercent)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercent = attendancePercent;

            return gradingCalculator.GetGrade();
        }
    }
}
