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
            var result = _context.Mekanikere.Include(m => m.Mærker).Include(m => m.Ordrer).FirstOrDefault(m => m.MekanikerId == id);

            if (result != null && result.MekanikerId == id)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public List<Mekaniker>? ReadMekanikere()
        {
            try
            {
                return _context.Mekanikere.Include(m => m.Mærker).Include(m => m.Ordrer).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
