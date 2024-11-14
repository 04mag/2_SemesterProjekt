using Anden_SemesterProjekt.Shared.Models;
using System.Net.Http.Json;

namespace Anden_SemesterProjekt.Client.Services
{
    public class AnsatClientService : IAnsatClientService
    {
        private readonly HttpClient _httpClient;
        public AnsatClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Mekaniker?> GetMekaniker(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Mekaniker>($"api/ansat/{id}");
            return result;
        }

        public async Task<List<Mekaniker>?> GetMekanikere()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Mekaniker>>("api/ansat");

            return result;
        }
    }
}
