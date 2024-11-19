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

        public async Task<T?> GetScooterAsync<T>(int id) where T : Scooter
        {
            return await _scooterRepository.ReadScooterAsync<T>(id);
        }

        public async Task<List<T>> GetAllScootereAsync<T>() where T : Scooter
        {
            return await _scooterRepository.ReadScootereAsync<T>();
        }

        public async Task<int> AddScooterAsync<T>(T scooter) where T : Scooter
        {
            return await _scooterRepository.CreateScooterAsync(scooter);
        }

        public async Task<int> UpdateScooterAsync<T>(T scooter) where T : Scooter
        {
            return await _scooterRepository.UpdateScooterAsync(scooter);
        }
        

        public async Task<int> DeleteScooterAsync(int id)
        {
            return await _scooterRepository.DeleteScooterAsync(id);
        }
    }
}