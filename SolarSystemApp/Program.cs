using System;
using System.Threading.Tasks;
using SolarSystemApp.Data;
using SolarSystemApp.Services;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Fetching data...");
        ApiService apiService = new ApiService();
        PlanetService planetService = new PlanetService(apiService);
        OutputService outputService = new OutputService();

        var planetsWithMoons = await planetService.GetPlanetsWithMoonsAsync();
        outputService.PrintPlanetsWithMoons(planetsWithMoons);
    }
}