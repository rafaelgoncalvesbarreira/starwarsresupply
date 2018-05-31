using Newtonsoft.Json;
using StarWarsTravelStop.console.Enums;
using StarWarsTravelStop.console.Model;
using StarWarsTravelStop.console.Model.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsTravelStop.console
{
    public class TravelStopCalculator
    {
        private const string API_URL = "https://swapi.co/api/starships/";
        private const string UNKNOWN = "unknown";

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
                starshipInfo.numberOfStop = calculateStop(starship);

                result.Add(starshipInfo);
            }
            return null;
        }

        private void LoadStarships()
        {
            SWResponse response = ConsumeApi();
            _starShips.AddRange(response.results);
            while (!string.IsNullOrEmpty(response.next))
            {
                response = ConsumeApi(response.next);
                _starShips.AddRange(response.results);
            }

        }

        private SWResponse ConsumeApi(string apiUrl = API_URL)
        {
            
            var jsonSettings = new JsonSerializerSettings
            {
                
                NullValueHandling = NullValueHandling.Ignore
            };

            HttpClient client = new HttpClient();
            var responseStream = client.GetStreamAsync(apiUrl).Result;
            var streamReader = new StreamReader(responseStream);
            string json = streamReader.ReadToEnd();
            var result = JsonConvert.DeserializeObject<SWResponse>(json);
            return result;
        }

        private int calculateStop(Starship starship)
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
