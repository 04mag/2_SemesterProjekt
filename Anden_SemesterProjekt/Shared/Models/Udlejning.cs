using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Udlejning
    {
        public int UdlejningId { get; set; }
        public int ScooterId { get; set; }
        public UdlejningsScooter UdlejningsScooter { get; set; }
        public int OrdreId { get; set; }
        public Ordre Ordre { get; set; }
        public DateTime StartDato { get; set; }
        public DateTime SlutDato { get; set; }
        public double AntalKmKørt { get; set; }
        public bool SelvrisikoUdløst { get; set; }
        public double lejePrDag { get; set; } = 200;
        public double forsikringPrDag { get; set; }
        public double prisPrKm { get; set; } = 0.53;

        public double selvrisiko { get; set; } = 1000;
    }
}
