using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public interface IUdlejningsScooterRepository
    {
        public UdlejningsScooter? ReadUdlejningsScooter(int id);
        public List<UdlejningsScooter>? ReadUdlejningsScootere();
        public int CreateUdlejningsScooter(UdlejningsScooter udlejningsScooter);
        public int UpdateUdlejningsScooter(UdlejningsScooter udlejningsScooter);
        public int DeleteUdlejningsScooter(int id);
    }
}
