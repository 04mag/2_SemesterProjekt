using Anden_SemesterProjekt.Server.Context;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public class AnsatRepository : IAnsatRepository
    {
        private readonly SLContext _context;
        public AnsatRepository()
        {
            _context = new SLContext();
        }

        public Mekaniker? ReadMekaniker(int id)
        {
            return _context.Mekanikere.Find(id);
        }

        public List<Mekaniker>? ReadMekanikere()
        {
            try
            {
                return _context.Mekanikere.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
