using Anden_SemesterProjekt.Server.Context;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public class OrdreRepository : IOrdreRepository
    {
        private readonly SLContext _context;

        public OrdreRepository(SLContext context)
        {
            _context = context;
        }

        public async Task<Ordre?> ReadOrdreAsync(int id)
        {
            return await _context.Ordrer.FindAsync(id);
        }

        public async Task<List<Ordre>> ReadOrdrerAsync()
        {
            return await _context.Ordrer.ToListAsync();
        }

        public async Task<int> CreateOrdreAsync(Ordre ordre)
        {
            _context.Ordrer.Add(ordre);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateOrdreAsync(Ordre ordre)
        {
            // Henter scooteren fra databasen og gemmer den i existingScooter
            var existingOrdre = await _context.Scootere.FindAsync(ordre.OrdreId);
            if (existingOrdre == null)
            {
                throw new ArgumentException("Scooteren findes ikke.");
            }
            // Alle properties på existingScooter bliver overskrevet af de properties der er i udlejningsScooter
            _context.Entry(existingOrdre).CurrentValues.SetValues(ordre);
            await _context.SaveChangesAsync();
            return ordre.OrdreId;
        }

        public async Task<int> DeleteOrdreAsync(int id)
        {
            var ordre = await _context.Ordrer.FindAsync(id);
            _context.Ordrer.Remove(ordre);
            return await _context.SaveChangesAsync();
        }
    }
}
