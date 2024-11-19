using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public interface IKundeRepository
    {
        /// <summary>
        /// Opretter ny kunde i databasen.
        /// </summary>
        /// <param name="kunde"></param>
        /// <returns>Retunerer kundeId hvis kunden er oprettet, ellers -1.</returns>
        public int CreateKunde(Kunde kunde);

        /// <summary>
        /// Finder kunde ud fra id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retunerer kunde object. Null hvis ikke fundet.</returns>
        public Kunde? ReadKunde(int id);

        /// <summary>
        /// Finder alle kunder i databasen.
        /// </summary>
        /// <returns>Retunerer liste af kunder. Null hvis ingen fundet.</returns>
        public List<Kunde>? ReadKunder();

        /// <summary>
        /// Finder kunder ud fra tlfNummer og mærke søgning.
        /// </summary>
        /// <param name="tlfNummer"></param>
        /// <param name="mærke"></param>
        /// <returns>Retunerer liste af kunder. Null hvis ikke fundet</returns>
        public List<Kunde>? ReadKunder(string tlfNummer, string mærke);

        /// <summary>
        /// Opdaterer kunde i databasen.
        /// </summary>
        /// <param name="kunde"></param>
        /// <returns>Om opdatering var successfuld som bool.</returns>
        public bool UpdateKunde(Kunde kunde);

        /// <summary>
        /// Sletter kunde fra databasen.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Om sletning var successfuld som bool.</returns>
        public bool DeleteKunde(int id);

        /// <summary>
        /// Finder by ud fra postnummer.
        /// </summary>
        /// <param name="postnummer"></param>
        /// <returns>Retunerer By Object fra postnummer. Null hvis ikke fundet.</returns>
        public By? GetBy(string postnummer);

        public bool RemoveTlfNummer(int id);

        public int? AddTlfNummer(TlfNummer tlfNummer);
    }
}
