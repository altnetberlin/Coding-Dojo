using System;

namespace KataDojoCalendar
{
    public class DojoCalendarCalculator
    {
        public DateTime GetDateFor(int year, int month)
        {
            var targetDayOfWeek = TargetDayOfWeek(month);
            var firstDayOfWeek = FirstDayOfWeek(year, month);
            var offset = 7;
            if (firstDayOfWeek == DayOfWeek.Saturday)
                offset = 14;
            return new DateTime(year, month, offset + 1 + targetDayOfWeek - firstDayOfWeek);
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