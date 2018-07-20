using StarWarsTravelStop.console.Api;
using StarWarsTravelStop.console.Enums;
using StarWarsTravelStop.console.Model;
using StarWarsTravelStop.console.Model.Api;
using System.Collections.Generic;

namespace StarWarsTravelStop.console
{
    /// <summary>
    /// Calcules the number of stops for resupply from all starships
    /// </summary>
    public class TravelResupplyCalculator
    {
        private List<Starship> _starShips;
        private int _megaLightDistance;
        IRequestClient _requestClient;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="megaLightDistance">value use to calculate the number of stops</param>
        public TravelResupplyCalculator(int megaLightDistance, IRequestClient requestClient)
        {
            _starShips = new List<Starship>();
            _megaLightDistance = megaLightDistance;
            _requestClient = requestClient;
        }

        /// <summary>
        /// Make the calculation of number of stops needed
        /// </summary>
        /// <returns>a collection of all starships and the total amount of stops required to make the distance</returns>
        public List<StopNeeded> CalculateAllStops()
        {
            var result = new List<StopNeeded>();
            LoadStarships();

            foreach (Starship starship in _starShips)
            {
                var starshipInfo = new StopNeeded
                {
                    starship = starship
                };
                if (!starship.isUnknow)
                {
                    starshipInfo.numberOfStop = calculateNumberOfStops(starship);
                }

                result.Add(starshipInfo);
            }
            return result;
        }

        private void LoadStarships()
        {
            _starShips = _requestClient.GetAllStarships();
        }


        private int calculateNumberOfStops(Starship starship)
        {
            int stopNeeded = 0;
            if (!starship.isUnknow)
            {
                int movimentInOneDay = starship.MGLTNumber.Value * 24;
                int consumablesInDays = ConsumablesToDays(starship.consumables);
                int distanceUntilNextStop = movimentInOneDay * consumablesInDays;
                stopNeeded = (int)_megaLightDistance / distanceUntilNextStop;
            }
            return stopNeeded;
        }

        private int ConsumablesToDays(string consumables)
        {
            var splitted = consumables.Split(" ");
            var number = int.Parse(splitted[0]);
            var descriptor = splitted[1];

            ConsumableTime intervalSelected = ConsumableTime.DAY;
            foreach (ConsumableTime consumableTime in ConsumableTime.GetAll())
            {
                if (descriptor.Contains(consumableTime.TimeDescriptor))
                {
                    intervalSelected = consumableTime;
                    break;
                }
            }

            return number * intervalSelected.DaysMultiplier;
        }
    }
}
