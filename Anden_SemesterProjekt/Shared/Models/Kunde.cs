using Microsoft.Extensions.Options;
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
    public class Kunde
    {

        public int KundeId { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Navn skal være mellem 2 og 50 karaktere langt.")]
        public string Navn { get; set; } = string.Empty;
        [Required]
        [ValidateComplexType]
        public Adresse Adresse { get; set; } = new Adresse();
        [Required]
        public List<TlfNummer> TlfNumre { get; set; } = new List<TlfNummer>();
        [Required]
        //Regex til tjek af email. \b tjekker ord til ord, første om der kun er bogstaver, tal, punktum og bindestreg. Derefter om der er et @, og til sidst om der er et domæne.
        [RegularExpression(@"^([\w]+\.)?[\w]+@([\w]+\.)*[\w]+\.{1}\w{2,4}$", ErrorMessage = "Ugyldig emailadresse.")]
        public string Email { get; set; }
        [ForeignKey("TilknyttetMekaniker")]
        public int? MekanikerId { get; set; } = null;
        public Mekaniker? TilknyttetMekaniker { get; set; } = null;
        public List<KundeScooter>? Scootere { get; set; } = new List<KundeScooter>();
        [JsonIgnore]
        public List<Ordre>? Ordrer { get; set; } = new List<Ordre>();
        public bool ErAktiv { get; set; } = true;
    }
}
