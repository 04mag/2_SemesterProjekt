using Anden_SemesterProjekt.Server.Repositories;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public class ScooterService : IScooterService
    {
        private readonly IScooterRepository _scooterRepository;

        public ScooterService(IScooterRepository scooterRepository)
        {
            _scooterRepository = scooterRepository;
        }

        public async Task<Scooter?> ReadScooterAsync(int id) 
        {
            return await _scooterRepository.ReadScooterAsync(id);
        }

        public async Task<List<KundeScooter>> ReadKundeScootereAsync(int kundeId) 
        {
            return await _scooterRepository.ReadKundeScootereAsync(kundeId);
        }
        public async Task<List<UdlejningsScooter>> ReadUdlejningsScootere()
        {
            return await _scooterRepository.ReadUdlejningsScootereAsync();
        }

        public async Task<int> AddScooterAsync(Scooter scooter) 
        {
            return await _scooterRepository.CreateScooterAsync(scooter);
        }

        public async Task<int> UpdateScooterAsync(Scooter scooter) 
        {
            return await _scooterRepository.UpdateScooterAsync(scooter);
        }
        public async Task UpdateScooterTilgængelighedAsync(int scooterId, bool isAvailable)
        {
            if (scooterId <= 0)
            {
                throw new ArgumentException("Invalid scooter ID.");
            }

            // Eventuel forretningslogik her
            await _scooterRepository.UpdateScooterTilgængelighedAsync(scooterId, isAvailable);
        }
        public async Task<int> DeleteScooterAsync(int id)
        {
            return await _scooterRepository.DeleteScooterAsync(id);
        }
    }
}