using Anden_SemesterProjekt.Server.Context;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public class KundeRepository : IKundeRepository
    {
        private readonly SLContext _context;
        public KundeRepository()
        {
            _context = new SLContext();
        }
        public int CreateKunde(Kunde kunde)
        {
            throw new NotImplementedException();
        }

        public bool DeleteKunde(int id)
        {
            Kunde? kunde = ReadKunde(id);

            if (kunde == null)
            {
                return false;
            }
            else
            {
                _context.Kunder.Remove(kunde);
                _context.SaveChanges();
                return true;
            }
        }

        public By? GetBy(int postnummer)
        {
            return _context.Byer.Find(postnummer);
        }

        public Kunde? ReadKunde(int id)
        {
            return _context.Kunder.Find(id);
        }

        public List<Kunde>? ReadKunder()
        {
            throw new NotImplementedException();
        }

        public List<Kunde>? ReadKunder(string tlfNummer, Mærke mærke)
        {
            throw new NotImplementedException();
        }

        public bool UpdateKunde(Kunde kunde)
        {
            throw new NotImplementedException();
        }
    }
}
