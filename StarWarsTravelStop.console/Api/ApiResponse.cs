using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace StarWarsTravelStop.console.Model.Api
{
    /// <summary>
    /// Represent a response for the API, with all member needed
    /// </summary>
    public class ApiResponse
    {
        public int count { get; set; }
        public String next { get; set; }
        public String previous { get; set; }
        public List<Starship> results { get; set; }
    }
}
