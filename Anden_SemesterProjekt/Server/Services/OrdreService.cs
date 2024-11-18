using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public class OrdreService : IOrdreService
    {
        private readonly IOrdreRepository _ordreRepository;

        public OrdreService(IOrdreRepository ordreRepository)
        {
            _ordreRepository = ordreRepository;
        }

        public async Task<Ordre?> GetOrdreAsync(int id)
        {
            return await _ordreRepository.ReadOrdreAsync(id);
        }

        public async Task<List<Ordre>> GetOrdrerAsync()
        {
            return await _ordreRepository.ReadOrdrerAsync();
        }

        public async Task<int> AddOrdreAsync(Ordre ordre)
        {
            return await _ordreRepository.CreateOrdreAsync(ordre);
        }

        public async Task<int> UpdateOrdreAsync(Ordre ordre)
        {
            return await _ordreRepository.UpdateOrdreAsync(ordre);
        }

        public async Task<int> DeleteOrdreAsync(int id)
        {
            return await _ordreRepository.DeleteOrdreAsync(id);
        }
    }
}
