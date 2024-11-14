using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public interface IAnsatService
    {
        public Mekaniker? ReadMekaniker(int id);
        public List<Mekaniker>? ReadMekanikere();
    }
}
