using Anden_SemesterProjekt.Server.Context;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public class MærkeRepository : IMærkeRepository
    {
        private readonly SLContext _context;

        public MærkeRepository()
        {
            _context = new SLContext();
        }

        public async Task<Mærke?> ReadMærkeAsync(int id)
        {
            //return await _context.Mærker
            //    .Include(m => m.Mekanikere)
            //    .FirstOrDefaultAsync(m => m.MærkeId == id);

            return await _context.Mærker
                .Where(m => m.MærkeId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Mærke>> ReadMærkerAsync()
        {
            try
            {
                return await _context.Mærker.Include(m=>m.Mekanikere).ToListAsync();
            }
            catch (Exception ex)
            {
                // Log fejlen, f.eks. med en logging-framework
                Console.WriteLine($"Fejl ved læsning af mærker: {ex.Message}");
                return new List<Mærke>();
            }
        }

        public async Task<int> CreateMærkeAsync(Mærke mærke)
        {
            await _context.Mærker.AddAsync(mærke);
            await _context.SaveChangesAsync();
            return mærke.MærkeId;
        }

        public async Task<int> UpdateMærkeAsync(Mærke mærke)
        {
            _context.Mærker.Update(mærke);
            await _context.SaveChangesAsync();
            return mærke.MærkeId;
        }

        public async Task<int> DeleteMærkeAsync(int id)
        {
            var mærke = await _context.Mærker.FindAsync(id);
            if (mærke != null)
            {
                _context.Mærker.Remove(mærke);
                await _context.SaveChangesAsync();
                return id;
            }
            else
            {
                return 0;
            }
        }
    }
}