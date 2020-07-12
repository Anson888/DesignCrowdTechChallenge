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
            if (IsFixed && !CarryOverDay)
            {
                return new DateTime(year, Month, Day);
            }
            else if (IsFixed && CarryOverDay)
            {
                var startDate = new DateTime(year, Month, Day);
                if (startDate.DayOfWeek == DayOfWeek.Saturday)
                    return startDate.AddDays(2);
                else if (startDate.DayOfWeek == DayOfWeek.Sunday)
                    return startDate.AddDays(1);
                else return startDate;

            }
            //above for fixed occurences
            else
            {
                DateTime date = new DateTime(year, Month, 01);
                int startDayOfWeek = date.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)date.DayOfWeek;
                int dayOfWeekRuleInt = DayOfWeekRule == DayOfWeek.Sunday ? 7 : (int)DayOfWeekRule;
                int additionalDays = dayOfWeekRuleInt - startDayOfWeek;
                date = date.AddDays(additionalDays); //gets first occurence of day of week
                if (Occurence == 1)//returns first occurrence 
                {
                    if (CarryOverDay)
                    {
                        if (date.DayOfWeek == DayOfWeek.Saturday)
                            return date.AddDays(2);
                        else if (date.DayOfWeek == DayOfWeek.Sunday)
                            return date.AddDays(1);
                        else return date;
                    }
                    else return date;
                }
                else
                {
                    date = date.AddDays(7 * (Occurence - 1));//places a great deal of trust in user, could be remedied by doing a for loop
                    if (CarryOverDay)
                    {
                        if (date.DayOfWeek == DayOfWeek.Saturday)
                            return date.AddDays(2);
                        else if (date.DayOfWeek == DayOfWeek.Sunday)
                            return date.AddDays(1);
                        else return date;
                    }
                    else return date;
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
