using Anden_SemesterProjekt.Shared.Models;
using System.Net;
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

        public async Task<By?> GetBy(string postnummer)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<By>($"api/kunder/by/{postnummer}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> DeleteKunde(int id)
        {
            return await _httpClient.DeleteAsync($"api/kunder/{id}");
        }

        public async Task<Kunde?> GetKunde(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Kunde>($"api/kunder/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Kunde>?> GetKunder()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Kunde>>($"api/kunder");
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Kunde>?> GetKunder(string tlfnummer, string mærke)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Kunde>>($"api/kunder/{tlfnummer}/{mærke}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<Kunde?> PostKunde(Kunde kunde)
        {
            var response = await _httpClient.PostAsJsonAsync("api/kunder", kunde);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Kunde>();
            }
            else
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> PutKunde(Kunde kunde)
        {
            return await _httpClient.PutAsJsonAsync("api/kunder", kunde);
        }

        public async Task<TlfNummer?> PostTlfNummer(TlfNummer tlfNummer)
        {
            var response = await _httpClient.PostAsJsonAsync("api/kunder/tlf", tlfNummer);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TlfNummer>();
            }
            else
            {
                return new TlfNummer();
            }
        }

        public async Task<HttpResponseMessage> DeleteTlfNummer(int id)
        {
            return await _httpClient.DeleteAsync($"api/kunder/tlf/{id}");
        }
    }
}
