using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public interface IUdlejningRepository
    {
        Task<Udlejning?> GetUdlejningAsync(int id);
        Task<List<Udlejning>> GetUdlejningerAsync();
        Task<int> AddUdlejningAsync(Udlejning udlejning);
        Task<int> UpdateUdlejningAsync(Udlejning udlejning);
        Task<int> DeleteUdlejningAsync(int id);
    }
}
