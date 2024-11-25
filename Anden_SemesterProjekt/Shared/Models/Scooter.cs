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

            [Required(ErrorMessage = "Stelnummer er påkrævet.")]
            [StringLength(17, MinimumLength = 17, ErrorMessage = "Stelnummer skal være præcis 17 tegn.")] //Alle stelnumre efter 1981 har 17 karaktere
            public string Stelnummer { get; set; } = string.Empty;

            [Required(ErrorMessage = "Registreringsnummer er påkrævet.")]
            [RegularExpression(@"^[A-Za-z0-9]{1,10}$", ErrorMessage = "Registreringsnummer skal være mellem 1 og 10 alfanumeriske tegn.")]
            public string Registreringsnummer { get; set; } = string.Empty;

            public int MærkeId { get; set; }

            [JsonIgnore]
            public Mærke? Mærke { get; set; }
        }


}
