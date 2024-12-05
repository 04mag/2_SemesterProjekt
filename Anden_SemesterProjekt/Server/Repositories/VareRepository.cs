using Anden_SemesterProjekt.Server.Context;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Anden_SemesterProjekt.Server.Repositories
{
    public class VareRepository : IVareRepository
    {
        private readonly SLContext _context;
        public VareRepository()
        {
            _context = new SLContext();
        }

        /// <summary>
        /// Opretter en ny vare i databasen
        /// </summary>
        /// <param name="vare"></param>
        /// <returns></returns>
        public int CreateVare(Vare vare)
        {
            _context.Varer.Add(vare);
            _context.SaveChanges();
            int id = vare.Id;

            if(id > 0)
            {
                return id;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Henter alle aktive varer og ydelser i databasen, uanset typen. 
        /// </summary>
        /// <returns> Return type er en generisk liste af Vare, da Vare er en fælles baseklasse for både Vare og Ydelser og returnerer Null hvis ikke findes </returns>
        public List<Vare>? ReadAktiveVarerOgYdelser()
        {
            return _context.Varer.Where(v => v.ErAktiv).ToList(); //Filteret v.ErAktiv fordi både varer og ydelser er inkluderet i samme tabel - polymorfi?
        }


        /// <summary>
        /// Finder kun aktive varer i databasen
        /// </summary>
        /// <returns> Returnerer en liste af aktive varer og returnerer Null hvis ikke findes </returns>
        public List<Vare>? ReadAktiveVarer()
        {
            var vare =  _context.Varer
            .Where(v => v.ErAktiv && v.GetType() == typeof(Vare)) //v.GetType() == typeof(Vare) sikrer at kun objekter af typen Vare bliver returneret
            .ToList();
            if (vare.Count == 0)
            {
                return null;
            }
            return vare;
        }

        /// <summary>
        /// Finder kun aktive ydelser i databasen
        /// </summary>
        /// <returns> Returnerer en liste af aktive ydelser og returnerer Null hvis ikke findes </returns>
        public List<Ydelse>? ReadAktiveYdelser()
        {
            return _context.Varer.OfType<Ydelse>().Where(v => v.ErAktiv).ToList();
                
        }
        
        /// <summary>
        /// Finder en vare i databasen udfra Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Returnerer vare object. Null hvis id ikke findes </returns>
        public Vare? ReadVare(int id)
        {
            return _context.Varer.Find(id);
        }

        /// <summary>
        /// Opdaterer en vare i databasen
        /// </summary>
        /// <param name="vare"></param>
        /// <returns> Fortæller om opdateringen lykkedes som bool </returns>
        public bool  UpdateVare(Vare vare)
        {
            var eksisterendeVare = _context.Varer.Find(vare.Id);

            if (eksisterendeVare == null)
            {
                return false;
            }
            else
            {
                _context.Entry(eksisterendeVare).CurrentValues.SetValues(vare);
                _context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Sletter en vare i databasen
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Fortæller om sletningen lykkedes som bool </returns>
        public bool DeleteVare(int id)
        {
            Vare? vare = ReadVare(id);

            if (vare != null) 
            { 
                return false;
            }
            else
            {
                _context.Varer.Remove(vare);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
