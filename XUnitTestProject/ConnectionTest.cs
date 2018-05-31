using StarWarsTravelStop.console;
using StarWarsTravelStop.console.Api;
using StarWarsTravelStop.console.Model;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class ConnectionTest
    {
        [Fact]
        public void SuccessfulRequest()
        {
            var client = new RequestClient();
            var starships = client.GetAllStarships();
            Assert.NotNull(starships);

            foreach(Starship starship in starships)
            {
                Assert.NotNull(starship);
                Assert.NotNull(starship.name);
                Assert.Equal(!starship.MGLTNumber.HasValue, starship.isUnknow);
            }
        }
    }
}
