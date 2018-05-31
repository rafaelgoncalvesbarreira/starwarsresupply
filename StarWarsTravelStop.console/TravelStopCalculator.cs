﻿using StarWarsTravelStop.console.Api;
using StarWarsTravelStop.console.Enums;
using StarWarsTravelStop.console.Model;
using StarWarsTravelStop.console.Model.Api;
using System.Collections.Generic;

namespace StarWarsTravelStop.console
{
    public class TravelStopCalculator
    {
        private List<Starship> _starShips;
        private double _megaLightDistance;

        public TravelStopCalculator(double megaLightDistance)
        {
            _starShips = new List<Starship>();
            _megaLightDistance = megaLightDistance;
        }


        public List<StopNeeded> CalculateAllStops()
        {
            var result = new List<StopNeeded>();
            LoadStarships();

            foreach(Starship starship in _starShips)
            {
                var starshipInfo = new StopNeeded
                {
                    starship = starship
                };
                starshipInfo.numberOfStop = calculateNumberOfStops(starship);

                result.Add(starshipInfo);
            }
            return result;
        }

        private void LoadStarships()
        {
            var requestClient = new RequestClient();
            _starShips = requestClient.GetAllStarships();
        }

        

        private int calculateNumberOfStops(Starship starship)
        {
            //mglt * 24 hours = 1 day = move in the month
            //megaLightDistance / (mov * consumables in  days)
            int stopNeeded = 0;
            if (starship.MGLTNumber.HasValue)
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

            ConsumableTimeEnum intervalSelected=ConsumableTimeEnum.DAY;
            foreach (ConsumableTimeEnum enumItem in ConsumableTimeEnum.GetAll())
            {
                if (splitted[1].Contains(enumItem.TimeDescriptor))
                {
                    intervalSelected = enumItem;
                    break;
                }
            }

            return number * intervalSelected.DaysMultiplier;
        }
    }
}
