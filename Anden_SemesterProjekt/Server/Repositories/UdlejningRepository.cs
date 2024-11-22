using Anden_SemesterProjekt.Server.Context;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public class UdlejningRepository : IUdlejningRepository
    {
        private readonly SLContext _context;

        public UdlejningRepository(SLContext context)
        {
            _context = context;
        }

        public async Task<Udlejning?> GetUdlejningAsync(int id)
        {
            return await _context.Udlejninger.FindAsync(id);
        }

        public async Task<List<Udlejning>> GetUdlejningerAsync()
        {
            return await _context.Udlejninger.ToListAsync();
        }

        public async Task<int> AddUdlejningAsync(Udlejning udlejning)
        {
            _context.Udlejninger.Add(udlejning);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateUdlejningAsync(Udlejning udlejning)
        {
            // Henter scooteren fra databasen og gemmer den i existingScooter
            var existingUdlejning = await _context.Udlejninger.FindAsync(udlejning.OrdreId);
            if (existingUdlejning == null)
            {
                throw new ArgumentException("Scooteren findes ikke.");
            }
            // Alle properties på existingScooter bliver overskrevet af de properties der er i udlejningsScooter
            _context.Entry(existingUdlejning).CurrentValues.SetValues(udlejning);
            await _context.SaveChangesAsync();
            return udlejning.OrdreId;
        }

        public async Task<int> DeleteUdlejningAsync(int id)
        {
            var udlejning = await _context.Udlejninger.FindAsync(id);
            _context.Udlejninger.Remove(udlejning);
            return await _context.SaveChangesAsync();
        }
    }
}
