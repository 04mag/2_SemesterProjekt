using Anden_SemesterProjekt.Server.Repositories;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public class UdlejningsScooterService : IUdlejningsScooterService
    {
        private readonly IUdlejningsScooterRepository _udlejningsScooterRepository;

        public UdlejningsScooterService(IUdlejningsScooterRepository udlejningsScooterRepository)
        {
            _udlejningsScooterRepository = udlejningsScooterRepository;
        }

        public async Task<UdlejningsScooter?> GetUdlejningsScooterAsync(int id)
        {
            return await _udlejningsScooterRepository.ReadUdlejningsScooterAsync(id);
        }

        public async Task<List<UdlejningsScooter>> GetAllUdlejningsScootereAsync()
        {
            return await _udlejningsScooterRepository.ReadUdlejningsScootereAsync();
        }

        public async Task<int> AddUdlejningsScooterAsync(UdlejningsScooter udlejningsScooter)
        {
            return await _udlejningsScooterRepository.CreateUdlejningsScooterAsync(udlejningsScooter);
        }

        public async Task<int> UpdateUdlejningsScooterAsync(UdlejningsScooter udlejningsScooter)
        {
            return await _udlejningsScooterRepository.UpdateUdlejningsScooterAsync(udlejningsScooter);
        }

        public async Task<int> DeleteUdlejningsScooterAsync(int id)
        {
            return await _udlejningsScooterRepository.DeleteUdlejningsScooterAsync(id);
        }
    }
}