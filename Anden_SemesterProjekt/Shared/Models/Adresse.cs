using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Adresse
    {
        public int AdresseId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Gadenavn skal være mellem 2 og 100 karaktere langt!")]
        public string Gadenavn { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 2, ErrorMessage = "Husnummer skal være mellem 2 og 5 karaktere langt!")]
        public string Husnummer { get; set; }
        [StringLength(3, MinimumLength = 1, ErrorMessage = "Etage skal være mellem 1 og 3 karaktere langt!")]
        public string? Etage { get; set; }
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Side skal være 1 karakter langt!")]
        public string? Side { get; set; }
        [StringLength(5, MinimumLength = 1, ErrorMessage = "Dørnummer skal være mellem 1 og 5 karaktere langt!")]
        public string? Dørnummer { get; set; }
        [Required]
        public int Postnummer { get; set; }
        public By By { get; set; }
        public int KundeId { get; set; }
        public Kunde Kunde { get; set; }
    }
}
