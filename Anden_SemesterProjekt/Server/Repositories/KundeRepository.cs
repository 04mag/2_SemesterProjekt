using Anden_SemesterProjekt.Client.Pages.Kunder;
using Anden_SemesterProjekt.Server.Context;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public class KundeRepository : IKundeRepository
    {
        private readonly SLContext _context;

        //Det her i stedet for og drop singleton på repositories?
        //public KundeRepository(SLContext context)
        //{
        //    _context = context;
        //}

        public KundeRepository()
        {
            _context = new SLContext();
        }

        /// <summary>
        /// Opretter ny kunde i databasen.
        /// </summary>
        /// <param name="kunde"></param>
        /// <returns>Retunerer kundeId hvis kunden er oprettet, ellers -1.</returns>
        ///
        public async Task<int> CreateKunde(Kunde kunde)
        {
            int id = 0;
            try
            {
                await _context.Kunder.AddAsync(kunde);
                await _context.SaveChangesAsync();

                id = kunde.KundeId;
            }
            catch
            {
                throw new Exception("Kunde kunne ikke oprettes.");
            }

            if (id > 0)
            {
                return id;
            }
            else
            {
                throw new Exception("Kunde kunne ikke oprettes.");
            }
        }

        /// <summary>
        /// Sletter kunde fra databasen.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Om sletning var successfuld som bool.</returns>
        public async Task<bool> DeleteKunde(int id)
        {
            Kunde? kunde = await ReadKunde(id);

            if (kunde == null)
            {
                return false;
            }
            else
            {
                kunde.ErAktiv = false;

                try
                {
                    await UpdateKunde(kunde);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    throw new Exception("Kunde kunne ikke slettes, da kunde status ikke kunne opdateres.");
                }

                return true;
            }
        }

        /// <summary>
        /// Finder by ud fra postnummer.
        /// </summary>
        /// <param name="postnummer"></param>
        /// <returns>Retunerer By Object fra postnummer. Null hvis ikke fundet.</returns>
        public async Task<By?> GetBy(string postnummer)
        {
            return await _context.By.FindAsync(postnummer);
        }

        /// <summary>
        /// Finder kunde ud fra id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retunerer kunde object. Null hvis ikke fundet.</returns>
        public async Task<Kunde?> ReadKunde(int id)
        {
            try
            {
                var result = await _context.Kunder
                    .Include(k => k.Scootere!).ThenInclude(s => s.Mærke)
                    .Include(k => k.TlfNumre)
                    .Include(k => k.TilknyttetMekaniker)
                    .Include(k => k.Adresse).ThenInclude(a => a!.By)
                    .Where(k => k.KundeId == id)
                    .FirstOrDefaultAsync();

                if (result != null && result.KundeId == id)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw new Exception("Kunde kunne ikke findes.");
            }
        }

        /// <summary>
        /// Finder alle kunder i databasen.
        /// </summary>
        /// <returns>Retunerer liste af kunder. Null hvis ingen fundet.</returns>
        public async Task<List<Kunde>?> ReadKunder()
        {
            try
            {
                var result = await _context.Kunder
                    .Include(k => k.Scootere!).ThenInclude(s => s.Mærke)
                    .Include(k => k.TlfNumre)
                    .Include(k => k.TilknyttetMekaniker)
                    .Include(k => k.Adresse).ThenInclude(a => a!.By)
                    .Where(k => k.ErAktiv == true)
                    .ToListAsync();

                if (result.Count == 0)
                {
                    return null;
                }
                else
                {
                    return result;
                }
            }
            catch
            {
                throw new Exception("Kunder kunne ikke findes.");
            }
        }


        /// <summary>
        /// Opdaterer kunde i databasen.
        /// </summary>
        /// <param name="kunde"></param>
        /// <returns>Om opdatering var successfuld som bool.</returns>
        public async Task<bool> UpdateKunde(Kunde kunde)
        {
            var existingKunde = await _context.Kunder.FindAsync(kunde.KundeId);
            if (existingKunde == null)
            {
                throw new Exception("Kunden som blev forsøgt opdateret findes ikke.");
            }

            //Setter alle værdier på existingKunde til værdierne på kunde
            _context.Entry(existingKunde).CurrentValues.SetValues(kunde);


            //Opdaterer adresse
            if (kunde.Adresse == null)
            {
                kunde.Adresse = new Adresse();
            }
            
            var existingAdresse = await _context.Adresser.FindAsync(kunde.Adresse.AdresseId);
            if (existingAdresse == null)
            {
                throw new Exception("Adressen som blev forsøgt opdateret findes ikke.");
            }

            _context.Entry(existingAdresse).CurrentValues.SetValues(kunde.Adresse);


            //Sletter tlfNumre fra database som ikke længere findes i kunde objektet
            //Finder Id på alle kundens tlfnumre
            var allValidIds = kunde.TlfNumre.Select(t => t.TlfNummerId).ToList();
            //Finder alle tlfnumre som ikke findes i kunde objektet
            var missingRows = await _context.TlfNumre.Where(t => t.KundeId == kunde.KundeId && !allValidIds.Contains(t.TlfNummerId)).ToListAsync();


            foreach (var nummer in kunde.TlfNumre)
            {
                if (nummer.TlfNummerId == 0)
                {
                    existingKunde.TlfNumre.Add(nummer);
                }
            }

            existingKunde.TlfNumre = existingKunde.TlfNumre.Except(missingRows).ToList();


            //Sletter scootere som ikke længere tilhører kunden
            if (kunde.Scootere == null)
            {
                kunde.Scootere = new List<KundeScooter>();
            }

            //Finder Id på alle kundens scootere
            var allValidScooterIds = kunde.Scootere.Select(s => s.ScooterId).ToList();
            //Finder alle scootere som ikke findes i kunde objektet
            var missingScooterRows = _context.Scootere.OfType<KundeScooter>().Where(s => s.KundeId == kunde.KundeId && !allValidScooterIds.Contains(s.ScooterId)).ToList();

            if (existingKunde.Scootere == null)
            {
                existingKunde.Scootere = new List<KundeScooter>();
            }

            foreach (var scooter in kunde.Scootere)
            {
                if (scooter.ScooterId == 0)
                {
                    existingKunde.Scootere.Add(scooter);
                }
            }

            existingKunde.Scootere = existingKunde.Scootere.Except(missingScooterRows).ToList();



            await _context.SaveChangesAsync();
            return true;
        }
    }
}
