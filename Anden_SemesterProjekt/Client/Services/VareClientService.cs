using Anden_SemesterProjekt.Shared.Models;
using Azure;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace Anden_SemesterProjekt.Client.Services
{
    public class VareClientService : IVareClientService
    {
        private readonly HttpClient _httpClient;
        public VareClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //Sender en POST-anmodning til api/Varer og api/Varer/ydelse og opretter en ny vare i databasen
        public async Task<Vare?> PostVare(Vare vare)
        {
            if (vare is Ydelse)
            {
                Ydelse ydelse = (Ydelse)vare; 
                var response = await _httpClient.PostAsJsonAsync("api/Varer/ydelse",ydelse);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Ydelse>();
                }
                else
                {
                    return null;
                }
            }
            if (vare is Vare)
            {
                var response = await _httpClient.PostAsJsonAsync("api/Varer", vare);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Vare>();
                }
                else
                {
                    return null;
                }
            }

            return null; 
        }


        //Sender en GET-anmodning til api/Varer for at hente en liste over alle aktive Varer og Ydelser.
        public async Task<List<Vare>?> GetAktiveVarerOgYdelser()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Vare>>("api/Varer/VarerOgYdelser"); //Dobbelttjek 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }
        

        //Sender en GET-anmodning til api/Varer for at hente en liste over alle aktive Varer.
        public async Task<List<Vare>?> GetAktiveVarer()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Vare>>("api/Varer/Varer"); //Dobbelttjek
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e. Message);
            }
        }


        //Sender en GET-anmodning til api/Varer for at hente en liste over alle aktive Ydelser.
        //Har tilrettet nedstående fra Vare til Ydelse. 20/11/2024-20.30
        public async Task<List<Ydelse>?> GetAktiveYdelser()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Ydelse>>("api/Varer/ydelse"); //Dobbelttjek - evt try-catch
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }
        

        //Henter en enkelt vare baseret på Id.
        public async Task<Vare?> GetVare(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Vare>($"api/Varer/{id}");
            }
            catch
            {
                return null;
            }
        }

        //Sender en PUT-anmodning for at opdatere en eksisterene vare eller ydelse. 
        public async Task<HttpResponseMessage> PutVare(Vare vare)
        {
            if (vare is Vare)
            {
                return await _httpClient.PutAsJsonAsync("api/Varer", vare);
            }
            else
            {
                return null; 
            }

            if (vare is Ydelse) 
            {
                return await _httpClient.PutAsJsonAsync("api/Varer/ydelse", vare);
            }
            else
            {
                return null; 
            }
            return null; 


            //    if (vare is Ydelse)
            //    {
            //        var response = await _httpClient.PutAsJsonAsync("api/Varer/ydelse", vare);

            //        if (response.IsSuccessStatusCode)
            //        {
            //            return await response.Content.ReadFromJsonAsync<HttpResponseMessage>();
            //        }
            //        else
            //        {
            //            return null;
            //        }
            //    }

            //    if (vare is Vare)
            //    {
            //        var response = await _httpClient.PutAsJsonAsync("api/Varer", vare);

            //        if (response.IsSuccessStatusCode)
            //        {
            //            return await response.Content.ReadFromJsonAsync<HttpResponseMessage>();
            //        }
            //        else
            //        {
            //            return null;
            //        }
            //    }
            //    return null;
        }

        //Sender en DELETE-anmodning for at slette en eksisterende vare.
        public async Task<HttpResponseMessage> DeleteVare(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Varer/{id}");
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
           
            
        }
    }
}


