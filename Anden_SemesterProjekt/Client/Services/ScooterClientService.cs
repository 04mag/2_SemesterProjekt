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

        public async Task<T?> GetScooter<T>(int id) where T : Scooter
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<T>($"api/scootere/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<T>?> GetScootere<T>() where T : Scooter
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<T>>("api/scootere");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> AddScooterAsync<T>(T scooter) where T : Scooter
        {
            try
            {
                // Sørger for korrekt serialisering af polymorf JSON
                var response = await _httpClient.PostAsJsonAsync("api/scootere", scooter);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Fejl ved oprettelse af scooter: {response.ReasonPhrase}");
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Fejl ved oprettelse af scooter: {ex.Message}");
            }
        }


        public async Task<HttpResponseMessage> DeleteScooter(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/scootere/{id}");
                return response;
            }
            catch
            {
                throw new Exception("Fejl ved sletning af scooter.");
            }
        }

        public async Task<HttpResponseMessage> UpdateScooter(Scooter scooter)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("api/scootere", scooter);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Fejl ved opdatering af scooter: " + ex.Message);
            }
        }
    }
}
