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
                .Include(o => o.Kunde).ThenInclude(k => k!.TlfNumre)
                .Include(o => o.Kunde).ThenInclude(k => k!.Adresse).ThenInclude(a => a!.By)
                .Include(o => o.KundeScooter).ThenInclude(k => k!.Mærke)
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
                .Include(o => o.Kunde).ThenInclude(k => k!.TlfNumre)
                .Include(o => o.Kunde).ThenInclude(k => k!.Adresse).ThenInclude(a => a!.By)
                .Include(o => o.KundeScooter).ThenInclude(k => k!.Mærke)
                .Include(o => o.Mekaniker)
                .Include(o => o.VareLinjer)
                .Include(o => o.Udlejning).ThenInclude(u => u!.UdlejningsScooter)
                .ToListAsync();
        }

        public async Task<List<Ordre>> ReadOrdrerAsync(int kundeId)
        {
            return await _context.Ordrer
                .Include(o => o.Kunde).ThenInclude(k => k!.TlfNumre)
                .Include(o => o.Kunde).ThenInclude(k => k!.Adresse).ThenInclude(a => a!.By)
                .Include(o => o.KundeScooter).ThenInclude(k => k!.Mærke)
                .Include(o => o.Mekaniker)
                .Include(o => o.VareLinjer)
                .Include(o => o.Udlejning).ThenInclude(u => u!.UdlejningsScooter)
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
            var existingOrdre = await _context.Ordrer.FindAsync(ordre.OrdreId);
            if (existingOrdre == null)
            {
                return 0;
            }

            _context.Entry(existingOrdre).CurrentValues.SetValues(ordre);

            // Sætter udlejningen på existingOrdre til at være den udlejning der er i ordre
            if (ordre.Udlejning != null)
            {
                existingOrdre.Udlejning = ordre.Udlejning;
                if (ordre.Udlejning.UdlejningsScooter != null)
                {
                    existingOrdre.Udlejning.UdlejningsScooter.ErTilgængelig = ordre.Udlejning.UdlejningsScooter.ErTilgængelig;
                }
                existingOrdre.VareLinjer = ordre.VareLinjer;
            }

            if (ordre.Udlejning != null && ordre.Udlejning.UdlejningsScooter != null)
            {
                //Finder udlejningsscooter i _context
                Scooter? existingScooter = await _context.Scootere.FindAsync(ordre.Udlejning.UdlejningsScooter.ScooterId);

                if (existingScooter != null)
                {
                    //detach scooter from context
                    _context.Entry(existingScooter).State = EntityState.Detached;
                }
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
