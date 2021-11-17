﻿using Xunit;

namespace Sparky
{
    public class GradingCalculatorXUnitTests
    {
        private GradingCalculator gradingCalculator;

        public GradingCalculatorXUnitTests()
        {
            gradingCalculator = new GradingCalculator();
        }

        [Fact]
        public void GradeCalc_InputScore95Attendance90_GetAGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercent = 90;

            string result = gradingCalculator.GetGrade();

            Assert.Equal("A", result);
        }

        [Fact]
        public void GradeCalc_InputScore85Attendance90_GetBGrade()
        {
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercent = 90;

            string result = gradingCalculator.GetGrade();

            Assert.Equal("B", result);
        }

        [Fact]
        public void GradeCalc_InputScore65Attendance90_GetCGrade()
        {
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercent = 90;

            string result = gradingCalculator.GetGrade();

            Assert.Equal("C", result);
        }

        [Fact]
        public void GradeCalc_InputScore95Attendance65_GetBGrade()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercent = 65;

            string result = gradingCalculator.GetGrade();

            Assert.Equal("B", result);
        }

        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void GradeCalc_FailuresScenarios_GetFGrade(int score, int attendancePercent)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercent = attendancePercent;

            string result = gradingCalculator.GetGrade();

            Assert.Equal("F", result);
        }

        [Theory]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 65, "B")]
        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        public void GradeCalc_AllGradeLogicalScenarios_GradeOutput(int score, int attendancePercent, string expectedResult)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercent = attendancePercent;
            var result = gradingCalculator.GetGrade();

            Assert.Equal(expectedResult, result);
        }
    }
}
