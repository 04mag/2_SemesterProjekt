using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public interface IScooterClientService 
    {
        Task<List<UdlejningsScooter>> GetAllUdlejningsScootereAsync();
        Task<List<KundeScooter>> GetAllKundeScootereAsync();
        Task<Scooter> GetScooter(int id);
        Task<int> CreateUdlejningsScooter(UdlejningsScooter scooter);
        Task<int> CreateKundeScooter(KundeScooter scooter);
        Task<int> UpdateScooter(Scooter scooter);
        Task<int> DeleteScooter(int id);
    }
}
 