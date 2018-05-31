using StarWarsTravelStop.console;
using StarWarsTravelStop.console.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUnitTestProject.mock;

namespace XUnitTestProject
{
    public class CalculationTest
    {
        [Fact]
        public void happyCase()
        {
            string ywing = "Y-wing";
            string millenium = "Millennium Falcon";
            string rebel = "Rebel Transport";
            var mock = new RequestClientMock();
            var calculator = new TravelResupplyCalculator(1000000, mock);
            var results = calculator.CalculateAllStops();
            Assert.NotNull(results);
            Assert.NotEmpty(results);
            Assert.True(mock.StarShips.Count == results.Count);
            foreach(StopNeeded info in results)
            {
                if (info.starship.name == ywing)
                {
                    Assert.True(info.numberOfStop == 74);
                }
                else if(info.starship.name == millenium)
                {
                    Assert.True(info.numberOfStop == 9);
                }
                else if (info.starship.name == rebel)
                {
                    Assert.True(info.numberOfStop == 11);
                }
            }
        }

        [Fact]
        public void unknowValue()
        {
            var mock = new RequestClientMock();
            mock.StarShips.Add(new Starship
            {
                name = "DeathStar III",
                MGLT = Starship.UNKNOWN_STAT,
                consumables = Starship.UNKNOWN_STAT
            });

            var calculator = new TravelResupplyCalculator(1000000, mock);
            var results = calculator.CalculateAllStops();

            Assert.NotNull(results);
            Assert.NotEmpty(results);
            Assert.True(mock.StarShips.Count == results.Count);

            bool unknowFound = false;
            foreach (StopNeeded info in results)
            {
                if (info.starship.isUnknow)
                {
                    unknowFound = true;
                    Assert.Null(info.numberOfStop);
                }
            }

            Assert.True(unknowFound);
        }
    }
}
