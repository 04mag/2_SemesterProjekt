using Anden_SemesterProjekt.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Client.Services
{
    public interface IScooterClientService
    {
        Task<List<Scooter>> GetAllScootersAsync();
        Task<Scooter?> GetScooterByIdAsync(int id);
        Task AddScooterAsync(Scooter scooter);
        Task UpdateScooterAsync(Scooter scooter);
        Task DeleteScooterAsync(int id);
    }
}
