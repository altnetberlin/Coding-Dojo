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

    public class WithDojoCalendarCalculator
    {
        Establish context = () => { sut = new DojoCalendarCalculator(); };

        protected static DojoCalendarCalculator sut;
        protected static DateTime actual;
    }

    [Subject(typeof (DojoCalendarCalculator))]
    public class When_Asking_For_07_2013 : WithDojoCalendarCalculator
    {
        private Because of = () => { actual = sut.GetDateFor(2013, 7); };

        private It should_return_10_07_2013 = () => actual.ShouldEqual(new DateTime(2013, 7, 10));
    }

    [Subject(typeof(DojoCalendarCalculator))]
    public class When_Asking_For_06_2013 : WithDojoCalendarCalculator
    {
        private Because of = () => { actual = sut.GetDateFor(2013, 6); };

        private It should_be_a_Tuesday = () => actual.DayOfWeek.ShouldEqual(DayOfWeek.Tuesday);
        private It should_be_in_June = () => actual.Month.ShouldEqual(6);
    }

    [Subject(typeof(DojoCalendarCalculator))]
    public class When_Asking_For_08_2013 : WithDojoCalendarCalculator
    {
        private Because of = () => { actual = sut.GetDateFor(2013, 8); };

        private It should_be_a_Thursday = () => actual.DayOfWeek.ShouldEqual(DayOfWeek.Thursday);
        private It should_be_in_August = () => actual.Month.ShouldEqual(8);
    }

    [Subject(typeof(DojoCalendarCalculator))]
    public class When_Asking_For_09_2013 : WithDojoCalendarCalculator
    {
        private Because of = () => { actual = sut.GetDateFor(2013, 9); };

        private It should_be_a_Monday = () => actual.DayOfWeek.ShouldEqual(DayOfWeek.Monday);
    }

    [Subject(typeof(DojoCalendarCalculator))]
    public class When_Asking_For_12_2013 : WithDojoCalendarCalculator
    {
        private Because of = () => { actual = sut.GetDateFor(2013, 12); };

        private It should_be_a_Thursday = () => actual.DayOfWeek.ShouldEqual(DayOfWeek.Thursday);
        private It should_be_in_December = () => actual.Month.ShouldEqual(12);
    }

    [Subject(typeof(DojoCalendarCalculator))]
    public class When_Asking_For_01_2014 : WithDojoCalendarCalculator
    {
        private Because of = () => { actual = sut.GetDateFor(2014, 1); };

        private It should_be_a_Monday = () => actual.DayOfWeek.ShouldEqual(DayOfWeek.Monday);
        private It should_be_in_January = () => actual.Month.ShouldEqual(1);
    }
}