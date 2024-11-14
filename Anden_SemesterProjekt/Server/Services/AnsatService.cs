using Anden_SemesterProjekt.Server.Repositories;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public class AnsatService
    {
        private readonly IAnsatRepository _ansatRepository;

        public AnsatService(IAnsatRepository ansatRepository)
        {
            _ansatRepository = ansatRepository;
        }

        public Mekaniker? ReadMekaniker(int id)
        {
            return _ansatRepository.ReadMekaniker(id);
        }

        public List<Mekaniker>? ReadMekanikere()
        {
            return _ansatRepository.ReadMekanikere();
        }
    }
}
