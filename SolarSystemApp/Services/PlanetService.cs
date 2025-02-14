using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using SolarSystemApp.Models;
using SolarSystemApp.Data;

namespace SolarSystemApp.Services
{
    public class PlanetService
    {
        private readonly ApiService _apiService;

        public PlanetService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<Planet>> GetPlanetsWithMoonsAsync()
        {
            var data = await _apiService.FetchBodiesAsync();
            List<Planet> planets = new List<Planet>();

            if (data != null && data.bodies != null)
            {
                foreach (var body in data.bodies)
                {
                    if ((bool)body.isPlanet && body.moons != null)
                    {
                        var planet = new Planet
                        {
                            Name = (string)body.englishName,
                            AverageTemperature = (double)body.avgTemp,
                            Moons = ((JArray)body.moons).Select(m => new Moon { Name = (string)m["moon"] }).ToList()
                        };
                        planets.Add(planet);
                    }
                }
            }
            return planets;
        }
    }
}