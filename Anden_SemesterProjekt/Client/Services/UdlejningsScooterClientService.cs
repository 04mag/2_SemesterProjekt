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
            try
            {
                return await _httpClient.GetFromJsonAsync<UdlejningsScooter>($"api/udlejningsscooter/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<UdlejningsScooter>?> GetUdlejningsScootere()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<UdlejningsScooter>>("api/udlejningsscooter");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> AddUdlejningsScooter(UdlejningsScooter udlejningsScooter)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/udlejningsscooter", udlejningsScooter);
                return response; // Returner response til klienten
            }
            catch 
            { 
                throw new Exception ($"Fejl i AddUdlejningsScooter");
            }
        }

        public async Task<HttpResponseMessage> DeleteUdlejningsScooter(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/udlejningsscooter/{id}");
                return response;
            }
            catch
            {
                throw new Exception("Fejl ved sletning af scooter.");
            }
        }

        public async Task<HttpResponseMessage> UpdateUdlejningsScooter(UdlejningsScooter udlejningsScooter)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("api/udlejningsscooter", udlejningsScooter);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Fejl ved opdatering af scooter: " + ex.Message);
            }
        }
    }
}
