using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class TlfNummer
    {
        public int TlfNummerId { get; set; }
        [Required]
        [RegularExpression(@"^([2-9])\d{7}$", ErrorMessage = "Ugyldigt telefonnummer.")]
        public string TelefonNummer { get; set; }
        public int KundeId { get; set; }
        [JsonIgnore]
        public Kunde? Kunde { get; set; }
    }
}
