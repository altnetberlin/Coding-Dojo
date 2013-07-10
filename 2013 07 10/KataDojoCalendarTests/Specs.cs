using System;
using KataDojoCalendar;
using Machine.Specifications;

namespace KataDojoCalendarTests
{
    [Subject(typeof (DojoCalendarCalculator))]
    public class When_Creating_Dojo_Calendar_Calculator
    {
        Establish context = () => { };

        private Because of = () => { var calculator = new DojoCalendarCalculator(); };

        private It should_work = () => { };
    }

    [Subject(typeof (DojoCalendarCalculator))]
    public class When_Asking_For_07_2013
    {
        Establish context = () => { sut = new DojoCalendarCalculator(); };

        private Because of = () => { actual = sut.GetDateFor(2013, 7); };

        private It should_return_10_07_2013 = () => actual.ShouldEqual(new DateTime(2013, 7, 10));

        private static DojoCalendarCalculator sut;
        private static DateTime actual;
    }

    [Subject(typeof(DojoCalendarCalculator))]
    public class When_Asking_For_06_2013
    {
        Establish context = () => { sut = new DojoCalendarCalculator(); };

        private Because of = () => { actual = sut.GetDateFor(2013, 6); };

        private It should_be_a_Tuesday = () => actual.DayOfWeek.ShouldEqual(DayOfWeek.Tuesday);
        private It should_be_in_June = () => actual.Month.ShouldEqual(6);

        private static DojoCalendarCalculator sut;
        private static DateTime actual;
    }

    [Subject(typeof(DojoCalendarCalculator))]
    public class When_Asking_For_08_2013
    {
        Establish context = () => { sut = new DojoCalendarCalculator(); };

        private Because of = () => { actual = sut.GetDateFor(2013, 8); };

        private It should_be_a_Thursday = () => actual.DayOfWeek.ShouldEqual(DayOfWeek.Thursday);

        private static DojoCalendarCalculator sut;
        private static DateTime actual;
    }

    [Subject(typeof(DojoCalendarCalculator))]
    public class When_Asking_For_09_2013
    {
        Establish context = () => { sut = new DojoCalendarCalculator(); };

        private Because of = () => { actual = sut.GetDateFor(2013, 9); };

        private It should_be_a_Monday = () => actual.DayOfWeek.ShouldEqual(DayOfWeek.Monday);

        private static DojoCalendarCalculator sut;
        private static DateTime actual;
    }
}