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

        public async Task<int> CreateUdlejningsScooter(UdlejningsScooter scooter)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Scootere/UdlejningsScooter", scooter);
            return await response.Content.ReadFromJsonAsync<int>();
        }
        public async Task<int> CreateKundeScooter(KundeScooter scooter)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Scootere/KundeScooter", scooter);
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<int> UpdateScooter(Scooter scooter)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Scooter/", scooter);
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<int> DeleteScooter(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Scooter/{id}");
            return await response.Content.ReadFromJsonAsync<int>();
        }
    }
}