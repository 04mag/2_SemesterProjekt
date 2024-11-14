using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public interface IAnsatClientService
    {
        public Task<List<Mekaniker>> GetMekanikere();
        public Task<Mekaniker> GetMekaniker(int id);
    }
}
