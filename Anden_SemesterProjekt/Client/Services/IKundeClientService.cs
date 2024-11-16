using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public interface IKundeClientService
    {
        Task<List<Kunde>?> GetKunder();
        Task<List<Kunde>?> GetKunder(string tlfnummer, string mærke);
        Task<Kunde?> GetKunde(int id);
        Task<Kunde?> PostKunde(Kunde kunde);
        Task<int> PutKunde(Kunde kunde);
        Task<int> DeleteKunde(int id);
    }
}
