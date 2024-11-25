using System.Net.Http.Json;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public class UdlejningClientService : IUdlejningClientService
    {
        private readonly HttpClient _httpClient;

        public UdlejningClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Udlejning?> GetUdlejningAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Udlejning>($"api/udlejning/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Udlejning>> GetUdlejningerAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Udlejning>>("api/udlejning");
            }
            catch
            {
                return null;
            }
        }

        public async Task<int> AddUdlejningAsync(Udlejning udlejning)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/udlejning", udlejning);
                return await response.Content.ReadFromJsonAsync<int>();
            }
            catch
            {
                return 0;
            }
        }

        public async Task<int> UpdateUdlejningAsync(Udlejning udlejning)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("api/udlejning", udlejning);
                return await response.Content.ReadFromJsonAsync<int>();
            }
            catch
            {
                return 0;
            }
        }

        public async Task<int> DeleteUdlejningAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/udlejning/{id}");
                return await response.Content.ReadFromJsonAsync<int>();
            }
            catch
            {
                return 0;
            }
        }
    }
}
