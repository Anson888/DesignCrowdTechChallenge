using System;
using System.Collections.Generic;
using System.Text;

namespace DesignCrowdTechChallenge
{
    class BusinessDayCounter
    {
        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            if (secondDate <= firstDate)
                return 0;
            int numberOfWeekDays = 0;
            while (firstDate < secondDate)
            {
                firstDate = firstDate.AddDays(1);
                if (firstDate.DayOfWeek != DayOfWeek.Saturday && firstDate.DayOfWeek != DayOfWeek.Sunday && firstDate != secondDate)
                    numberOfWeekDays++;
            }
            return numberOfWeekDays;
        }

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            if (secondDate <= firstDate)
                return 0;
            int numberOfWeekDays = 0;
            while (firstDate < secondDate)
            {
                firstDate = firstDate.AddDays(1);
                if (firstDate.DayOfWeek != DayOfWeek.Saturday && firstDate.DayOfWeek != DayOfWeek.Sunday && firstDate != secondDate && !publicHolidays.Contains(firstDate))
                    numberOfWeekDays++;
            }
            return numberOfWeekDays;
        }

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<PublicHolidayRule> publicHolidayRules)
        {
            if (secondDate <= firstDate)
                return 0;
            int numberOfWeekDays = 0;
            List<DateTime> publicHolidays = new List<DateTime>();
            foreach (PublicHolidayRule publicHolidayRule in publicHolidayRules)
            {
                if (firstDate.Year == secondDate.Year)
                    publicHolidays.Add(publicHolidayRule.GetDateTime(firstDate.Year));
                else { 
                    publicHolidays.Add(publicHolidayRule.GetDateTime(firstDate.Year));
                    publicHolidays.Add(publicHolidayRule.GetDateTime(secondDate.Year));
                }
            }
            while (firstDate < secondDate)
            {
                firstDate = firstDate.AddDays(1);
                if (firstDate.DayOfWeek != DayOfWeek.Saturday && firstDate.DayOfWeek != DayOfWeek.Sunday && firstDate != secondDate && !publicHolidays.Contains(firstDate))
                    numberOfWeekDays++;
            }
            return numberOfWeekDays;
        }

    }
}
