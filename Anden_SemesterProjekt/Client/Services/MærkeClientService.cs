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

        public async Task<Mærke?> GetMærke(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Mærke>($"api/mærke/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Mærke>?> GetMærker()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Mærke>>("api/mærke");
            }
            catch
            {
                return null;
            }
        }

        public async Task<Mærke?> AddMærke(Mærke mærke)
        {
            var response = await _httpClient.PostAsJsonAsync("api/mærke", mærke);
            return await response.Content.ReadFromJsonAsync<Mærke>();
        }

        public async Task<int> DeleteMærke(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/mærke/{id}");
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<Mærke> updateMærke(Mærke mærke)
        {
            var response = await _httpClient.PutAsJsonAsync("api/mærke", mærke);
            return await response.Content.ReadFromJsonAsync<Mærke>();
        }
    }
}
