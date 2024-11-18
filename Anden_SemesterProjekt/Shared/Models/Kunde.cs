using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Kunde
    {

        public int KundeId { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Navn skal være mellem 2 og 50 karaktere langt.")]
        public string Navn { get; set; } = string.Empty;
        [ForeignKey("Adresse")]
        public int AdresseId { get; set; }
        [ValidateComplexType]
        public Adresse Adresse { get; set; } = new Adresse();
        [Required]
        public List<TlfNummer> TlfNumre { get; set; } = new List<TlfNummer>();
        [Required]
        [EmailAddress(ErrorMessage = "Ugyldig Email.")]
        public string Email { get; set; }
        public Mekaniker? TilknyttetMekaniker { get; set; }
        public List<KundeScooter> Scootere { get; set; } = new List<KundeScooter>();
        public List<Ordre>? Ordrer { get; set; }
    }
}
