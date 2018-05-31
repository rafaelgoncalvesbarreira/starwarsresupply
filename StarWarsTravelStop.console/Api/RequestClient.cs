using Newtonsoft.Json;
using StarWarsTravelStop.console.Model;
using StarWarsTravelStop.console.Model.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace StarWarsTravelStop.console.Api
{
    /// <summary>
    /// Class responsible for deal with all the aspect of the REST api from swapi.com
    /// </summary>
    public class RequestClient
    {
        private const string API_URL = "https://swapi.co/api/starships/";

        /// <summary>
        /// Do a Request to get all Starships avaliable
        /// </summary>
        /// <returns>all Starships registred</returns>
        public List<Starship> GetAllStarships()
        {
            List<Starship> allShips = new List<Starship>();
            ApiResponse response = ConsumeApi();
            allShips.AddRange(response.results);
            while (!string.IsNullOrEmpty(response.next))
            {
                response = ConsumeApi(response.next);
                allShips.AddRange(response.results);
            }

            return allShips;
        }

        private ApiResponse ConsumeApi(string apiUrl = API_URL)
        {
            var jsonSettings = new JsonSerializerSettings
            {

                NullValueHandling = NullValueHandling.Ignore
            };

            var client = new HttpClient();
            var responseStream = client.GetStreamAsync(apiUrl).Result;
            var streamReader = new StreamReader(responseStream);
            string json = streamReader.ReadToEnd();
            var result = JsonConvert.DeserializeObject<ApiResponse>(json);
            return result;
        }
    }
}
