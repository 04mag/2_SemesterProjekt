using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public interface IUdlejningsScooterClientService
    {
        public Task<UdlejningsScooter?> GetUdlejningsScooter(int id);
        public Task<List<UdlejningsScooter>?> GetUdlejningsScootere();
        public Task<HttpResponseMessage> AddUdlejningsScooter(UdlejningsScooter udlejningsScooter);
        public Task<HttpResponseMessage> DeleteUdlejningsScooter(int id); 
        public Task<HttpResponseMessage> UpdateUdlejningsScooter(UdlejningsScooter udlejningsScooter); 
    }
}
 