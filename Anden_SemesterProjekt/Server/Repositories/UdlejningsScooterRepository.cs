using Anden_SemesterProjekt.Server.Context;
using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public class UdlejningsScooterRepository : IUdlejningsScooterRepository
    {
        private readonly SLContext _context;
        public UdlejningsScooter? ReadUdlejningsScooter(int id)
        {
         return  _context.Scootere.OfType<UdlejningsScooter>().FirstOrDefault(s => s.ScooterId == id);
        }

        public List<UdlejningsScooter>? ReadUdlejningsScootere()
        {
           return _context.Scootere.OfType<UdlejningsScooter>().ToList();
           
        }

        public int CreateUdlejningsScooter(UdlejningsScooter udlejningsScooter)
        {
            _context.Scootere.Add(udlejningsScooter);
             _context.SaveChanges();
            return udlejningsScooter.ScooterId;
        }

        public int UpdateUdlejningsScooter(UdlejningsScooter udlejningsScooter)
        {
            _context.Scootere.Update(udlejningsScooter);
            _context.SaveChanges();
            return udlejningsScooter.ScooterId;
        }

        public int DeleteUdlejningsScooter(int id)
        {
            var scooter = _context.Scootere.OfType<UdlejningsScooter>().FirstOrDefault(s => s.ScooterId == id);
            if (scooter != null)
            {
                _context.Scootere.Remove(scooter);
                _context.SaveChanges();
                return id;
            }
            else
            {
                return 0;
            }
        }
    }
}
