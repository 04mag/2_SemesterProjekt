using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Udlejning
    { 
        public int UdlejningId { get; set; }
        public int UdlejningsScooterId { get; set; }
        public UdlejningsScooter? UdlejningsScooter { get; set; }
        public int OrdreId { get; set; }
        [JsonIgnore]
        public Ordre? Ordre { get; set; }
        public DateTime StartDato { get; set; } = DateTime.Now;
        public DateTime SlutDato { get; set; } = DateTime.Now;
        public double AntalKmKørt { get; set; }
        public bool SelvrisikoUdløst { get; set; } = false;
        public double LejePrDag { get; set; } = 200;
        public double ForsikringPrDag { get; set; } = 100;
        public double PrisPrKm { get; set; } = 0.53;
        public double Selvrisiko { get; set; } = 1000;
       
        public double GetLejeForsikringPrisPrDag()
        {
            return LejePrDag + ForsikringPrDag;
        }

        public string GetLejeForsikringPrisPrDagString()
        {
            return GetLejeForsikringPrisPrDag().ToString("0.00");
        }

        public double GetTotalLejeForsikringPris()
        {
            double totalPris = 0;
            double antalDage = (SlutDato - StartDato).TotalDays + 1;
            totalPris += antalDage * LejePrDag;
            totalPris += antalDage * ForsikringPrDag;
            return totalPris;
        }

        public string GetTotalLejeForsikringPrisString()
        {
            return GetTotalLejeForsikringPris().ToString("0.00");
        }

        public string AntalKmKørtToString()
        {
            return AntalKmKørt.ToString("0");
        }

        public double GetTotalKmPris()
        {
            return AntalKmKørt * PrisPrKm;
        }

        public string GetTotalKmPrisString()
        {
            return GetTotalKmPris().ToString("0.00");
        }

        public string GetSelvrisikoToString()
        {
            return Selvrisiko.ToString("0.00");
        }

        public double GetTotalPris()
        {
            return GetTotalLejeForsikringPris() + GetTotalKmPris() + (SelvrisikoUdløst ? Selvrisiko : 0);
        }

        public string GetTotalPrisString()
        {
            return GetTotalPris().ToString("0.00");
        }
    }
}
