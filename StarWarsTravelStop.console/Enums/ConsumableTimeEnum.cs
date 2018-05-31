using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsTravelStop.console.Enums
{
    /// <summary>
    /// Represents the types of interval a Starship can carry of consumables. It's can be from days, weeks, month until years.
    /// </summary>
    public class ConsumableTimeEnum
    {
        /// <summary>
        /// the value used to convert this period to days
        /// </summary>
        public int DaysMultiplier { get; private set; }
        /// <summary>
        /// What kind of times it is, it can be Day, Week, Month or Year
        /// </summary>
        public string TimeDescriptor { get; private set; }

        /// <summary>
        /// A private constructor to emulate a Enum
        /// </summary>
        /// <param name="timeDescriptor"></param>
        /// <param name="daysMultiplier"></param>
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
