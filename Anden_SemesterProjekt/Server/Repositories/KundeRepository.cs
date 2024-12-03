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
                bool aktiveOrdrer = _context.Ordrer.Any(o => o.KundeId == id && o.ErAfsluttet == false);

                if (aktiveOrdrer)
                {
                    return false;
                }

                kunde.ErAktiv = false;

                UpdateKunde(kunde);

                _context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Finder by ud fra postnummer.
        /// </summary>
        /// <param name="postnummer"></param>
        /// <returns>Retunerer By Object fra postnummer. Null hvis ikke fundet.</returns>
        public By? GetBy(string postnummer)
        {
            return _context.By.Find(postnummer);
        }

        /// <summary>
        /// Finder kunde ud fra id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retunerer kunde object. Null hvis ikke fundet.</returns>
        public Kunde? ReadKunde(int id)
        {
            try
            {
                var result = _context.Kunder
                    .Include(k => k.Scootere).ThenInclude(s => s.Mærke)
                    .Include(k => k.TlfNumre)
                    .Include(k => k.TilknyttetMekaniker).ThenInclude(m => m.Mærker)
                    .Include(k => k.Ordrer)
                    .Include(k => k.Adresse).ThenInclude(a => a.By).Where(k => k.KundeId == id).FirstOrDefault();

                if (result == null)
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
                return null;
            }
        }

        /// <summary>
        /// Finder alle kunder i databasen.
        /// </summary>
        /// <returns>Retunerer liste af kunder. Null hvis ingen fundet.</returns>
        public List<Kunde>? ReadKunder()
        {
            try
            {
                var result = _context.Kunder
                    .Include(k => k.Scootere).ThenInclude(s => s.Mærke)
                    .Include(k => k.TlfNumre)
                    .Include(k => k.TilknyttetMekaniker)
                    .Include(k => k.Ordrer)
                    .Include(k => k.Adresse).ThenInclude(a => a.By)
                    .Where(k => k.ErAktiv == true)
                    .ToList();

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
                var result = _context.Kunder
                    .Include(k => k.TlfNumre)
                    .Include(k => k.Adresse).ThenInclude(a => a.By)
                    .Include(k => k.TilknyttetMekaniker)
                    .Include(k => k.Scootere).ThenInclude(m => m.Mærke)
                    .Include(k => k.Ordrer)
                    .Where(k => k.TlfNumre.Any(t => t.TelefonNummer.Contains(tlfNummer, StringComparison.OrdinalIgnoreCase)))
                    .Where(k => k.Scootere.Any(s => s.Mærke.ScooterMærke.Contains(mærke, StringComparison.OrdinalIgnoreCase)))
                    .Where(k => k.ErAktiv == true)
                    .ToList();

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
            var existingKunde = _context.Kunder.Find(kunde.KundeId);
            if (existingKunde == null)
            {
                return false;
            }
            else
            {
                //Setter alle værdier på existingKunde til værdierne på kunde
                _context.Entry(existingKunde).CurrentValues.SetValues(kunde);


                //Opdaterer adresse
                var existingAdresse = _context.Adresser.Find(kunde.Adresse.AdresseId);
                if (existingAdresse == null)
                {
                    return false;
                }
                else
                {
                    _context.Entry(existingAdresse).CurrentValues.SetValues(kunde.Adresse);
                }


                //Sletter tlfNumre fra database som ikke længere findes i kunde objektet
                //Finder Id på alle kundens tlfnumre
                var allValidIds = kunde.TlfNumre.Select(t => t.TlfNummerId).ToList();
                //Finder alle tlfnumre som ikke findes i kunde objektet
                var missingRows = _context.TlfNumre.Where(t => t.KundeId == kunde.KundeId && !allValidIds.Contains(t.TlfNummerId)).ToList();
                

                foreach (var nummer in kunde.TlfNumre)
                {
                    if (nummer.TlfNummerId == 0)
                    {
                        existingKunde.TlfNumre.Add(nummer);
                    }
                }

                existingKunde.TlfNumre = existingKunde.TlfNumre.Except(missingRows).ToList();

                //Sletter scootere som ikke længere tilhører kunden
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

                

                _context.SaveChanges();
                return true;
            }
        }
    }
}
