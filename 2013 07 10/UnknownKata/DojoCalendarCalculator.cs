using System;

namespace KataDojoCalendar
{
    public class DojoCalendarCalculator
    {
        public DateTime GetDateFor(int year, int month)
        {
            var targetDayOfWeek = TargetDayOfWeek(month);
            var firstDayOfWeek = FirstDayOfWeek(year, month);
            var day = Day(targetDayOfWeek, firstDayOfWeek);
            return new DateTime(year, month, day);
        }

        private static int Day(DayOfWeek targetDayOfWeek, DayOfWeek firstDayOfWeek)
        {
            var offset = firstDayOfWeek == DayOfWeek.Saturday ? 14 : 7;
            return offset + 1 + targetDayOfWeek - firstDayOfWeek;
        }

        private DayOfWeek TargetDayOfWeek(int month)
        {
            return (DayOfWeek) (1 + ((month - 1)%4));
        }

        private DayOfWeek FirstDayOfWeek(int year, int month)
        {
            return new DateTime(year, month, 1).DayOfWeek;
        }
    }
}