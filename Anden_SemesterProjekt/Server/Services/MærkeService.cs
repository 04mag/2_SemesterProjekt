using Anden_SemesterProjekt.Server.Repositories;
using Anden_SemesterProjekt.Shared.Models;
namespace Anden_SemesterProjekt.Server.Services
{
    public class MærkeService : IMærkeService
    {
        private readonly IMærkeRepository _mærkeRepository;

        public MærkeService(IMærkeRepository mærkeRepository)
        {
            _mærkeRepository = mærkeRepository;
        }

        public async Task<Mærke?> GetMærkeAsync(int id)
        {
            return await _mærkeRepository.ReadMærkeAsync(id);
        }

        public async Task<List<Mærke>> GetAllMærkerAsync()
        {
            return await _mærkeRepository.ReadMærkerAsync();
        }

        public async Task<int> AddMærkeAsync(Mærke mærke)
        {
            return await _mærkeRepository.CreateMærkeAsync(mærke);
        }

        public async Task<int> UpdateMærkeAsync(Mærke mærke)
        {
            return await _mærkeRepository.UpdateMærkeAsync(mærke);
        }

        public async Task<int> DeleteMærkeAsync(int id)
        {
            return await _mærkeRepository.DeleteMærkeAsync(id);
        }
    }
}