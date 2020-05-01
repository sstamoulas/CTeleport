using System.Collections.Generic;

namespace CTeleportTest.Models
{
    public class Airport
    {
        public string IATA { get; set; }
        public Dictionary<string, double> Location { get; set; }
    }
}
