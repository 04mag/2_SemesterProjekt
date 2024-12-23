﻿using System;
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
        [JsonIgnore]
        public Vare? Vare { get; set; }

        // data annotation til at sikre at antal altid er over 0
        [Range(1, int.MaxValue, ErrorMessage = "Antal skal være større end 0")]
        public int? Antal { get; set; } = 1;

        public double Rabat { get; set; } = 0;
        public double VarePris { get; set; }
        public string VareBeskrivelse { get; set; } = "";
        public double YdelseAntalTimer { get; set; } = 0;

        public string GetPrisPrVareString()
        {
            return VarePris.ToString("0.00");
        }

        public string GetRabatString()
        {
            if (Rabat == 0)
            {
                return "";
            }
            return Rabat.ToString("0.00");
        }

        public double GetTotalPris()
        {
            double totalPris = VarePris * (int)Antal;
            if (Rabat != 0)
            {
                totalPris -= (double)Rabat;
            }
            return totalPris;
        }

        public string GetTotalPrisString()
        {
            return GetTotalPris().ToString("0.00");
        }

        public double GetTotalAntalTimer()
        {
            if (Antal == null)
            {
                return 0;
            }
            return YdelseAntalTimer * (int)Antal;
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

    