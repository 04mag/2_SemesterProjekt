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
        public int UdlejningsScooterId { get; set; }
        public UdlejningsScooter UdlejningsScooter { get; set; }
        public int OrdreId { get; set; }
        public Ordre Ordre { get; set; }
        public DateTime StartDato { get; set; } = DateTime.Now;
        public DateTime SlutDato { get; set; } = DateTime.Now.AddDays(1);
        public double AntalKmKørt { get; set; }
        public bool SelvrisikoUdløst { get; set; }
        public double LejePrDag { get; set; } = 200;
        public double ForsikringPrDag { get; set; }
        public double PrisPrKm { get; set; } = 0.53;
        public double Selvrisiko { get; set; } = 1000;
        public Udlejning()
        {
        }
    }
}
