using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Kunde
    {

        public int KundeId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Navn skal være mellem 2 og 50 karaktere langt.")]
        public string Navn { get; set; }
        public Adresse Adresse { get; set; }
        public List<TlfNummer> TlfNumre { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Ugyldig Email.")]
        public string Email { get; set; }
        public Mekaniker? TilknyttetMekaniker { get; set; }
        public List<KundeScooter>? Scootere { get; set; }
        public List<Ordre>? Ordrer { get; set; }
    }
}
