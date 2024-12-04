using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public interface IAnsatService
    {
        public Task<Mekaniker?> ReadMekaniker(int id);
        public Task<List<Mekaniker>?> ReadMekanikere();
    }
}
