using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public interface IOrdreClientService
    {
        public Task<Ordre?> GetOrdre(int id);
        public Task<List<Ordre>?> GetOrdrer();
        public Task<List<Ordre>?> GetOrdrer(int kundeId);
        public Task<HttpResponseMessage> AddOrdre(Ordre ordre);
        public Task<HttpResponseMessage> DeleteOrdre(int id);
        public Task<HttpResponseMessage> UpdateOrdre(Ordre ordre);
    }
}
