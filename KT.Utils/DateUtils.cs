using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KT.Utils
{
    public class DateUtils
    {

        public static bool DateIsInRange(DateTime? testDate, DateTime? startDate, DateTime? endDate)
        {
            if (!testDate.HasValue) return false;

            return ((!startDate.HasValue || startDate.Value <= testDate.Value) && (!endDate.HasValue || endDate.Value > testDate.Value));
        }

        public static int GetLastDayOfMonth(int month, int year)
        {
            return new DateTime(year, month, 1).AddMonths(1).AddDays(-1).Day;
        }

        public static int MonthsInTimeRange(DateTime startDate, DateTime endDate)
        {
            int years = endDate.Year - startDate.Year + 1;

            return 12 * years - startDate.Month - (12 - endDate.Month) + 1;
        }

        public static int GetAgeInMonths(DateTime birthDate)
        {
            return GetAgeInMonths(birthDate, DateTime.Now);
        }

        public static int GetAgeInMonths(DateTime birthDate, DateTime compareDate)
        {
            int months = MonthsInTimeRange(birthDate, compareDate);

            if (compareDate.Day >= birthDate.Day || compareDate.Day == GetLastDayOfMonth(compareDate.Month, compareDate.Year)) return months -1;
            return months - 2;
        }
    }
}
