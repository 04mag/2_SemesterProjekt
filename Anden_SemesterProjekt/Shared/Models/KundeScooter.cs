using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class KundeScooter : Scooter
    {
        public int KundeId { get; set; }
        [JsonIgnore]
        public Kunde Kunde { get; set; }

        public override string ToString()
        {
            if (this.Mærke == null)
            {
                return $"{this.Registreringsnummer}";
            }
            else
            {
                return $"{this.Registreringsnummer} ({this.Mærke.ScooterMærke})";
            }
        }
    }
}
