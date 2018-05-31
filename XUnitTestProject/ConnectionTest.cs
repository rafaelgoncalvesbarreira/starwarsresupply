using StarWarsTravelStop.console;
using StarWarsTravelStop.console.Api;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class ConnectionTest
    {
        [Fact]
        public void Test1()
        {
            var calculator = new TravelResupplyCalculator(1000000, new RequestClient());
            var result = calculator.CalculateAllStops();
            
        }
    }
}
