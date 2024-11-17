using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public interface IMærkeService
    {
        Task<Mærke?> GetMærkeAsync(int id);
        Task<List<Mærke>> GetAllMærkerAsync();
        Task<int> AddMærkeAsync(Mærke mærke);
        Task<int> UpdateMærkeAsync(Mærke mærke);
        Task<int> DeleteMærkeAsync(int id);
    }
}
