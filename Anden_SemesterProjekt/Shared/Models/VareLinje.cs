using System;
using System.Collections.Generic;
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
        public int? Antal { get; set; }
        public double? Rabat { get; set; }
        public double VarePris { get; set; }
        public double VareBeskrivelse { get; set; }
        public double YdelseAntalTimer { get; set; } = 0;
    }
}

    