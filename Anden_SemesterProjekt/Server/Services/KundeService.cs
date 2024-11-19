using Anden_SemesterProjekt.Server.Repositories;
using Anden_SemesterProjekt.Shared.Models;

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
        /// Opretter ny kunde i databasen.
        /// </summary>
        /// <param name="kunde"></param>
        /// <returns>Retunerer kundeId hvis kunden er oprettet, ellers -1.</returns>
        public int CreateKunde(Kunde kunde)
        {
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
            return _kundeRepository.UpdateKunde(kunde);
        }

        public bool RemoveTlfNummer(int id)
        {
            return _kundeRepository.RemoveTlfNummer(id);
        }

        public int? AddTlfNummer(TlfNummer tlfNummer)
        {
            return _kundeRepository.AddTlfNummer(tlfNummer);
        }
    }
}
