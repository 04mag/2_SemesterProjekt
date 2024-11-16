using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public interface IUdlejningsScooterClientService
    {
        public Task<UdlejningsScooter?> GetUdlejningsScooter(int id);
        public Task<List<UdlejningsScooter>?> GetUdlejningsScootere();
        public Task<int> AddUdlejningsScooter(UdlejningsScooter udlejningsScooter);
        public Task<int> DeleteUdlejningsScooter(int id); 
        public Task<int> updateUdlejningsScooter(UdlejningsScooter udlejningsScooter); 
    }
}
 