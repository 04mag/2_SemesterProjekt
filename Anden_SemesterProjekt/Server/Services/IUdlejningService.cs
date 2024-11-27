using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public interface IUdlejningService
    {
        Task<Udlejning?> GetUdlejningAsync(int id);
        Task<List<Udlejning>> GetUdlejningerAsync();
        Task<int> AddUdlejningAsync(Udlejning udlejning);
        Task<int> UpdateUdlejningAsync(Udlejning udlejning);
        Task<int> DeleteUdlejningAsync(int id);
    }
}
