using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public interface IUdlejningsScooterService
    {
        Task<UdlejningsScooter?> GetUdlejningsScooterAsync(int id);
        Task<List<UdlejningsScooter>> GetAllUdlejningsScootereAsync();
        Task<int> AddUdlejningsScooterAsync(UdlejningsScooter udlejningsScooter);
        Task<int> UpdateUdlejningsScooterAsync(UdlejningsScooter udlejningsScooter);
        Task<int> RemoveUdlejningsScooterAsync(int id);
    }
}
