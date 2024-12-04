using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public interface IKundeClientService
    {
        public Task<List<Kunde>?> GetKunder();
        public Task<Kunde?> GetKunde(int id);
        public Task<Kunde?> PostKunde(Kunde kunde);
        public Task<HttpResponseMessage> PutKunde(Kunde kunde);
        public Task<HttpResponseMessage> DeleteKunde(int id);
        public Task<By?> GetBy(string postnummer);
    }
}
