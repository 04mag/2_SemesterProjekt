using Anden_SemesterProjekt.Shared.Models;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public interface IVareRepository
    {
        /// <summary>
        /// Opretter en ny vare i databasen
        /// </summary>
        /// <param name="vare"></param>
        /// <returns>Returnerer Id hvis varen er oprettet</returns>
        public int CreateVare(Vare vare);

        /// <summary>
        /// Finder alle varer og ydelser i databasen
        /// </summary>
        /// <returns> Returnerer en liste af varer og ydelser. Null hvis ingen varer eller ydelser bliver fundet </returns>
        public List<Vare>? ReadAktiveVarerOgYdelser();

        /// <summary>
        /// Finder alle aktive varer i databasen
        /// </summary>
        /// <returns> Returnerer en liste af varer. Null hvis ingen varer bliver fundet v</returns>
        public List<Vare>? ReadAktiveVarer();

        /// <summary>
        /// Finder alle aktive ydelser i databasen
        /// </summary>
        /// <returns> Returnerer en liste af ydelser. Null hvis ingen ydelser bliver fundet </returns>
        public List<Ydelse>? ReadAktiveYdelser();

        /// <summary>
        /// Finder en vare eller ydelse i databasen udfra Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Returnerer varer eller ydelser og returnerer null hvis ingen bliver fundet </returns>
        public Vare? ReadVare(int id);

        /// <summary>
        /// Opdaterer en vare eller ydelse i databasen
        /// </summary>
        /// <param name="vare"></param>
        /// <returns> Boolen fortæller om opdateringen lykkedes eller ej  </returns>
        public bool UpdateVare(Vare vare);

        /// <summary>
        /// Sletter en vare eller ydelse i databasen
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Boolen fortæller om opdateringen lykkedes eller ej </returns>
        public bool DeleteVare(int id);
    }

}
