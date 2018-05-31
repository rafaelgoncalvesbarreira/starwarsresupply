using StarWarsTravelStop.console.Api;
using System;
using System.Collections.Generic;
using System.Text;
using StarWarsTravelStop.console.Model;

namespace XUnitTestProject.mock
{
    public class RequestClientMock : IRequestClient
    {
        public List<Starship> StarShips { get; set; }

        public RequestClientMock()
        {
            StarShips = new List<Starship>
            {
                new Starship
                {
                    name="Y-wing",
                    consumables="1 week",
                    MGLT="80"
                },
                new Starship
                {
                    name="Millennium Falcon",
                    consumables="2 months",
                    MGLT="75"
                },
                new Starship
                {
                    name="Rebel Transport",
                    consumables="6 months",
                    MGLT="20"
                },
            };
        }
        public List<Starship> GetAllStarships()
        {
            return StarShips;
        }
    }
}
