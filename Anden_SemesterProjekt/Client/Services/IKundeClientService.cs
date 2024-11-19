using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public interface IKundeClientService
    {
        Task<List<Kunde>?> GetKunder();
        Task<List<Kunde>?> GetKunder(string tlfnummer, string mærke);
        Task<Kunde?> GetKunde(int id);
        Task<Kunde?> PostKunde(Kunde kunde);
        Task<HttpResponseMessage> PutKunde(Kunde kunde);
        Task<HttpResponseMessage> DeleteKunde(int id);
        Task<By?> GetBy(string postnummer);
        Task<TlfNummer?> PostTlfNummer(TlfNummer tlfNummer);
        Task<HttpResponseMessage> DeleteTlfNummer(int id);
    }
}
