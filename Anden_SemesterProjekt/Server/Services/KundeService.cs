using Anden_SemesterProjekt.Server.Repositories;
using Anden_SemesterProjekt.Shared.Models;
using Anden_SemesterProjekt.Shared.Validation;

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
        public int CreateKunde(Kunde kunde)
        {
            //Tjekker om kundens navn er mellem 2 og 50 karaktere langt.
            if (!SLValidator.StringLenght(kunde.Navn, 2, 50)) return -1;

            //Tjekker om kunden har en gyldig email.
            if (!SLValidator.EmailIsValid(kunde.Email)) return -1;

            //Tjekker om alle tlfNumre er gyldige.
            foreach (var tlf in kunde.TlfNumre)
            {
                if (!SLValidator.PhoneNumberIsValid(tlf.TelefonNummer)) return -1;
            }

            //Adresse tjek
            if (!SLValidator.StringLenght(kunde.Adresse.Gadenavn, 2, 100)) return -1;
            if (!SLValidator.StringLenght(kunde.Adresse.Husnummer, 1, 5)) return -1;
            if (!SLValidator.StringLenght(kunde.Adresse.Etage, 0, 3)) return -1;
            if (!SLValidator.StringLenght(kunde.Adresse.Side, 0, 3)) return -1;
            if (!SLValidator.StringLenght(kunde.Adresse.Dørnummer, 0, 5)) return -1;

            //Postnummer tjekkes ikke da denne tjekkes i databasen i forhold til om foreign key er valid. Dermed valideres by også.

            return _kundeRepository.CreateKunde(kunde);
        }

        /// <summary>
        /// Sletter kunde fra databasen.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Om sletning var successfuld som bool.</returns>
        public bool DeleteKunde(int id)
        {
            return _kundeRepository.DeleteKunde(id);
        }

        /// <summary>
        /// Finder by ud fra postnummer.
        /// </summary>
        /// <param name="postnummer"></param>
        /// <returns>Retunerer By Object fra postnummer. Null hvis ikke fundet.</returns>
        public By? GetBy(string postnummer)
        {
            return _kundeRepository.GetBy(postnummer);
        }

        /// <summary>
        /// Finder kunde ud fra id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retunerer kunde object. Null hvis ikke fundet.</returns>
        public Kunde? ReadKunde(int id)
        {
            return _kundeRepository.ReadKunde(id);
        }

        /// <summary>
        /// Finder alle kunder i databasen.
        /// </summary>
        /// <returns>Retunerer liste af kunder. Null hvis ingen fundet.</returns>
        public List<Kunde>? ReadKunder()
        {
            return _kundeRepository.ReadKunder();
        }

        /// <summary>
        /// Finder kunder ud fra tlfNummer og mærke søgning.
        /// </summary>
        /// <param name="tlfNummer"></param>
        /// <param name="mærke"></param>
        /// <returns>Retunerer liste af kunder. Null hvis ikke fundet</returns>
        public List<Kunde>? ReadKunder(string tlfNummer, string mærke)
        {
            return _kundeRepository.ReadKunder(tlfNummer, mærke);
        }

        /// <summary>
        /// Opdaterer kunde i databasen.
        /// </summary>
        /// <param name="kunde"></param>
        /// <returns>Om opdatering var successfuld som bool.</returns>
        public bool UpdateKunde(Kunde kunde)
        {
            //Tjekker om kundens navn er mellem 2 og 50 karaktere langt.
            if (!SLValidator.StringLenght(kunde.Navn, 2, 50)) return false;

            //Tjekker om kunden har en gyldig email.
            if (!SLValidator.EmailIsValid(kunde.Email)) return false;

            //Tjekker om alle tlfNumre er gyldige.
            foreach (var tlf in kunde.TlfNumre)
            {
                if (!SLValidator.PhoneNumberIsValid(tlf.TelefonNummer)) return false;
            }

            //Adresse tjek
            if (!SLValidator.StringLenght(kunde.Adresse.Gadenavn, 2, 100)) return false;
            if (!SLValidator.StringLenght(kunde.Adresse.Husnummer, 1, 5)) return false;
            if (!SLValidator.StringLenght(kunde.Adresse.Etage, 0, 3)) return false;
            if (!SLValidator.StringLenght(kunde.Adresse.Side, 0, 3)) return false;
            if (!SLValidator.StringLenght(kunde.Adresse.Dørnummer, 0, 5)) return false;

            //Postnummer tjekkes ikke da denne tjekkes i databasen i forhold til om foreign key er valid. Dermed valideres by også.


            return _kundeRepository.UpdateKunde(kunde);
        }
    }
}
