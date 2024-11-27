using Anden_SemesterProjekt.Server.Context;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public class OrdreRepository : IOrdreRepository
    {
        private readonly SLContext _context;

        public OrdreRepository()
        {
            _context = new SLContext();
        }

        public async Task<Ordre?> ReadOrdreAsync(int id)
        {
            var result = await _context.Ordrer
                .Include(o => o.Kunde)
                .Include(o => o.KundeScooter)
                .Include(o => o.Mekaniker)
                .Include(o => o.VareLinjer)
                .Include(o => o.Udlejning)
                .FirstOrDefaultAsync(o => o.OrdreId == id);

            if (result == null)
            {
                return null;
            }

            if (result.OrdreId != id)
            {
                return null;
            }

            return result;
        }

        public async Task<List<Ordre>> ReadOrdrerAsync()
        {
            return await _context.Ordrer
                .Include(o => o.Kunde)
                .Include(o => o.KundeScooter)
                .Include(o => o.Mekaniker)
                .Include(o => o.VareLinjer)
                .Include(o => o.Udlejning)
                .ToListAsync();
        }

        public async Task<int> CreateOrdreAsync(Ordre ordre)
        {
            _context.Ordrer.Add(ordre);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateOrdreAsync(Ordre ordre)
        {
            // Henter scooteren fra databasen og gemmer den i existingScooter
            var existingOrdre = await _context.Ordrer.FindAsync(ordre.OrdreId);
            if (existingOrdre == null)
            {
                throw new ArgumentException("Scooteren findes ikke.");
            }
            // Alle properties på existingScooter bliver overskrevet af de properties der er i udlejningsScooter
            _context.Entry(existingOrdre).CurrentValues.SetValues(ordre);

            //Fjerne objects fra ordre, så de ikke bliver oprettet som nye i databasen
            existingOrdre.Kunde = ordre.Kunde;
            existingOrdre.KundeScooter = null;
            existingOrdre.Mekaniker = null;
            existingOrdre.VareLinjer = null;
            existingOrdre.Udlejning = ordre.Udlejning;

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
