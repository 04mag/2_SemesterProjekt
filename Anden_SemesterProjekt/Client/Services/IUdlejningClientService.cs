using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public class IUdlejningClientService
    {
        public Task<Udlejning?> GetUdlejningAsync(int id);
        public Task<List<Udlejning>> GetUdlejningerAsync();
        public Task<int> AddUdlejningAsync(Udlejning udlejning);
        public Task<int> UpdateUdlejningAsync(Udlejning udlejning);
        public Task<int> DeleteUdlejningAsync(int id);
    }
}
