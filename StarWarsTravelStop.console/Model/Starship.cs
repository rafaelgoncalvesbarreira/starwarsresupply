using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsTravelStop.console.Model
{
    /// <summary>
    /// Represent a Starship from Star Wars. Provides info required to calculate how many stops it will need
    /// </summary>
    public class Starship
    {
        public const string UNKNOWN_STAT = "unknown";

        public string name { get; set; }
        public string MGLT{ get; set; }
        public string consumables { get; set; }
        public int? MGLTNumber {
            get {
                int result;
                if(int.TryParse(MGLT,out result))
                {
                    return result;
                }
                return null;
            }
        }
        /// <summary>
        /// this property inform when a starship doesn't have all information about its stats.  
        /// </summary>
        public bool isUnknow {
            get {
                return MGLT.Equals(UNKNOWN_STAT, StringComparison.InvariantCultureIgnoreCase);
            }
        }
    }
}
