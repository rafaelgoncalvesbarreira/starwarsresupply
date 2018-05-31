using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsTravelStop.console.Model
{
    /// <summary>
    /// Represent the information about the number of stops to resupply
    /// </summary>
    public class StopNeeded
    {
        public Starship starship { get; set; }
        public int? numberOfStop { get; set; }
    }
}
