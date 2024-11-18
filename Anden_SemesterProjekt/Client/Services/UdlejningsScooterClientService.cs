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
            var result = await _httpClient.GetFromJsonAsync<UdlejningsScooter>($"api/udlejningsscooter/{id}");
            return result;
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

        public async Task<HttpResponseMessage> AddUdlejningsScooter(UdlejningsScooter scooter)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/udlejningsscooter", scooter);
                return response; // Returner response til klienten
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl i AddUdlejningsScooter: {ex.Message}");
                throw; // Kast undtagelsen videre, så den fanges i din frontend
            }
        }

        public async Task<HttpResponseMessage> DeleteUdlejningsScooter(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/udlejningsscooter/{id}");

            if (response.IsSuccessStatusCode)
            {

                return response;
            }

       
            throw new Exception("Fejl ved sletning af scooter.");
        }

        public async Task<HttpResponseMessage> UpdateUdlejningsScooter(UdlejningsScooter udlejningsScooter)
        {
            var response = await _httpClient.PutAsJsonAsync("api/udlejningsscooter", udlejningsScooter);

            if (response.IsSuccessStatusCode)
            {

                return response;
            }

        
            throw new Exception("Fejl ved opdatering af scooter.");
        }
    }
}
