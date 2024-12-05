using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public interface IScooterClientService 
    {
        Task<List<UdlejningsScooter>> GetAllUdlejningsScootereAsync();
        Task<List<KundeScooter>> GetAllKundeScootereAsync();
        Task<Scooter> GetScooter(int id);
        Task<int> CreateScooter(Scooter scooter);
        
        Task<int> UpdateScooter(Scooter scooter);
        Task UpdateScooterTilgængelighed(int scooterId, bool erTilgængelig);
        Task<int> DeleteScooter(int id);
    }
}
 