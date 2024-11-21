using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anden_SemesterProjekt.Server.Services
{
    public interface IScooterService 
    {
        Task<Scooter?> GetScooterAsync(int id);
        Task<List<UdlejningsScooter>> GetAllUdlejningsScootereAsync();
        Task<List<KundeScooter>> GetAllKundeScootereAsync();
        Task<int> AddScooterAsync(Scooter Scooter);
        Task<int> UpdateScooterAsync(Scooter Scooter);
        Task<int> DeleteScooterAsync(int id);
    }
}
