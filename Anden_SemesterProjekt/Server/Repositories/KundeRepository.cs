using Anden_SemesterProjekt.Server.Context;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public class KundeRepository : IKundeRepository
    {
        private readonly SLContext _context;
        public KundeRepository()
        {
            _context = new SLContext();
        }

        /// <summary>
        /// Opretter ny kunde i databasen.
        /// </summary>
        /// <param name="kunde"></param>
        /// <returns>Retunerer kundeId hvis kunden er oprettet, ellers -1.</returns>
        public int CreateKunde(Kunde kunde)
        {
            _context.Kunder.Add(kunde);
            _context.SaveChanges();

            int id = kunde.KundeId;

            if (id > 0)
            {
                return id;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Sletter kunde fra databasen.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Om sletning var successfuld som bool.</returns>
        public bool DeleteKunde(int id)
        {
            Kunde? kunde = ReadKunde(id);

            if (kunde == null)
            {
                return false;
            }
            else
            {
                _context.Kunder.Remove(kunde);
                _context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Finder by ud fra postnummer.
        /// </summary>
        /// <param name="postnummer"></param>
        /// <returns>Retunerer By Object fra postnummer. Null hvis ikke fundet.</returns>
        public By? GetBy(int postnummer)
        {
            return _context.Byer.Find(postnummer);
        }

        /// <summary>
        /// Finder kunde ud fra id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retunerer kunde object. Null hvis ikke fundet.</returns>
        public Kunde? ReadKunde(int id)
        {
            return _context.Kunder.Find(id);
        }

        /// <summary>
        /// Finder alle kunder i databasen.
        /// </summary>
        /// <returns>Retunerer liste af kunder. Null hvis ingen fundet.</returns>
        public List<Kunde>? ReadKunder()
        {
            try
            {
                return _context.Kunder
                    .Include(k => k.TlfNumre)
                    .Include(k => k.Adresse).ThenInclude(a => a.By)
                    .Include(k => k.TilknyttetMekaniker)
                    .Include(k => k.Scootere).ThenInclude(m => m.Mærke)
                    .Include(k => k.Ordrer)
                    .ToList();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Finder kunder ud fra tlfNummer og mærke søgning.
        /// </summary>
        /// <param name="tlfNummer"></param>
        /// <param name="mærke"></param>
        /// <returns>Retunerer liste af kunder. Null hvis ikke fundet</returns>
        public List<Kunde>? ReadKunder(string tlfNummer, string mærke)
        {
            try
            {
                return _context.Kunder
                    .Include(k => k.TlfNumre)
                    .Include(k => k.Adresse).ThenInclude(a => a.By)
                    .Include(k => k.TilknyttetMekaniker)
                    .Include(k => k.Scootere).ThenInclude(m => m.Mærke)
                    .Include(k => k.Ordrer)
                    .Where(k => k.TlfNumre.Any(t => t.TelefonNummer.Contains(tlfNummer, StringComparison.OrdinalIgnoreCase)))
                    .Where(k => k.Scootere.Any(s => s.Mærke.ScooterMærke.Contains(mærke, StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Opdaterer kunde i databasen.
        /// </summary>
        /// <param name="kunde"></param>
        /// <returns>Om opdatering var successfuld som bool.</returns>
        public bool UpdateKunde(Kunde kunde)
        {
            var result = _context.Kunder.Find(kunde.KundeId);

            if (result == null)
            {
                return false;
            }
            else
            {
                _context.Update(kunde);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
