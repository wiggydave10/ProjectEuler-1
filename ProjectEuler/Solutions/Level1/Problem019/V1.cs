using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Problem019
{
    public static class V1
    {
        public static int CountingSundays(DateTime from, DateTime to)
        {
            var startDay = (int) from.DayOfWeek;
            var days = (to - from).Days;
            var weeks = days/7;
            var remainder = days%7;
            return (7 - startDay < remainder) ? weeks + 1 : weeks;
        }

        public static int CountingFirstSundays(DateTime from, DateTime to)
        {
            var count = 0;
            while (from < to)
            {
                if (from.DayOfWeek == DayOfWeek.Sunday) count++;
                from = from.AddMonths(1);
            }

            return count;
        }
    }
}
