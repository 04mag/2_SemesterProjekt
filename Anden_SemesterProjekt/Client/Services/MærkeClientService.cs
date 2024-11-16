using System.Net.Http.Json;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public class MærkeClientService : IMærkeClientService
    {
        private readonly HttpClient _httpClient;

        public MærkeClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Mærke?> GetUdlejningsScooter(int id)
        {
            return await _httpClient.GetFromJsonAsync<Mærke>($"api/Mærke/{id}");
        }

        public async Task<List<Mærke>?> GetMærke()
        {
            return await _httpClient.GetFromJsonAsync<List<Mærke>>("api/Mærke");
        }

        public async Task<int> AddMærke(Mærke mærke)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Mærke", mærke);
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<int> DeleteMærke(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Mærke/{id}");
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<int> updateMærke(Mærke mærke)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Mærke", mærke);
            return await response.Content.ReadFromJsonAsync<int>();
        }
    }
}
