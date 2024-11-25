using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Anden_SemesterProjekt.Server.Services
{
    public interface IScooterService 
    {
        Task<Scooter?> ReadScooterAsync(int id);
        Task<List<UdlejningsScooter>> ReadUdlejningsScootere();
        Task<List<KundeScooter>> ReadKundeScootereAsync(int kundeId);
        Task<int> AddScooterAsync(Scooter Scooter);
        Task<int> UpdateScooterAsync(Scooter Scooter);
        Task<int> DeleteScooterAsync(int id);
    }
}
