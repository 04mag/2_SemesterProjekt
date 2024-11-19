using Anden_SemesterProjekt.Server.Repositories;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public class UdlejningService
    {
        private readonly IUdlejningRepository _udlejningRepository;

        public UdlejningService(IUdlejningRepository udlejningRepository)
        {
            _udlejningRepository = udlejningRepository;
        }

        public Task<Udlejning?> GetUdlejningAsync(int id)
        {
            return _udlejningRepository.GetUdlejningAsync(id);
        }

        public Task<List<Udlejning>> GetUdlejningerAsync()
        {
            return _udlejningRepository.GetUdlejningerAsync();
        }

        public Task<int> AddUdlejningAsync(Udlejning udlejning)
        {
            return _udlejningRepository.AddUdlejningAsync(udlejning);
        }

        public Task<int> UpdateUdlejningAsync(Udlejning udlejning)
        {
            return _udlejningRepository.UpdateUdlejningAsync(udlejning);
        }

        public Task<int> DeleteUdlejningAsync(int id)
        {
            return _udlejningRepository.DeleteUdlejningAsync(id);
        }
    }
}
