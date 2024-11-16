using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public interface IUdlejningsScooterService
    {
        public UdlejningsScooter? ReadUdlejningsScooter(int id);
        public List<UdlejningsScooter>? ReadUdlejningsScootere();
        public int CreateUdlejningsScooter(UdlejningsScooter udlejningsScooter);
        public int UpdateUdlejningsScooter(UdlejningsScooter udlejningsScooter);
        public int DeleteUdlejningsScooter(int id);

    }
}
