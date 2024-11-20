using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public interface IScooterClientService <T> where T : Scooter
    {
        public Task<T?> GetScooter(int id);
        public Task<List<T>> GetScootere();
        public Task<HttpResponseMessage> AddScooterAsync(T Scooter);
        public Task<HttpResponseMessage> DeleteScooter(int id); 
        public Task<HttpResponseMessage> UpdateScooter(Scooter Scooter); 
    }
}
 