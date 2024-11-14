using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Reparation : Vare
    {

        public Mekaniker Mekaniker { get; set; }
        public KundeScooter Scooter { get; set; } 
        public DateTime StartDato { get; set; }
        public DateTime SlutDato { get; set; }
        public Status Status { get; set; }
        public string Noter { get; set; }
        public double Timer { get; set; }
        public List<Ydelse> Ydelser { get; set; }
    }
    public enum Status
    {
        Afventer,
        Igang,
        AfventerReservedele,
        Færdig,
    }
}
