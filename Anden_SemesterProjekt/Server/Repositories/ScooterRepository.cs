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

        public async Task<T?> ReadScooterAsync<T>(int id) where T : Scooter
        {
            return await _context.Scootere
                .OfType<T>()              // Begræns typen til den angivne subklasse
                .Include(s => s.Mærke)    // Inkluder relateret data
                .FirstOrDefaultAsync(s => s.ScooterId == id);
        }

        // Generisk metode til at læse alle scootere af en bestemt type
        public async Task<List<T>> ReadScootereAsync<T>() where T : Scooter
        {
            return await _context.Scootere
                .OfType<T>()              // Begræns typen til den angivne subklasse
                .Include(s => s.Mærke)    // Inkluder relateret data
                .ToListAsync();
        }
     

        public async Task<int> CreateScooterAsync<T>(T Scooter) where T: Scooter
        {
            await _context.Scootere.AddAsync(Scooter);
            await _context.SaveChangesAsync();
            return Scooter.ScooterId;
        }

        public async Task<int> UpdateScooterAsync<T>(T Scooter) where T : Scooter
        {
            // Henter scooteren fra databasen og gemmer den i existingScooter
            var existingScooter = await _context.Scootere.FindAsync(Scooter.ScooterId); 
            if (existingScooter == null)
            {
                throw new ArgumentException("Scooteren findes ikke.");
            }
            // Alle properties på existingScooter bliver overskrevet af de properties der er i udlejningsScooter
            _context.Entry(existingScooter).CurrentValues.SetValues(Scooter);
            await _context.SaveChangesAsync();
            return Scooter.ScooterId;
        }

        public async Task<int> DeleteScooterAsync(int id)
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
