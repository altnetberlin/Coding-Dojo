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

        private Because of = () => { actual = sut.GetDateFor(7, 2013); };

        private It should_return_10_07_2013 = () => actual.ShouldEqual(new DateTime(2013, 7, 10));

        private static DojoCalendarCalculator sut;
        private static DateTime actual;
    }
}