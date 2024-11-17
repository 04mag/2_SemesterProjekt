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
            return await _context.Scootere.OfType<UdlejningsScooter>().Include(s=>s.Mærke)
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
            _context.Scootere.Update(udlejningsScooter);
            await _context.SaveChangesAsync();
            return udlejningsScooter.ScooterId;
        }

        public async Task<int> DeleteUdlejningsScooterAsync(int id)
        {
            var scooter = await _context.Scootere.OfType<UdlejningsScooter>()
                                                 .FirstOrDefaultAsync(s => s.ScooterId == id);
            if (scooter != null)
            {
                _context.Scootere.Remove(scooter);
                await _context.SaveChangesAsync();
                return id;
            }
            return 0;
        }
    }
}
