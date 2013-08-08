using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingDojoDateAppointer
{
    public class Appointer
    {
        public DateTime FindDateFor(int year, int month)
        {
            var workDays = Days(year, month)
                .Where(IsWorkDay);

            var weeks = workDays.ToLookup(WeekNumberOf);

            var targetWeek = weeks.Skip(1).First();

            var targetDayOfWeek = TargetDayOfWeekFor(month);
            return targetWeek.First(x => x.DayOfWeek == targetDayOfWeek);
        }

        public int WeekNumberOf(DateTime date)
        {
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var offset = (int)(firstDayOfMonth.DayOfWeek) - 1;
            return (int)Math.Ceiling((date.Day + offset) / 7.0);
        }

        public DayOfWeek TargetDayOfWeekFor(int month)
        {
            return (DayOfWeek)((month - 1) % 4 + 1);
        }

        private bool IsWorkDay(DateTime day)
        {
            return day.DayOfWeek != DayOfWeek.Saturday &&
                   day.DayOfWeek != DayOfWeek.Sunday;
        }

        private IEnumerable<DateTime> Days(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                             .Select(x => new DateTime(year, month, x));
        }
    }
}