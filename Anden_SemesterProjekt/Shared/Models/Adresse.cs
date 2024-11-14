using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Adresse
    {
        public int AdresseId { get; set; }
        public string Gadenavn { get; set; }
        public string Husnummer { get; set; }
        public string? Etage { get; set; }
        public string? Side { get; set; }
        public string? Dørnummer { get; set; }
        public string Postnummer { get; set; }
        public By By { get; set; }
        public int KundeId { get; set; }
        public Kunde Kunde { get; set; }
    }
}
