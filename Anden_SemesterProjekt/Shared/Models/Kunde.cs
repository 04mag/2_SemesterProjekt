using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Kunde
    {

        public int KundeId { get; set; }
        public string Navn { get; set; }
        public Adresse Adresse { get; set; }
        public List<TlfNummer> TlfNumre { get; set; }
        public string Email { get; set; }
        public Mekaniker TilknyttetMekaniker { get; set; }
        public List<KundeScooter>? Scootere { get; set; }
        public List<Ordre>? Ordrer { get; set; }
    }
}
