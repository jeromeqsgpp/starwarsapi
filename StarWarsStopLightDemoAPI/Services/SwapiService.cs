

using StarWarsStopLightDemoAPI.Models;

namespace StarWarsStopLightDemoAPI.Services
{
    public class SwapiService
    {
        private readonly HttpClient _httpClient;
        public SwapiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri("https://swapi.dev/api/");
        }
        public async Task<SwapiPeople> GetSwapiPersonByIdAsync(int personId)
        {
            var response = await _httpClient.GetFromJsonAsync<SwapiPeople>($"people/{personId}/");
            return response;
        }
    }
}
