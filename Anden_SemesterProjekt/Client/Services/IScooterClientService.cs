using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public interface IScooterClientService
    {
        public Task<T?> GetScooter<T>(int id) where T : Scooter;
        public Task<List<T>?> GetScootere<T>() where T : Scooter;
        public Task<HttpResponseMessage> AddScooterAsync<T>(T Scooter) where T : Scooter;
        public Task<HttpResponseMessage> DeleteScooter(int id); 
        public Task<HttpResponseMessage> UpdateScooter(Scooter Scooter); 
    }
}
 