﻿using Anden_SemesterProjekt.Server.Context;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public class AnsatRepository : IAnsatRepository
    {
        private readonly SLContext _context;
        public AnsatRepository()
        {
            _context = new SLContext();
        }

        public async Task<Mekaniker?> ReadMekaniker(int id)
        {
            var result = await _context.Mekanikere.Include(m => m.Mærker).Include(m => m.Ordrer).FirstOrDefaultAsync(m => m.MekanikerId == id);

            if (result != null && result.MekanikerId == id)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Mekaniker>?> ReadMekanikere()
        {
            try
            {
                 return await _context.Mekanikere.Include(m => m.Mærker).Include(m => m.Ordrer).Where(m => m.ErAktiv == true).ToListAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
