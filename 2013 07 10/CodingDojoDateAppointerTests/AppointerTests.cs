using System;
using CodingDojoDateAppointer;
using NUnit.Framework;
using FluentAssertions;

namespace CodingDojoDateAppointerTests
{
    public class AppointerTests
    {
        [TestCase(2013, 6, 11)]
        [TestCase(2013, 7, 10)]
        [TestCase(2013, 8, 8)]
        [TestCase(2013, 9, 9)]
        [TestCase(2013, 10, 8)]
        [TestCase(2013, 11, 6)]
        [TestCase(2013, 12, 12)]
        [TestCase(2014, 1, 6)]
        [TestCase(2014, 2, 11)]
        [TestCase(2014, 3, 12)]
        [TestCase(2014, 4, 10)]
        public void FindDateFor(int year, int month, int day)
        {
            var appointer = new Appointer();

            var date = appointer.FindDateFor(year, month);

            date.Should()
                .HaveYear(year).And
                .HaveMonth(month).And
                .HaveDay(day);
        }

        [TestCase(1, ExpectedResult = DayOfWeek.Monday)]
        [TestCase(2, ExpectedResult = DayOfWeek.Tuesday)]
        [TestCase(3, ExpectedResult = DayOfWeek.Wednesday)]
        [TestCase(4, ExpectedResult = DayOfWeek.Thursday)]
        [TestCase(5, ExpectedResult = DayOfWeek.Monday)]
        [TestCase(6, ExpectedResult = DayOfWeek.Tuesday)]
        [TestCase(7, ExpectedResult = DayOfWeek.Wednesday)]
        [TestCase(8, ExpectedResult = DayOfWeek.Thursday)]
        [TestCase(9, ExpectedResult = DayOfWeek.Monday)]
        [TestCase(10, ExpectedResult = DayOfWeek.Tuesday)]
        [TestCase(11, ExpectedResult = DayOfWeek.Wednesday)]
        [TestCase(12, ExpectedResult = DayOfWeek.Thursday)]
        public DayOfWeek TargetDayOfWeekFor(int month)
        {
            return new Appointer().TargetDayOfWeekFor(month);
        }

        [TestCase(2013, 6, 1, ExpectedResult = 1)]
        [TestCase(2013, 6, 2, ExpectedResult = 1)]
        [TestCase(2013, 6, 3, ExpectedResult = 2)]
        [TestCase(2013, 6, 4, ExpectedResult = 2)]
        [TestCase(2013, 6, 5, ExpectedResult = 2)]
        [TestCase(2013, 6, 6, ExpectedResult = 2)]
        [TestCase(2013, 6, 7, ExpectedResult = 2)]
        [TestCase(2013, 6, 8, ExpectedResult = 2)]
        [TestCase(2013, 6, 9, ExpectedResult = 2)]
        [TestCase(2013, 6, 10, ExpectedResult = 3)]
        [TestCase(2013, 6, 11, ExpectedResult = 3)]
        [TestCase(2013, 6, 12, ExpectedResult = 3)]
        [TestCase(2013, 6, 13, ExpectedResult = 3)]
        [TestCase(2013, 6, 14, ExpectedResult = 3)]
        [TestCase(2013, 6, 15, ExpectedResult = 3)]
        [TestCase(2013, 6, 16, ExpectedResult = 3)]
        [TestCase(2013, 6, 17, ExpectedResult = 4)]
        [TestCase(2013, 6, 18, ExpectedResult = 4)]
        [TestCase(2013, 6, 19, ExpectedResult = 4)]
        [TestCase(2013, 6, 20, ExpectedResult = 4)]
        [TestCase(2013, 6, 21, ExpectedResult = 4)]
        [TestCase(2013, 6, 22, ExpectedResult = 4)]
        [TestCase(2013, 6, 23, ExpectedResult = 4)]

        [TestCase(2013, 7, 1, ExpectedResult = 1)]
        [TestCase(2013, 7, 2, ExpectedResult = 1)]
        [TestCase(2013, 7, 3, ExpectedResult = 1)]
        [TestCase(2013, 7, 4, ExpectedResult = 1)]
        [TestCase(2013, 7, 5, ExpectedResult = 1)]
        [TestCase(2013, 7, 6, ExpectedResult = 1)]
        [TestCase(2013, 7, 7, ExpectedResult = 1)]
        [TestCase(2013, 7, 8, ExpectedResult = 2)]
        [TestCase(2013, 7, 9, ExpectedResult = 2)]
        [TestCase(2013, 7, 10, ExpectedResult = 2)]
        [TestCase(2013, 7, 11, ExpectedResult = 2)]
        [TestCase(2013, 7, 12, ExpectedResult = 2)]
        [TestCase(2013, 7, 13, ExpectedResult = 2)]
        [TestCase(2013, 7, 14, ExpectedResult = 2)]
        [TestCase(2013, 7, 15, ExpectedResult = 3)]
        [TestCase(2013, 7, 16, ExpectedResult = 3)]
        public int WeekNumberOf(int year, int month, int day)
        {
            return new Appointer().WeekNumberOf(new DateTime(year, month, day));
        }
    }
}