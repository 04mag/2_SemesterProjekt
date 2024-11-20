using Anden_SemesterProjekt.Shared.Models;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace Anden_SemesterProjekt.Client.Services
{
    public class VareClientService
    {
        private readonly HttpClient _httpClient;
        public VareClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //Sender en POST-anmodning til api/varer og opretter en ny vare i databasen
        public async Task<Vare?> PostVare(Vare vare)
        {
            var response = await _httpClient.PostAsJsonAsync("api/varer", vare);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Vare>();
            }
            else
            {
                return null;
            }
        }

        //Sender en GET-anmodning til api/varer for at hente en liste over alle aktive varer og ydelser.
        public async Task<List<Vare>?> GetAktiveVarerOgYdelser()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Vare>>("api/varer/VarerOgYdelser"); //Dobbelttjek 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //Sender en GET-anmodning til api/varer for at hente en liste over alle aktive varer.
        public async Task<List<Vare>?> GetAktiveVarer()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Vare>>("api/varer/Varer"); //Dobbelttjek
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }


        //Sender en GET-anmodning til api/varer for at hente en liste over alle aktive ydelser.
        public async Task<List<Ydelse>?> GetAktiveYdelser()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Ydelse>>("api/varer/Ydelser"); //Dobbelttjek - evt try-catch
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //Henter en enkelt vare baseret på Id.
        public async Task<Vare?> GetVare(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Vare>($"api/varer/{id}");
            }
            catch
            {
                return null;
            }
        }

        //Sender en PUT-anmodning for at opdatere en eksisterene vare.
        public async Task<bool> PutVare(Vare vare)
        {
            var response = await _httpClient.PutAsJsonAsync("api/varer", vare);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Sender en DELETE-anmodning for at slette en eksisterende vare.
        public async Task<bool> DeleteVare(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/varer/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
