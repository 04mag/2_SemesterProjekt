using System.Net.Http.Json;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;

using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public class ScooterClientService <T> : IScooterClientService<T> where T : Scooter
    {
        private readonly HttpClient _httpClient;
      

        public ScooterClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T?> GetScooter(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<T>($"api/scootere/{id}");
            }
            catch
            {
                throw new Exception( "Error in client service");
            }
        }

        public async Task<List<T>> GetScootere() 
        {
            var scooterJson = await _httpClient.GetStringAsync("api/scooter");

            // First, deserialize the list of base class Scooter
            var scooters = JsonSerializer.Deserialize<List<T>>(scooterJson);

            if (scooters == null)
            {
                throw new Exception("Failed to deserialize scooters.");
            }

            // Iterate through each scooter, check its type, and deserialize accordingly
            List<T> deserializedScooters = new List<T>();

            foreach (var scooter in scooters)
            {
                if (scooter.ScooterType == "KundeScooter")
                {
                    // Deserialize to KundeScooter
                    var kundeScooter = JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(scooter));
                    if (kundeScooter != null)
                    {
                        deserializedScooters.Add(kundeScooter);
                    }
                }
                else if (scooter.ScooterType == "UdlejningsScooter")
                {
                    // Deserialize to UdlejningsScooter
                    var udlejningsScooter = JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(scooter));
                    if (udlejningsScooter != null)
                    {
                        deserializedScooters.Add(udlejningsScooter);
                    }
                }
                else
                {
                    throw new Exception($"Unknown scooter type: {scooter.ScooterType}");
                }
            }

            return deserializedScooters;
        }

        public async Task<HttpResponseMessage> AddScooterAsync(T scooter) 
        {
            try
            {
                // Sørger for korrekt serialisering af polymorf JSON
                var options = new JsonSerializerOptions
                {
                    Converters = { new ScooterJsonConverter() }
                };
                var response = await _httpClient.PostAsJsonAsync("api/scootere", scooter, options);
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
