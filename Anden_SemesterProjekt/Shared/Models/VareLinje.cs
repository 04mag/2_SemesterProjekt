using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class VareLinje
    {
        public int VareLinjeId { get; set; }
        public int OrdreId { get; set; }
        [JsonIgnore]
        public Ordre? Ordre { get; set; }
        public int VareId { get; set; }
        public Vare? Vare { get; set; }

        // data annotation til at sikre at antal altid er over 0
        [Range(1, int.MaxValue, ErrorMessage = "Antal skal være større end 0")]
        public int? Antal { get; set; } = 1;

        public double Rabat { get; set; } = 0;
        public double VarePris { get; set; }
        public string VareBeskrivelse { get; set; } = "";
        public double YdelseAntalTimer { get; set; } = 0;

        public double GetTotalPris()
        {
            if (Antal == null)
            {
                return 0;
            }
            double totalPris = (VarePris - Rabat) * (int)Antal;
           
            return totalPris;
        }

        public double GetTotalAntalTimer()
        {
            if (Antal == null)
            {
                return 0;
            }
            return YdelseAntalTimer * (int)Antal;
        }

        public string GetTotalPrisString()
        {
            return GetTotalPris().ToString("0.00");
        }

        public string GetAntalTimerString()
        {
            return YdelseAntalTimer.ToString("0.00");
        }

        public string GetTotalAntalTimerString()
        {
            return GetTotalAntalTimer().ToString("0.00");
        }

    }
}

    