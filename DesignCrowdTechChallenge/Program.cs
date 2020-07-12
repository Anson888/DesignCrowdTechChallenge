using System;
using System.Collections.Generic;

namespace DesignCrowdTechChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DateTime first = new DateTime(2013, 10, 7);
            DateTime second = new DateTime(2014, 1, 1);
            //DateTime second = new DateTime(2014, 1, 1);
            List<DateTime> holidays = new List<DateTime>();
            holidays.Add(new DateTime(2013, 12, 25));
            holidays.Add(new DateTime(2013, 12, 26));
            holidays.Add(new DateTime(2014, 1, 1));
            BusinessDayCounter b = new BusinessDayCounter();
            int x = b.WeekdaysBetweenTwoDates(first, second);
            PublicHolidayRule p = new PublicHolidayRule(11, DayOfWeek.Thursday, 4, false);

            DateTime d = p.GetDateTime(2020);
            List<PublicHolidayRule> pList = new List<PublicHolidayRule>();
            //pList.Add(p);
            pList.Add(new PublicHolidayRule(12, 25, false));
            pList.Add(new PublicHolidayRule(12, 26, false));
            pList.Add(new PublicHolidayRule(1, 1, false));

            //    int difference = b.WeekdaysBetweenTwoDates(first, second);
            int difference2 = b.BusinessDaysBetweenTwoDates(first, second, holidays);
            int difference3 = b.BusinessDaysBetweenTwoDates(first, second, pList);

        }
    }
}
