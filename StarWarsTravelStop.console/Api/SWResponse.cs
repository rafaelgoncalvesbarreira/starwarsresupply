using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace StarWarsTravelStop.console.Model.Api
{
    public class SWResponse
    {
        public int count { get; set; }
        public String next { get; set; }
        public String previous { get; set; }
        public List<Starship> results { get; set; }
    }
}
