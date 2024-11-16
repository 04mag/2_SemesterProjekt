using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Client.Services
{
    public interface IUdlejningsScooterClientService
    {
        public Task<UdlejningsScooter?> GetUdlejningsScooter(int id);
        public Task<List<UdlejningsScooter>?> GetUdlejningsScootere();
        public Task<int> AddUdlejningsScooter(UdlejningsScooter udlejningsScooter); // Tilføjer et udlejningsScooter og returnerer et int
        public Task<int> DeleteUdlejningsScooter(int id); // Sletter et udlejningsScooter og returnerer et int. Denne int er id'et på det slettede udlejningsScooter
        public Task<int> updateUdlejningsScooter(UdlejningsScooter udlejningsScooter); // Opdaterer et udlejningsScooter og returnerer et int
    }
}
 