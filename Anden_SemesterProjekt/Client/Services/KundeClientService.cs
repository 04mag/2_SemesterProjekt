using Anden_SemesterProjekt.Shared.Models;
using System.Net.Http.Json;
using System.Text;

namespace Anden_SemesterProjekt.Client.Services
{
    public class KundeClientService : IKundeClientService
    {
        private readonly HttpClient _httpClient;
        public KundeClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> DeleteKunde(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/kunder/{id}");

            var responseStatusCode = response.StatusCode;

            return (int)responseStatusCode;
        }

        public async Task<Kunde?> GetKunde(int id)
        {
            return await _httpClient.GetFromJsonAsync<Kunde>($"api/kunder/{id}");
        }

        public async Task<List<Kunde>?> GetKunder()
        {
            return await _httpClient.GetFromJsonAsync<List<Kunde>>("api/kunder");
        }

        public async Task<List<Kunde>?> GetKunder(string tlfnummer, string mærke)
        {
            return await _httpClient.GetFromJsonAsync<List<Kunde>>($"api/kunder/{tlfnummer}/{mærke}");  
        }

        public async Task<int> PostKunde(Kunde kunde)
        {
            return await _httpClient.PostAsJsonAsync("api/kunder", kunde).Result.Content.ReadFromJsonAsync<int>();
        }

        public async Task<int> PutKunde(Kunde kunde)
        {
            var response = await _httpClient.PutAsJsonAsync("api/kunder", kunde);

            var responseStatusCode = response.StatusCode;

            return (int)responseStatusCode;
        }
    }
}
