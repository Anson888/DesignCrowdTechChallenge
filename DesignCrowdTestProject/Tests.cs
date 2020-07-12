using NUnit.Framework;
using DesignCrowdTechChallenge;
using System;
using System.Collections.Generic;

namespace DesignCrowdTestProject
{
    public class Tests
    {
        BusinessDayCounter BusinessDayCounter;

        [SetUp]
        public void Setup()
        {
            BusinessDayCounter = new BusinessDayCounter();
        }

        [Test]
        public void TestWeekdaysBetweenTwoDates()
        {
            DateTime first = new DateTime(2013, 10, 5);
            DateTime second = new DateTime(2013, 10, 14);
            int weekdays = BusinessDayCounter.WeekdaysBetweenTwoDates(first, second);
            Assert.AreEqual(weekdays, 5);
        }
        [Test]
        public void TestBusinessDaysBetweenTwoDates()
        {
            DateTime first = new DateTime(2013, 10, 7);
            DateTime second = new DateTime(2014, 1, 1);
            List<DateTime> holidays = new List<DateTime>();
            holidays.Add(new DateTime(2013, 12, 25));
            holidays.Add(new DateTime(2013, 12, 26));
            holidays.Add(new DateTime(2014, 1, 1));
            int weekdays = BusinessDayCounter.BusinessDaysBetweenTwoDates(first, second, holidays);
            Assert.AreEqual(weekdays, 59);
        }

        [Test]
        public void TestBusinessDaysBetweenTwoDatesPublicHolidayRules()
        {
            DateTime first = new DateTime(2013, 10, 7);
            DateTime second = new DateTime(2014, 1, 1);
            List<PublicHolidayRule> pList = new List<PublicHolidayRule>();
            pList.Add(new PublicHolidayRule(12, 25, false));
            pList.Add(new PublicHolidayRule(12, 26, false));
            pList.Add(new PublicHolidayRule(1, 1, false));
            int weekdays = BusinessDayCounter.BusinessDaysBetweenTwoDates(first, second, pList);
            Assert.AreEqual(weekdays, 59);
        }

        [Test]
        public void TestRulesWithAndWithoutCarryOver()
        {
            DateTime first = new DateTime(2020,7, 9);
            DateTime second = new DateTime(2020, 7, 16);
            List<PublicHolidayRule> pList = new List<PublicHolidayRule>();
            pList.Add(new PublicHolidayRule(7, DayOfWeek.Sunday, 2, true ));
            pList.Add(new PublicHolidayRule(7, 10 , false));
            int weekdays = BusinessDayCounter.BusinessDaysBetweenTwoDates(first, second, pList);
            Assert.AreEqual(weekdays, 2);
        }
    }
}