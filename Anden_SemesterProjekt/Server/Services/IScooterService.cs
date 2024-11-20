using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public interface IScooterService <T> where T : Scooter
    {
        Task<T?> GetScooterAsync(int id);
        Task<List<T>> GetAllScootereAsync();
        Task<int> AddScooterAsync(T Scooter);
        Task<int> UpdateScooterAsync(T Scooter);
        Task<int> DeleteScooterAsync(int id);
    }
}
