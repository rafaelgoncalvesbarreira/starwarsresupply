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
        private const string API_URL= "https://swapi.co/api/starships/";
        private List<Starship> _starShips;
        private double _megaLightDistance;

        public TravelStopCalculator(double megaLightDistance)
        {
            this._megaLightDistance = megaLightDistance;
        }

 
        public StopNeeded CalculateStops()
        {
            request().Wait();
            return null;
        }

        private void LoadStarships()
        {

        }

        private static async Task request()
        {
            var serializer = new DataContractJsonSerializer(typeof(SWResponse));
            HttpClient client = new HttpClient();
            var responseStream = await client.GetStreamAsync(API_URL);
            var streamReader = new StreamReader(responseStream);
            string json = streamReader.ReadToEnd();
            var result = JsonConvert.DeserializeObject<SWResponse>(json);            
        }
    }
}
