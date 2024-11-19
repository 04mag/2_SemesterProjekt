using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public interface IScooterClientService
    {
        public Task<UdlejningsScooter?> GetScooter(int id);
        public Task<List<UdlejningsScooter>?> GetScootere();
        public Task<HttpResponseMessage> AddScooter(Scooter udlejningsScooter);
        public Task<HttpResponseMessage> DeleteScooter(int id); 
        public Task<HttpResponseMessage> UpdateScooter(Scooter udlejningsScooter); 
    }
}
 