using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public interface IKundeService
    {
        public int CreateKunde(Kunde kunde);
        public Kunde? ReadKunde(int id);
        public List<Kunde>? ReadKunder();
        public List<Kunde>? ReadKunder(string tlfNummer, string mærke);
        public bool UpdateKunde(Kunde kunde);
        public bool DeleteKunde(int id);
        public By? GetBy(int postnummer);
    }
}
