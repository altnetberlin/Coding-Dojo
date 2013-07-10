using System;

namespace KataDojoCalendar
{
    public class DojoCalendarCalculator
    {
        public DateTime GetDateFor(int month, int year)
        {
            return new DateTime(year, month, 10);
        }
    }
}