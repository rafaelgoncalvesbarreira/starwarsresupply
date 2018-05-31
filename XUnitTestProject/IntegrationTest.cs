using StarWarsTravelStop.console;
using StarWarsTravelStop.console.Api;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject
{
    public class IntegrationTest
    {
        [Fact]
        public void testUsingRealData()
        {
            var calculator = new TravelResupplyCalculator(1000000, new RequestClient());
            var result = calculator.CalculateAllStops();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
