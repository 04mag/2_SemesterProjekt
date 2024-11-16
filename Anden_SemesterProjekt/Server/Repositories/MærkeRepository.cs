using Anden_SemesterProjekt.Server.Context;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public class MærkeRepository : IMærkeRepository
    {
        private readonly SLContext _context;
        public Mærke? ReadMærke(int id)
        {
            return _context.Mærker.Find(id);
        }

        public List<Mærke>? ReadMærke()
        {
            return _context.Mærker.ToList();
        }

        public int CreateMærke(Mærke mærke)
        {
            _context.Mærker.Add(mærke);
            _context.SaveChanges();
            return mærke.MærkeId;
        }

        public int UpdateMærke(Mærke mærke)
        {
            _context.Mærker.Update(mærke);
            _context.SaveChanges();
            return mærke.MærkeId;
        }

        public int DeleteMærke(int id)
        {
            var mærke = _context.Mærker.Find(id);
            if (mærke != null)
            {
                _context.Mærker.Remove(mærke);
                _context.SaveChanges();
                return id;
            }
            else
            {
                return 0;
            }
        }
    }
}
