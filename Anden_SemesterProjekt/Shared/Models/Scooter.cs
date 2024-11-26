using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public abstract class Scooter
    {
        public int ScooterId { get; set; }
        [Required (ErrorMessage = "Stelnummer er påkrævet.")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "Stelnummeret skal være mellem 15 og 20 tegn.")]
        public string Stelnummer { get; set; }
        [Required(ErrorMessage = "Registreringsnummer er påkrævet.")]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "Registreringsnummeret skal være mellem 4 og 6 tegn.")]
        public string? Registreringsnummer { get; set; }
        [Required(ErrorMessage = "Mærke er påkrævet.")]
        public int MærkeId { get; set; }

        public Mærke? Mærke { get; set; }
        public bool ErAktiv { get; set; }
       
    }
}
