using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public interface IOrdreRepository
    {
        Task<Ordre?> ReadOrdreAsync(int id);
        Task<List<Ordre>> ReadOrdrerAsync();
        Task<int> CreateOrdreAsync(Ordre ordre);
        Task<int> UpdateOrdreAsync(Ordre ordre);
        Task<int> DeleteOrdreAsync(int id);
    }
}
