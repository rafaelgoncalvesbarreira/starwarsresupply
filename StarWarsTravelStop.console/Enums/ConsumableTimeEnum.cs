using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsTravelStop.console.Enums
{
    public class ConsumableTimeEnum
    {
        public int DaysMultiplier { get; private set; }
        public string TimeDescriptor { get; private set; }

        private ConsumableTimeEnum(string timeDescriptor, int daysMultiplier)
        {
            TimeDescriptor = timeDescriptor;
            DaysMultiplier = daysMultiplier;
        }

        public static ConsumableTimeEnum DAY = new ConsumableTimeEnum("day", 1);
        public static ConsumableTimeEnum WEEK = new ConsumableTimeEnum("week", 7);
        public static ConsumableTimeEnum MONTH = new ConsumableTimeEnum("month", 30);
        public static ConsumableTimeEnum YEAR = new ConsumableTimeEnum("year", 360);

        public static List<ConsumableTimeEnum> GetAll()
        {
            return new List<ConsumableTimeEnum>()
            {
                DAY, WEEK, MONTH, YEAR
            };
        }
    }
}
