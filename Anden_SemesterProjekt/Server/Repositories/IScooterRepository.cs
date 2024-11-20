using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public interface IScooterRepository <T> where T : Scooter
    {
        Task<T?> ReadScooterAsync(int id);
        Task<List<T>> ReadScootereAsync();

        Task<int> CreateScooterAsync(T scooter);
        Task<int> UpdateScooterAsync(T Scooter);
        Task<int> DeleteScooterAsync(int id);
    }
}
