using Anden_SemesterProjekt.Server.Context;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public class ScooterRepository : IScooterRepository
    {
        private readonly SLContext _context;

        public ScooterRepository()
        {
            _context = new SLContext();
        }

        public async Task<int> CreateScooterAsync(Scooter scooter)
        {
            _context.Scootere.Add(scooter);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteScooterAsync(int id)
        {
            var scooter = await _context.Scootere.FindAsync(id);

            if (scooter == null)
            {
                return 0;
            }

            scooter.ErAktiv = false;
            _context.Scootere.Update(scooter);
            return await _context.SaveChangesAsync();
        }

        public async Task<Scooter> ReadScooterAsync(int id)
        {
            return await _context.Scootere.FindAsync(id);
        }

        public async Task<List<UdlejningsScooter>> ReadUdlejningsScootereAsync()
        {
            return await _context.Scootere.OfType<UdlejningsScooter>().Include(s => s.Mærke).ToListAsync();
        }

        public async Task<List<KundeScooter>> ReadKundeScootereAsync(int kundeId)
        {
            return await _context.Scootere.OfType<KundeScooter>().Include(s => s.Mærke).ToListAsync();
        }

        public async Task<int> UpdateScooterAsync(Scooter scooter)
        {
            _context.Entry(scooter).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateScooterTilgængelighedAsync(int scooterId, bool erTilgængelig)
        {
            var scooter = new UdlejningsScooter
            {
                ScooterId = scooterId,
                ErTilgængelig = erTilgængelig
            };

            _context.Scootere.Attach(scooter);
            _context.Entry(scooter).Property(s => s.ErTilgængelig).IsModified = true;

            await _context.SaveChangesAsync();
        }
    }
}
