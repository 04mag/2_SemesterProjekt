using System.Net.Http.Json;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public class UdlejningsScooterClientService : IUdlejningsScooterClientService
    {
        private readonly HttpClient _httpClient;

        public UdlejningsScooterClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<UdlejningsScooter?> GetUdlejningsScooter(int id)
        {
            UdlejningsScooter? result = await _httpClient.GetFromJsonAsync<UdlejningsScooter>($"api/udlejningsscooter/{id}");
            return result;
        }
        public async Task<List<UdlejningsScooter>?> GetUdlejningsScootere()
        {
            return await _httpClient.GetFromJsonAsync<List<UdlejningsScooter>>("api/udlejningsscooter");
        }
        public Task<int> AddUdlejningsScooter(UdlejningsScooter udlejningsScooter) // Tilføjer et udlejningsScooter og returnerer et int
        {
            return _httpClient.PostAsJsonAsync("api/udlejningsscooter", udlejningsScooter).Result.Content.ReadFromJsonAsync<int>();
        }
        public Task<int> DeleteUdlejningsScooter(int id) // Sletter et udlejningsScooter og returnerer et int. Denne int er id'et på det slettede udlejningsScooter
        {
            return _httpClient.DeleteAsync($"api/udlejningsscooter/{id}").Result.Content.ReadFromJsonAsync<int>();
        }

        public Task<int> updateUdlejningsScooter(UdlejningsScooter udlejningsScooter) // Opdaterer et udlejningsScooter og returnerer et int
        {
            return _httpClient.PutAsJsonAsync("api/udlejningscooter", udlejningsScooter).Result.Content.ReadFromJsonAsync<int>();
        }
    }
}
