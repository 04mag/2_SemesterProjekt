using Anden_SemesterProjekt.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Client.Services
{
    public class ScooterClientService : IScooterClientService
    {
        private readonly HttpClient _httpClient;

        public ScooterClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Scooter>> GetAllScootersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Scooter>>("api/scooters");
        }

        public async Task<Scooter?> GetScooterByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Scooter>($"api/scooters/{id}");
        }

        public async Task AddScooterAsync(Scooter scooter)
        {
            await _httpClient.PostAsJsonAsync("api/scooters", scooter);
        }

        public async Task UpdateScooterAsync(Scooter scooter)
        {
            await _httpClient.PutAsJsonAsync("api/scooters", scooter);
        }

        public async Task DeleteScooterAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/scooters/{id}");
        }
    }
}

