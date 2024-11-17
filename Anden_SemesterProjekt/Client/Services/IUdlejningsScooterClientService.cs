using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public interface IUdlejningsScooterClientService
    {
        public Task<UdlejningsScooter?> GetUdlejningsScooter(int id);
        public Task<List<UdlejningsScooter>?> GetUdlejningsScootere();
        public Task<UdlejningsScooter> AddUdlejningsScooter(UdlejningsScooter udlejningsScooter);
        public Task<int> DeleteUdlejningsScooter(int id); 
        public Task<UdlejningsScooter> UpdateUdlejningsScooter(UdlejningsScooter udlejningsScooter); 
    }
}
 