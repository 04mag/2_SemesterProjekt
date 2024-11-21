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

        public async Task<Scooter?> GetScooterAsync(int id) 
        {
            return await _scooterRepository.ReadScooterAsync(id);
        }

        public async Task<List<KundeScooter>> GetAllKundeScootereAsync() 
        {
            return await _scooterRepository.ReadKundeScootereAsync();
        }
        public async Task<List<UdlejningsScooter>> GetAllUdlejningsScootereAsync()
        {
            return await _scooterRepository.ReadUdlejningsScootereAsync();
        }

        public async Task<int> AddScooterAsync(Scooter scooter) 
        {
            if (scooter == KundeScooter)
            {

            }
                return await _scooterRepository.CreateScooterAsync(scooter);
        }

        public async Task<int> UpdateScooterAsync(Scooter scooter) 
        {
            return await _scooterRepository.UpdateScooterAsync(scooter);
        }
        

        public async Task<int> DeleteScooterAsync(int id)
        {
            return await _scooterRepository.DeleteScooterAsync(id);
        }
    }
}