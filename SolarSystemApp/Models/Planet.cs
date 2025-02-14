using System.Collections.Generic;

namespace SolarSystemApp.Models
{
    public class Planet
    {
        public string Name { get; set; }
        public List<Moon> Moons { get; set; } = new List<Moon>();
        public double AverageTemperature { get; set; }
    }
}