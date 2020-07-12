using System;
using System.Collections.Generic;
using System.Text;

namespace DesignCrowdTechChallenge
{
    public class PublicHolidayRule
    {

        public PublicHolidayRule(int month, int date, bool carryOverDay)
        {
            IsFixed = true;
            Month = month;
            Day = date;
            CarryOverDay = carryOverDay;
        }
        public PublicHolidayRule(int month, DayOfWeek dayOfWeek, int occurence, bool carryOverDay) // for a date rule based on occurence in month, e.g. 4th Thursday of November 
                                                                                                   //not sure how to handle 'last' rule, maybe anything over 5 since the maximum occurence for any one day in a month is 5 
        {
            IsFixed = false;
            CarryOverDay = carryOverDay;
            Month = month;
            DayOfWeekRule = dayOfWeek;
            Occurence = occurence;
        }

        public DateTime GetDateTime(int year)
        {
            if (IsFixed)
                return new DateTime(year, Month, Day);
            else
            {
                DateTime date = new DateTime(year, Month, 01);
                int startDayOfWeek = (int)date.DayOfWeek;
                date = date.AddDays((int)DayOfWeekRule - startDayOfWeek); //gets first occurence of day of week
                if (Occurence == 1)//returns first occurrence 
                    return date;
                else
                {
                    return date.AddDays(7 * (Occurence - 1));//places a great deal of trust in user, could be remedied by doing a for loop
                }
            }
        }

        public bool CarryOverDay { get; set; }
        private bool IsFixed { get; set; }
        private int Month { get; set; }
        private int Day { get; set; }
        private DayOfWeek DayOfWeekRule { get; set; }
        private int Occurence { get; set; }


    }
}
