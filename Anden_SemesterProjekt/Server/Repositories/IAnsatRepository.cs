using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public interface IAnsatRepository
    {
        public Mekaniker? ReadMekaniker(int id);
        public List<Mekaniker>? ReadMekanikere();
    }
}
