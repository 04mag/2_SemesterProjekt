using Anden_SemesterProjekt.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public interface IScooterRepository
    {
        Task<List<Scooter>> GetAllScootersAsync();
        Task<Scooter?> GetScooterByIdAsync(int id);
        Task<int> AddScooterAsync(Scooter scooter);
        Task<bool> UpdateScooterAsync(Scooter scooter);
        Task<bool> DeleteScooterAsync(int id);
    }
}
