using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public interface IScooterRepository
    {
        Task<Scooter> ReadScooterAsync(int id);
        Task<List<UdlejningsScooter>> ReadUdlejningsScootereAsync();
        Task<List<KundeScooter>> ReadKundeScootereAsync(int kundeId);


        Task<int> CreateScooterAsync(Scooter scooter);
        Task<int> UpdateScooterAsync(Scooter Scooter);
        Task UpdateScooterTilgængelighedAsync(int scooterId, bool erTilgængelig);
        Task<int> DeleteScooterAsync(int id);
    }
}
