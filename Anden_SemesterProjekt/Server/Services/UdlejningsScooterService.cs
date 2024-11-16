using Anden_SemesterProjekt.Server.Repositories;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Services
{
    public class UdlejningsScooterService : IUdlejningsScooterService
    {
       private readonly IUdlejningsScooterRepository _udlejningsScooterRepository;

        public UdlejningsScooterService(IUdlejningsScooterRepository udlejningsScooterRepository)
        {
            _udlejningsScooterRepository = udlejningsScooterRepository;
        }
        public UdlejningsScooter? ReadUdlejningsScooter(int id)
        {
            return _udlejningsScooterRepository.ReadUdlejningsScooter(id);
        }

        public List<UdlejningsScooter>? ReadUdlejningsScootere()
        {
            return _udlejningsScooterRepository.ReadUdlejningsScootere();
        }

        public int CreateUdlejningsScooter(UdlejningsScooter udlejningsScooter)
        {
            return _udlejningsScooterRepository.CreateUdlejningsScooter(udlejningsScooter);
        }

        public int UpdateUdlejningsScooter(UdlejningsScooter udlejningsScooter)
        {
            return _udlejningsScooterRepository.UpdateUdlejningsScooter(udlejningsScooter);
        }

        public int DeleteUdlejningsScooter(int id)
        {
            return _udlejningsScooterRepository.DeleteUdlejningsScooter(id);
        }

    }
}
