using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public interface IAnsatRepository
    {
        public Task<Mekaniker?> ReadMekaniker(int id);
        public Task<List<Mekaniker>?> ReadMekanikere();
    }
}
