using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anden_SemesterProjekt.Shared.Models
{
    public class Adresse
    {
        public int AdresseId { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Gadenavn skal være mellem 2 og 100 karaktere langt!")]
        public string Gadenavn { get; set; } = string.Empty;
        [StringLength(5, MinimumLength = 1, ErrorMessage = "Husnummer skal være mellem 1 og 5 karaktere langt!")]
        public string Husnummer { get; set; } = string.Empty;
        [StringLength(3, MinimumLength = 1, ErrorMessage = "Etage skal være mellem 1 og 3 karaktere langt!")]
        public string? Etage { get; set; } = string.Empty;
        [StringLength(2, MinimumLength = 1, ErrorMessage = "Side skal være mellem 1 og 2 karaktere langt!")]
        public string? Side { get; set; } = string.Empty;
        [StringLength(5, MinimumLength = 1, ErrorMessage = "Dørnummer skal være mellem 1 og 5 karaktere langt!")]
        public string? Dørnummer { get; set; } = string.Empty;
        [Required(ErrorMessage = "Postnummer skal udfyldes!")]
        [ForeignKey("By")]
        public string Postnummer { get; set; }
        public By By { get; set; }
        public int KundeId { get; set; }
        public Kunde Kunde { get; set; }
    }
}
