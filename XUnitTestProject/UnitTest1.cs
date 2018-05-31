using StarWarsTravelStop.console;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var calculator = new TravelStopCalculator(10);
            calculator.CalculateStops();
        }
    }
}
