using System;
using System.Collections.Generic;
using System.IO;
using SolarSystemApp.Models;

namespace SolarSystemApp.Services
{
    public class OutputService
    {
        public void PrintPlanetsWithMoons(List<Planet> planets)
        {
            string filePath = "PlanetsWithMoons.txt";
            using StreamWriter writer = new StreamWriter(filePath);
            Console.WriteLine("Planets with at least one moon:");

            foreach (var planet in planets)
            {
                string line = $"{planet.Name} - Avg Temp: {planet.AverageTemperature}°C";
                Console.WriteLine(line);
                writer.WriteLine(line);
            }

            Console.WriteLine($"\nData written to {filePath}");
        }
    }
}