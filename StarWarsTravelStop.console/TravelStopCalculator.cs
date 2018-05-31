using Newtonsoft.Json;
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
        private List<Starship> _starShips;
        private double _megaLightDistance;

        public TravelStopCalculator(double megaLightDistance)
        {
            _starShips = new List<Starship>();
            _megaLightDistance = megaLightDistance;
        }


        public StopNeeded CalculateStops()
        {
            LoadStarships();

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
    }
}
