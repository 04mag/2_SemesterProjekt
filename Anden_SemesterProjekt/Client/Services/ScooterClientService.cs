using System.Net.Http.Json;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;

using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public class ScooterClientService : IScooterClientService
    {
        private readonly HttpClient _httpClient;
        public ScooterClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<UdlejningsScooter>> GetAllUdlejningsScootereAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<UdlejningsScooter>>("api/Scootere/UdlejningsScootere");
        }
        public async Task<List<KundeScooter>> GetAllKundeScootereAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<KundeScooter>>("api/Scootere/KundeScootere");
        }
        public async Task<Scooter> GetScooter(int id)
        {
            return await _httpClient.GetFromJsonAsync<Scooter>($"api/Scootere/{id}");
        }
        public async Task<int> CreateScooter(Scooter scooter)
        {
            if (scooter is UdlejningsScooter)
            {
                var response = await _httpClient.PostAsJsonAsync("api/Scootere/UdlejningsScooter", scooter);
                return await response.Content.ReadFromJsonAsync<int>();
            }
            else if (scooter is KundeScooter)
            {
                var response = await _httpClient.PostAsJsonAsync("api/Scootere/KundeScooter", scooter);
                return await response.Content.ReadFromJsonAsync<int>();
            }
            else
            {
                return 0;
            }
        }
        
        public async Task<int> UpdateScooter(Scooter scooter)
        {
            if (scooter is UdlejningsScooter)
            {
                var response = await _httpClient.PutAsJsonAsync("api/scootere/UdlejningsScooter", scooter);
                return await response.Content.ReadFromJsonAsync<int>();
            }
            else if (scooter is KundeScooter)
            {
                var response = await _httpClient.PutAsJsonAsync("api/scootere/KundeScooter", scooter);
                return await response.Content.ReadFromJsonAsync<int>();
            }
            else
            {
                return 0;
            }
        }
        public async Task UpdateScooterTilgængelighed(int scooterId, bool isAvailable)
        {
            var url = $"api/scootere/{scooterId}/ledighed";
            var response = await _httpClient.PutAsJsonAsync(url, isAvailable);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to update scooter availability: {response.ReasonPhrase}");
            }
        }


        public async Task<int> DeleteScooter(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/scootere/{id}");
            return await response.Content.ReadFromJsonAsync<int>();
        }
    }
}