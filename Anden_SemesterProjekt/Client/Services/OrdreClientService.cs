using System.Net.Http.Json;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public class OrdreClientService : IOrdreClientService
    {
        private readonly HttpClient _httpClient;

        public OrdreClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Ordre?> GetOrdre(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Ordre>($"api/ordre/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Ordre>?> GetOrdrer()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Ordre>>("api/ordre");
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<Ordre>?> GetOrdrer(int kundeId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Ordre>>($"api/ordre/kunde/{kundeId}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> AddOrdre(Ordre ordre)
        {
            try
            {
                return await _httpClient.PostAsJsonAsync("api/ordre", ordre);
            }
            catch
            {
                throw new Exception("Fejl i AddOrdre");
            }
        }

        public async Task<HttpResponseMessage> DeleteOrdre(int id)
        {
            try
            {
                return await _httpClient.DeleteAsync($"api/ordre/{id}");
            }
            catch
            {
                throw new Exception("Fejl i DeleteOrdre");
            }
        }

        public async Task<HttpResponseMessage> UpdateOrdre(Ordre ordre)
        {
            return await _httpClient.PutAsJsonAsync("api/ordre", ordre);
        }
    }
}
