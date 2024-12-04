using Anden_SemesterProjekt.Server.Repositories;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public class AnsatService : IAnsatService
    {
        private readonly IAnsatRepository _ansatRepository;

        public AnsatService(IAnsatRepository ansatRepository)
        {
            _ansatRepository = ansatRepository;
        }

        public async Task<Mekaniker?> ReadMekaniker(int id)
        {
            return await _ansatRepository.ReadMekaniker(id);
        }

        public async Task<List<Mekaniker>?> ReadMekanikere()
        {
            return await _ansatRepository.ReadMekanikere();
        }
    }
}
