using Anden_SemesterProjekt.Shared.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Ordre
    {
        public int OrdreId { get; set; }
        public List<VareLinje>? VareLinjer { get; set; }
        public int? KundeId { get; set; }
        public Kunde? Kunde { get; set; }
        public int? KundeScooterId { get; set; }
        public KundeScooter? KundeScooter { get; set; }
        public DateTime? BetalingsDato { get; set; }
        public bool ErBetalt { get; set; }
        public bool ErAfsluttet { get; set; }
        public DateTime StartDato { get; set; } = DateTime.Now;
        [OrdreSlutDatoCheck]
        public DateTime SlutDato { get; set; } = DateTime.Now;
        public Udlejning? Udlejning { get; set; }
        public int? MekanikerId { get; set; }
        public Mekaniker? Mekaniker { get; set; }
        public string Bemærkninger { get; set; } = string.Empty;

        public string GetStatus()
        {
            if (ErAfsluttet && ErBetalt)
            {
                return "Kvittering";
            }
            else if (ErAfsluttet && !ErBetalt)
            {
                return "Faktura";
            }
            else
            {
                return "Uafsluttet";
            }
        }

        public string IdToString()
        {
            return OrdreId.ToString();
        }

        public double GetTotalPris()
        {
            double totalPris = 0;
            if (VareLinjer != null)
            {
                foreach (var vareLinje in VareLinjer)
                {
                    totalPris += vareLinje.GetTotalPris();
                }
            }
            return totalPris;
        }

        public string GetTotalPrisString()
        {
            return GetTotalPris().ToString("0.00");
        }

        public double GetTotalPrisMedMoms()
        {
            return GetTotalPris() * 1.25;
        }

        public string GetTotalPrisMedMomsString()
        {
            return GetTotalPrisMedMoms().ToString("0.00");
        }

        public double GetTotalMoms()
        {
            return GetTotalPris() * 0.25;
        }

        public string GetTotalMomsString()
        {
            return GetTotalMoms().ToString("0.00");
        }

        public double GetTotalAntalTimer()
        {
            double totalAntalTimer = 0;
            if (VareLinjer != null)
            {
                foreach (var vareLinje in VareLinjer)
                {
                    totalAntalTimer += vareLinje.GetTotalAntalTimer();
                }
            }
            return totalAntalTimer;
        }

        public string GetTotalAntalTimerString()
        {
            return GetTotalAntalTimer().ToString("0.00");
        }

        public bool OrdreContainsYdelse()
        {
            if (VareLinjer != null)
            {
                if (GetTotalAntalTimer() > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
