using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SolarSystemApp.Data
{
    public class ApiService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string apiUrl = "https://api.le-systeme-solaire.net/rest/bodies/";

        public async Task<dynamic> FetchBodiesAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<dynamic>(jsonResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return null;
            }
        }
    }
}