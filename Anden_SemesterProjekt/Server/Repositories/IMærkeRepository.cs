using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public interface IMærkeRepository
    {
        Task<Mærke?> ReadMærkeAsync(int id);
        Task<List<Mærke>> ReadMærkerAsync();
        Task<int> CreateMærkeAsync(Mærke mærke);
        Task<int> UpdateMærkeAsync(Mærke mærke);
        Task<int> DeleteMærkeAsync(int id);
    }
}
