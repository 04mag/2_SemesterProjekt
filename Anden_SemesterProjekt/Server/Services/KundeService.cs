using Anden_SemesterProjekt.Server.Repositories;
using Anden_SemesterProjekt.Shared.Models;
using Anden_SemesterProjekt.Shared.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Anden_SemesterProjekt.Server.Services
{
    public class KundeService : IKundeService
    {
        private readonly IKundeRepository _kundeRepository;
        public KundeService(IKundeRepository kundeRepository)
        {
            _kundeRepository = kundeRepository;
        }

        /// <summary>
        /// Opretter ny kunde i databasen. Tjekker også for fejl i input af kunde objektet.
        /// </summary>
        /// <param name="kunde"></param>
        /// <returns>Retunerer kundeId hvis kunden er oprettet, ellers -1.</returns>
        public async Task<int> CreateKunde(Kunde kunde)
        {
            //Tjekker om kundens navn er mellem 2 og 50 karaktere langt.
            if (!SLValidator.StringLength(kunde.Navn, 2, 50)) return -1;

            //Tjekker om kunden har en gyldig email.
            if (!SLValidator.EmailIsValid(kunde.Email)) return -1;

            //Tjekker om alle tlfNumre er gyldige.
            foreach (var tlf in kunde.TlfNumre)
            {
                if (!SLValidator.PhoneNumberIsValid(tlf.TelefonNummer)) return -1;
            }

            //Adresse tjek
            if (kunde.Adresse == null) return -1;
            if (!SLValidator.StringLength(kunde.Adresse.Gadenavn, 2, 100)) return -1;
            if (!SLValidator.StringLength(kunde.Adresse.Husnummer, 1, 5)) return -1;
            if (!SLValidator.StringLength(kunde.Adresse.Etage, 0, 3)) return -1;
            if (!SLValidator.StringLength(kunde.Adresse.Side, 0, 3)) return -1;
            if (!SLValidator.StringLength(kunde.Adresse.Dørnummer, 0, 5)) return -1;

            //Postnummer tjekkes ikke da denne tjekkes i databasen i forhold til om foreign key er valid. Dermed valideres by også.

            return await _kundeRepository.CreateKunde(kunde);
        }

        /// <summary>
        /// Sletter kunde fra databasen.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Om sletning var successfuld som bool.</returns>
        public async Task<bool> DeleteKunde(int id)
        {
            return await _kundeRepository.DeleteKunde(id);
        }

        /// <summary>
        /// Finder by ud fra postnummer.
        /// </summary>
        /// <param name="postnummer"></param>
        /// <returns>Retunerer By Object fra postnummer. Null hvis ikke fundet.</returns>
        public async Task<By?> GetBy(string postnummer)
        {
            return await _kundeRepository.GetBy(postnummer);
        }

        /// <summary>
        /// Finder kunde ud fra id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retunerer kunde object. Null hvis ikke fundet.</returns>
        public async Task<Kunde?> ReadKunde(int id)
        {
            return await _kundeRepository.ReadKunde(id);
        }

        /// <summary>
        /// Finder alle kunder i databasen.
        /// </summary>
        /// <returns>Retunerer liste af kunder. Null hvis ingen fundet.</returns>
        public async Task<List<Kunde>?> ReadKunder()
        {
            return await _kundeRepository.ReadKunder();
        }

        /// <summary>
        /// Opdaterer kunde i databasen.
        /// </summary>
        /// <param name="kunde"></param>
        /// <returns>Om opdatering var successfuld som bool.</returns>
        public async Task<bool> UpdateKunde(Kunde kunde)
        {
            //Tjekker om kundens navn er mellem 2 og 50 karaktere langt.
            if (!SLValidator.StringLength(kunde.Navn, 2, 50)) return false;

            //Tjekker om kunden har en gyldig email.
            if (!SLValidator.EmailIsValid(kunde.Email)) return false;

            //Tjekker om alle tlfNumre er gyldige.
            foreach (var tlf in kunde.TlfNumre)
            {
                if (!SLValidator.PhoneNumberIsValid(tlf.TelefonNummer)) return false;
            }

            //Adresse tjek
            if (kunde.Adresse == null) return false;
            if (!SLValidator.StringLength(kunde.Adresse.Gadenavn, 2, 100)) return false;
            if (!SLValidator.StringLength(kunde.Adresse.Husnummer, 1, 5)) return false;
            if (!SLValidator.StringLength(kunde.Adresse.Etage, 0, 3)) return false;
            if (!SLValidator.StringLength(kunde.Adresse.Side, 0, 3)) return false;
            if (!SLValidator.StringLength(kunde.Adresse.Dørnummer, 0, 5)) return false;

            //Postnummer tjekkes ikke da denne tjekkes i databasen i forhold til om foreign key er valid. Dermed valideres by også.


            return await _kundeRepository.UpdateKunde(kunde);
        }
    }
}
