using Anden_SemesterProjekt.Server.Context;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public class UudlejningsScooterRepository : IUdlejningsScooterRepository
    {
        private readonly SLContext _context;
        public UdlejningsScooter? ReadUdlejningsScooter(int id)
        {
            Scooter result = _context.Scootere.OfType<UdlejningsScooter>().FirstOrDefault(s => s.ScooterId == id);

            // Tjekker og returnerer kun, hvis typen er en UdlejningsScooter
            if (result is UdlejningsScooter udlejningsScooter)
            {
                return udlejningsScooter;
            }
            // Ellers returnér null
            return null;
        }

        public List<UdlejningsScooter>? ReadUdlejningsScootere()
        {
           var result = _context.Scootere.OfType<UdlejningsScooter>().ToList();
        }

        public int CreateUdlejningsScooter(UdlejningsScooter udlejningsScooter)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateUdlejningsScooter(UdlejningsScooter udlejningsScooter)
        {
            throw new System.NotImplementedException();
        }

        public int DeleteUdlejningsScooter(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
