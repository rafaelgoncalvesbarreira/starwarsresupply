using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsTravelStop.console.Enums
{
    /// <summary>
    /// Represents the types of interval a Starship can carry of consumables. It's can be from days, weeks, month until years.
    /// </summary>
    public struct ConsumableTime
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
        private ConsumableTime(string timeDescriptor, int daysMultiplier)
        {
            TimeDescriptor = timeDescriptor;
            DaysMultiplier = daysMultiplier;
        }

        public static readonly ConsumableTime DAY = new ConsumableTime("day", 1);
        public static readonly ConsumableTime WEEK = new ConsumableTime("week", 7);
        public static readonly ConsumableTime MONTH = new ConsumableTime("month", 30);
        public static readonly ConsumableTime YEAR = new ConsumableTime("year", 360);

        public static List<ConsumableTime> GetAll()
        {
            return new List<ConsumableTime>()
            {
                DAY, WEEK, MONTH, YEAR
            };
        }
    }
}
