using Anden_SemesterProjekt.Server.Context;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public class UdlejningsScooterRepository : IUdlejningsScooterRepository
    {
        private readonly SLContext _context;

        public UdlejningsScooterRepository()
        {
            _context = new SLContext();
        }

        public async Task<UdlejningsScooter?> ReadUdlejningsScooterAsync(int id)
        {
            return await _context.Scootere.OfType<UdlejningsScooter>().Include(s => s.Mærke)
                .FirstOrDefaultAsync(s => s.ScooterId == id);
        }

        public async Task<List<UdlejningsScooter>> ReadUdlejningsScootereAsync()
        {
            return await _context.Scootere
                .OfType<UdlejningsScooter>()
                .Include(s => s.Mærke)
                .ToListAsync();
        }

        public async Task<int> CreateUdlejningsScooterAsync(UdlejningsScooter udlejningsScooter)
        {
            await _context.Scootere.AddAsync(udlejningsScooter);
            await _context.SaveChangesAsync();
            return udlejningsScooter.ScooterId;
        }

        public async Task<int> UpdateUdlejningsScooterAsync(UdlejningsScooter udlejningsScooter)
        {
            // Henter scooteren fra databasen og gemmer den i existingScooter
            var existingScooter = await _context.Scootere.FindAsync(udlejningsScooter.ScooterId); 
            if (existingScooter == null)
            {
                throw new ArgumentException("Scooteren findes ikke.");
            }
            // Alle properties på existingScooter bliver overskrevet af de properties der er i udlejningsScooter
            _context.Entry(existingScooter).CurrentValues.SetValues(udlejningsScooter);
            foreach (var udlejning in udlejningsScooter.Udlejninger)
                await _context.SaveChangesAsync();
            return udlejningsScooter.ScooterId; 
        }

        public async Task<int> DeleteUdlejningsScooterAsync(int id)
        {
            var scooter = await _context.Scootere.OfType<UdlejningsScooter>()
                                                 .FirstOrDefaultAsync(s => s.ScooterId == id);
            if (scooter != null)
            {
                scooter.ErAktiv = false;
                await _context.SaveChangesAsync();
                return id;
            }
            return 0;
        }
    }
}
