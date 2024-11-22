using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public interface IOrdreService
    {
        Task<Ordre?> GetOrdreAsync(int id);
        Task<List<Ordre>> GetOrdrerAsync();
        Task<int> AddOrdreAsync(Ordre ordre);
        Task<int> UpdateOrdreAsync(Ordre ordre);
        Task<int> DeleteOrdreAsync(int id);
    }
}
