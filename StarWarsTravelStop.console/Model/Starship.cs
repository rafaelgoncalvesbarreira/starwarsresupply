using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsTravelStop.console.Model
{
    public class Starship
    {
        public string name { get; set; }
        public string MGLT{ get; set; }
        public double? MGLTNumber {
            get {
                double result;
                if(Double.TryParse(MGLT,out result))
                {
                    return result;
                }
                return null;
            }
        } 
        public string consumables { get; set; }
    }
}
