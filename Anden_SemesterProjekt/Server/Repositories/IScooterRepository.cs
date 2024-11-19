using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public interface IScooterRepository
    {
        Task<UdlejningsScooter?> ReadUdlejningsScooterAsync(int id);
        Task<List<UdlejningsScooter>> ReadUdlejningsScootereAsync();
        Task<int> CreateScooterAsync(Scooter Scooter);
        Task<int> UpdateScooterAsync(Scooter Scooter);
        Task<int> DeleteScooterAsync(int id);
    }
}
