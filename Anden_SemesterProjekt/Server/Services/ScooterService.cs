using Anden_SemesterProjekt.Server.Repositories;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public class ScooterService : IScooterService
    {
        private readonly IScooterRepository _udlejningsScooterRepository;

        public ScooterService(IScooterRepository udlejningsScooterRepository)
        {
            _udlejningsScooterRepository = udlejningsScooterRepository;
        }

        public async Task<Scooter?> GetScooterAsync(int id)
        {
            return await _udlejningsScooterRepository.ReadUdlejningsScooterAsync(id);
        }

        public async Task<List<UdlejningsScooter>> GetAllUdlejningsScootereAsync()
        {
            return await _udlejningsScooterRepository.ReadUdlejningsScootereAsync();
        }

        public async Task<int> AddScooterAsync(Scooter Scooter)
        {
            return await _udlejningsScooterRepository.CreateScooterAsync(Scooter);
        }

        public async Task<int> UpdateScooterAsync(Scooter Scooter)
        {
            return await _udlejningsScooterRepository.UpdateScooterAsync(Scooter);
        }

        public async Task<int> DeleteScooterAsync(int id)
        {
            return await _udlejningsScooterRepository.DeleteScooterAsync(id);
        }
    }
}