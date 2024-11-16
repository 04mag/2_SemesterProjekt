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

        public int CreateMærke(Mærke mærke)
        {
            return _mærkeRepository.CreateMærke(mærke);
        }

        public int DeleteMærke(int id)
        {
            return _mærkeRepository.DeleteMærke(id);
        }

        public Mærke? ReadMærke(int id)
        {
            return _mærkeRepository.ReadMærke(id);
        }

        public List<Mærke>? ReadMærke()
        {
            return _mærkeRepository.ReadMærke();
        }

        public int UpdateMærke(Mærke mærke)
        {
            return _mærkeRepository.UpdateMærke(mærke);
        }
    }
}
