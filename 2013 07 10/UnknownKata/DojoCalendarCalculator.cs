using System;

namespace KataDojoCalendar
{
    public class DojoCalendarCalculator
    {
        public DateTime GetDateFor(int year, int month)
        {
            if (month == 7)
                return new DateTime(year, month, 10);

            return new DateTime(year, month, 7 + 1 + TargetDayOfWeek(month) - FirstDayOfWeek(year, month));
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