using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public interface IUdlejningsScooterRepository
    {
        Task<UdlejningsScooter?> ReadUdlejningsScooterAsync(int id);
        Task<List<UdlejningsScooter>> ReadUdlejningsScootereAsync();
        Task<int> CreateUdlejningsScooterAsync(UdlejningsScooter udlejningsScooter);
        Task<int> UpdateUdlejningsScooterAsync(UdlejningsScooter udlejningsScooter);
        Task<int> DeleteUdlejningsScooterAsync(int id);
    }
}
