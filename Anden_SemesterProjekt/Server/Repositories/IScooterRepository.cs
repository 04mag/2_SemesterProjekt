using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public interface IScooterRepository
    {
        Task<T?> ReadScooterAsync<T>(int id) where T : Scooter;
        Task<List<T>> ReadScootereAsync<T>() where T : Scooter;

        Task<int> CreateScooterAsync<T>(T Scooter) where T : Scooter;
        Task<int> UpdateScooterAsync<T>(T Scooter) where T : Scooter;
        Task<int> DeleteScooterAsync(int id);
    }
}
