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
                .Include(o => o.Kunde).ThenInclude(k => k.TlfNumre)
                .Include(o => o.Kunde).ThenInclude(k => k.Adresse).ThenInclude(a => a.By)
                .Include(o => o.KundeScooter)
                .Include(o => o.Mekaniker)
                .Include(o => o.VareLinjer)
                .Include(o => o.Udlejning).ThenInclude(u => u.UdlejningsScooter)
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
                .Include(o => o.Kunde).ThenInclude(k => k.TlfNumre)
                .Include(o => o.Kunde).ThenInclude(k => k.Adresse).ThenInclude(a => a.By)
                .Include(o => o.KundeScooter)
                .Include(o => o.Mekaniker)
                .Include(o => o.VareLinjer)
                .Include(o => o.Udlejning).ThenInclude(u => u.UdlejningsScooter)
                .ToListAsync();
        }

        public async Task<List<Ordre>> ReadOrdrerAsync(int kundeId)
        {
            return await _context.Ordrer
                .Include(o => o.Kunde).ThenInclude(k => k.TlfNumre)
                .Include(o => o.Kunde).ThenInclude(k => k.Adresse).ThenInclude(a => a.By)
                .Include(o => o.KundeScooter)
                .Include(o => o.Mekaniker)
                .Include(o => o.VareLinjer)
                .Include(o => o.Udlejning).ThenInclude(u => u.UdlejningsScooter)
                .Where(o => o.KundeId == kundeId)
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
                return 0;
            }

            // Alle properties på existingScooter bliver overskrevet af de properties der er i udlejningsScooter
            _context.Entry(existingOrdre).CurrentValues.SetValues(ordre);

            // Sætter udlejningen på existingOrdre til at være den udlejning der er i ordre
            existingOrdre.Udlejning = ordre.Udlejning;
            existingOrdre.Udlejning.UdlejningsScooter = ordre.Udlejning.UdlejningsScooter;

            //Finder udlejningsscooter i _context
            var existingScooter = await _context.Scootere.FindAsync(ordre.Udlejning.UdlejningsScooter.ScooterId);
            
            if (existingScooter != null)
            {
                //detach scooter from context
                _context.Entry(existingScooter).State = EntityState.Detached;
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteOrdreAsync(int id)
        {
            var ordre = await _context.Ordrer.FindAsync(id);
            _context.Ordrer.Remove(ordre);
            return await _context.SaveChangesAsync();
        }
    }
}
