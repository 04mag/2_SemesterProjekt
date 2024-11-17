using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public abstract class Scooter
    {
        public int ScooterId { get; set; }
        public string Stelnummer { get; set; }
        public string? Registreringsnummer { get; set; }
        [JsonIgnore] public Mærke ScooterMærke { get; set; }
        public int MærkeId { get; set; }

    }
}
