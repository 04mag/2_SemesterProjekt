using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public interface IScooterService
    {
        Task<T?> GetScooterAsync<T>(int id) where T : Scooter;
        Task<List<T>> GetAllScootereAsync<T>() where T : Scooter;
        Task<int> AddScooterAsync<T>(T Scooter) where T : Scooter;
        Task<int> UpdateScooterAsync<T>(T Scooter) where T : Scooter;
        Task<int> DeleteScooterAsync(int id);
    }
}
