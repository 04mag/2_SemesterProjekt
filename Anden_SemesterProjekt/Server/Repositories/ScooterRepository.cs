using Anden_SemesterProjekt.Server.Context;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public class ScooterRepository : IScooterRepository
    {
        private readonly SLContext _context;

        public ScooterRepository(SLContext context)
        {
            _context = context;
        }

        public async Task<List<Scooter>> GetAllScootersAsync()
        {
            return await _context.Scootere.Include(s => s.Mærke).ToListAsync();
        }

        public async Task<Scooter?> GetScooterByIdAsync(int id)
        {
            return await _context.Scootere.Include(s => s.Mærke)
                                          .FirstOrDefaultAsync(s => s.ScooterId == id);
        }

        public async Task<int> AddScooterAsync(Scooter scooter)
        {
            await _context.Scootere.AddAsync(scooter);
            await _context.SaveChangesAsync();
            return scooter.ScooterId;
        }

        public async Task<bool> UpdateScooterAsync(Scooter scooter)
        {
            var existingScooter = await _context.Scootere.FindAsync(scooter.ScooterId);
            if (existingScooter == null) return false;

            _context.Entry(existingScooter).CurrentValues.SetValues(scooter);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteScooterAsync(int id)
        {
            var scooter = await _context.Scootere.FindAsync(id);
            if (scooter == null) return false;

            _context.Scootere.Remove(scooter);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
