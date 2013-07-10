using System;

namespace KataDojoCalendar
{
    public class DojoCalendarCalculator
    {
        public DateTime GetDateFor(int year, int month)
        {
            if (month == 7)
                return new DateTime(year, month, 10);

            return new DateTime(year, month, 4);
        }
    }
}