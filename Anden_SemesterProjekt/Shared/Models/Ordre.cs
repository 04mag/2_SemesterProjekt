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
        public Udlejning? Udlejning{ get; set; }
        public int? MekanikerId { get; set; }
        public Mekaniker? Mekaniker { get; set; }
        public string Bemærkninger { get; set; } = string.Empty;
    }
}
