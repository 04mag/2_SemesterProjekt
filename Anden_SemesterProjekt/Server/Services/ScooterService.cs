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

        public async Task<Scooter?> GetScooterByIdAsync(int id)
        {
            return await _scooterRepository.GetScooterByIdAsync(id);
        }

        public async Task<List<Scooter>> GetAllScootersAsync()
        {
            return await _scooterRepository.GetAllScootersAsync();
        }

        public async Task<int> CreateScooterAsync(Scooter scooter)
        {
            return await _scooterRepository.AddScooterAsync(scooter);

        }
        public async Task<int> AddScooterAsync(Scooter scooter)
        {
            return await _scooterRepository.AddScooterAsync(scooter);
        }

        public async Task<bool> UpdateScooterAsync(Scooter scooter)
        {
            return await _scooterRepository.UpdateScooterAsync(scooter);
        }

        public async Task<bool> DeleteScooterAsync(int id)
        {
            return await _scooterRepository.DeleteScooterAsync(id);
        }
    }
}
