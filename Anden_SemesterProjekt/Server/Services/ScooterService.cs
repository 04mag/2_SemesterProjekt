using Anden_SemesterProjekt.Server.Repositories;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public class ScooterService<T> : IScooterService <T> where T : Scooter
    {
        private readonly IScooterRepository<T> _scooterRepository;

        public ScooterService(IScooterRepository<T> scooterRepository)
        {
            _scooterRepository = scooterRepository;
        }

        public async Task<T?> GetScooterAsync(int id) 
        {
            return await _scooterRepository.ReadScooterAsync(id);
        }

        public async Task<List<T>> GetAllScootereAsync() 
        {
            return await _scooterRepository.ReadScootereAsync();
        }

        public async Task<int> AddScooterAsync(T scooter) 
        {
            return await _scooterRepository.CreateScooterAsync(scooter);
        }

        public async Task<int> UpdateScooterAsync(T scooter) 
        {
            return await _scooterRepository.UpdateScooterAsync(scooter);
        }
        

        public async Task<int> DeleteScooterAsync(int id)
        {
            return await _scooterRepository.DeleteScooterAsync(id);
        }
    }
}